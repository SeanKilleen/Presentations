using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Akka.Actor;

namespace Supervision
{
    public partial class Main : Form
    {
        public static ActorSystem system;
        
        IActorRef boss;
        Timer updateTimer;
        Timer messageTimer;

        public Main()
        {
            InitializeComponent();

            updateTimer = new Timer() { Interval = 1000 };
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Enabled = true;

            messageTimer = new Timer() { Interval = 1000 };
            messageTimer.Tick += MessageTimer_Tick;
            //messageTimer.Enabled = true;

            system = ActorSystem.Create("villains");
            oneForOneToolStripMenuItem_Click(null, null);
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            boss.Tell(new CrackTheWhipMessage());
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            foreach (var item in Controls)
            {
                if (item is Minion)
                {
                    ((Minion)item).RefreshUI();
                }
            }
        }

        public void MinionAdded(IActorRef minion)
        {
            Minion minionControl = new Minion(minion, system);
            minionControl.Dock = DockStyle.Top;
            this.Invoke(new MethodInvoker(() => Controls.Add(minionControl)));            
        }
        
        private void addMinionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boss.Tell(new AddMinionMessage());
        }

        private void oneForOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oneForOneToolStripMenuItem.Checked = true;
            allForOneToolStripMenuItem.Checked = false;

            SetSupervisorStrategy(new OneForOneStrategy(
                maxNrOfRetries: 10,
                withinTimeRange: TimeSpan.FromSeconds(30),
                localOnlyDecider: x =>
                {
                    if (x is EvilException)
                        return Directive.Stop;

                    // otherwise restart the failing child
                    else return Directive.Restart;
                }));
        }

        private void allForOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oneForOneToolStripMenuItem.Checked = false;
            allForOneToolStripMenuItem.Checked = true;

            SetSupervisorStrategy(new AllForOneStrategy(
                maxNrOfRetries: 10,
                withinTimeRange: TimeSpan.FromSeconds(30),
                localOnlyDecider: x =>
                {
                    return Directive.Restart;
                }));
        }

        private void SetSupervisorStrategy(SupervisorStrategy strategy)
        {
            if (boss != null)
            {
                boss.GracefulStop(TimeSpan.FromSeconds(5));
            }

            var props = BossActor.Props(MinionAdded)
                        .WithSupervisorStrategy(strategy);
            boss = system.ActorOf(props, string.Format("Gru_{0}", Guid.NewGuid().ToString()));
            ClearMinionUI();
        }

        private void ClearMinionUI()
        {
            var minions = new List<Control>();
            foreach (Control item in Controls)
            {
                if (item is Minion)
                    minions.Add(item);
            }
            foreach (Control item in minions)
            {
                Controls.Remove(item);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMinionUI();
            boss.Tell(new RefreshMinionsMessage());
        }

        private void startAutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            messageTimer.Enabled = !messageTimer.Enabled;
            ((ToolStripMenuItem)sender).Text = string.Format("{0} Auto", messageTimer.Enabled ? "Stop" : "Start");
        }

        private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boss.Tell(new CrackTheWhipMessage());
        }
    }
}
