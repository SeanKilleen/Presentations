namespace Supervision
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addMinionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supervisorStrategyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allForOneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneForOneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startAutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMinionToolStripMenuItem,
            this.supervisorStrategyToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.startAutoToolStripMenuItem,
            this.sendMessageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 1034);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1249, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addMinionToolStripMenuItem
            // 
            this.addMinionToolStripMenuItem.Name = "addMinionToolStripMenuItem";
            this.addMinionToolStripMenuItem.Size = new System.Drawing.Size(118, 29);
            this.addMinionToolStripMenuItem.Text = "Add Minion";
            this.addMinionToolStripMenuItem.Click += new System.EventHandler(this.addMinionToolStripMenuItem_Click);
            // 
            // supervisorStrategyToolStripMenuItem
            // 
            this.supervisorStrategyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allForOneToolStripMenuItem,
            this.oneForOneToolStripMenuItem});
            this.supervisorStrategyToolStripMenuItem.Name = "supervisorStrategyToolStripMenuItem";
            this.supervisorStrategyToolStripMenuItem.Size = new System.Drawing.Size(179, 29);
            this.supervisorStrategyToolStripMenuItem.Text = "Supervisor Strategy";
            // 
            // allForOneToolStripMenuItem
            // 
            this.allForOneToolStripMenuItem.Name = "allForOneToolStripMenuItem";
            this.allForOneToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.allForOneToolStripMenuItem.Text = "All For One";
            this.allForOneToolStripMenuItem.Click += new System.EventHandler(this.allForOneToolStripMenuItem_Click);
            // 
            // oneForOneToolStripMenuItem
            // 
            this.oneForOneToolStripMenuItem.Checked = true;
            this.oneForOneToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.oneForOneToolStripMenuItem.Name = "oneForOneToolStripMenuItem";
            this.oneForOneToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.oneForOneToolStripMenuItem.Text = "One For One";
            this.oneForOneToolStripMenuItem.Click += new System.EventHandler(this.oneForOneToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(83, 29);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // startAutoToolStripMenuItem
            // 
            this.startAutoToolStripMenuItem.Name = "startAutoToolStripMenuItem";
            this.startAutoToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.startAutoToolStripMenuItem.Text = "Start Auto";
            this.startAutoToolStripMenuItem.Click += new System.EventHandler(this.startAutoToolStripMenuItem_Click);
            // 
            // sendMessageToolStripMenuItem
            // 
            this.sendMessageToolStripMenuItem.Name = "sendMessageToolStripMenuItem";
            this.sendMessageToolStripMenuItem.Size = new System.Drawing.Size(139, 29);
            this.sendMessageToolStripMenuItem.Text = "Send Message";
            this.sendMessageToolStripMenuItem.Click += new System.EventHandler(this.sendMessageToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 1067);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Akka.NET Supervision Demo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addMinionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supervisorStrategyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allForOneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneForOneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startAutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendMessageToolStripMenuItem;
    }
}

