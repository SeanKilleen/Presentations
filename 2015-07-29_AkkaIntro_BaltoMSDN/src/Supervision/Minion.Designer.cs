namespace Supervision
{
    partial class Minion
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblReference = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMessageCount = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.distractedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblID = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Location = new System.Drawing.Point(3, 71);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(77, 20);
            this.lblReference.TabIndex = 0;
            this.lblReference.Text = "reference";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(3, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "name";
            // 
            // lblMessageCount
            // 
            this.lblMessageCount.AutoSize = true;
            this.lblMessageCount.Location = new System.Drawing.Point(3, 41);
            this.lblMessageCount.Name = "lblMessageCount";
            this.lblMessageCount.Size = new System.Drawing.Size(49, 20);
            this.lblMessageCount.TabIndex = 2;
            this.lblMessageCount.Text = "count";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.distractedToolStripMenuItem,
            this.evilToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 64);
            // 
            // distractedToolStripMenuItem
            // 
            this.distractedToolStripMenuItem.Name = "distractedToolStripMenuItem";
            this.distractedToolStripMenuItem.Size = new System.Drawing.Size(156, 30);
            this.distractedToolStripMenuItem.Text = "Hungry";
            this.distractedToolStripMenuItem.Click += new System.EventHandler(this.distractedToolStripMenuItem_Click);
            // 
            // evilToolStripMenuItem
            // 
            this.evilToolStripMenuItem.Name = "evilToolStripMenuItem";
            this.evilToolStripMenuItem.Size = new System.Drawing.Size(156, 30);
            this.evilToolStripMenuItem.Text = "Evil";
            this.evilToolStripMenuItem.Click += new System.EventHandler(this.evilToolStripMenuItem_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(210, 41);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(26, 20);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "ID";
            // 
            // Minion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblMessageCount);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblReference);
            this.Name = "Minion";
            this.Size = new System.Drawing.Size(983, 184);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMessageCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem distractedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evilToolStripMenuItem;
        private System.Windows.Forms.Label lblID;
    }
}
