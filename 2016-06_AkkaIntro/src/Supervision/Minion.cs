using System;
using System.Windows.Forms;

using Akka.Actor;

namespace Supervision
{
    public partial class Minion : UserControl
    {
        IActorRef _minion;
        IActorRef _updater;

        public Minion(IActorRef minion, ActorSystem system)
        {
            InitializeComponent();

            _minion = minion;
            lblName.Text = "Hi, my name is "+ _minion.Path.Name;

            _updater = system.ActorOf(UiUpdateActor.Props(RefreshUI));
        }

        public async void RefreshUI()
        {
            var x = await _minion.Ask(new UpdateRequestMessage(_updater));
        }

        public void RefreshUI(Tuple<string, int, string> update)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                lblReference.Text = update.Item1;
                lblMessageCount.Text = update.Item2.ToString();
                lblID.Text = update.Item3;
            }));
        }

        private void distractedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _minion.Tell(new HungryMessage());
        }

        private void evilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _minion.Tell(new EvilMessage());
        }
    }
}
