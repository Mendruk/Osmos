namespace Osmos
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.reflectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teleportationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameModeLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TotalAreaLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureGameField = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGameField)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 25;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.GameModeLabel,
            this.toolStripSeparator1,
            this.TotalAreaLabel,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1180, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripDropDownButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reflectionToolStripMenuItem,
            this.teleportationToolStripMenuItem});
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.Black;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(85, 22);
            this.toolStripDropDownButton1.Text = "Game mode";
            // 
            // reflectionToolStripMenuItem
            // 
            this.reflectionToolStripMenuItem.Name = "reflectionToolStripMenuItem";
            this.reflectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reflectionToolStripMenuItem.Text = "Reflection";
            this.reflectionToolStripMenuItem.Click += new System.EventHandler(this.reflectionToolStripMenuItem_Click);
            // 
            // teleportationToolStripMenuItem
            // 
            this.teleportationToolStripMenuItem.Name = "teleportationToolStripMenuItem";
            this.teleportationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.teleportationToolStripMenuItem.Text = "Teleportation";
            this.teleportationToolStripMenuItem.Click += new System.EventHandler(this.teleportationToolStripMenuItem_Click);
            // 
            // GameModeLabel
            // 
            this.GameModeLabel.ForeColor = System.Drawing.Color.Black;
            this.GameModeLabel.Name = "GameModeLabel";
            this.GameModeLabel.Size = new System.Drawing.Size(60, 22);
            this.GameModeLabel.Text = "Reflection";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TotalAreaLabel
            // 
            this.TotalAreaLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalAreaLabel.ForeColor = System.Drawing.Color.Black;
            this.TotalAreaLabel.Name = "TotalAreaLabel";
            this.TotalAreaLabel.Size = new System.Drawing.Size(102, 22);
            this.TotalAreaLabel.Text = "Total area 0000000";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // pictureGameField
            // 
            this.pictureGameField.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureGameField.Location = new System.Drawing.Point(0, 20);
            this.pictureGameField.Name = "pictureGameField";
            this.pictureGameField.Size = new System.Drawing.Size(1183, 696);
            this.pictureGameField.TabIndex = 1;
            this.pictureGameField.TabStop = false;
            this.pictureGameField.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureGameField_Paint);
            this.pictureGameField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureGameField_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1180, 717);
            this.Controls.Add(this.pictureGameField);
            this.Controls.Add(this.toolStrip1);
            this.ForeColor = System.Drawing.Color.Lavender;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Osmos";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem reflectionToolStripMenuItem;
        private ToolStripMenuItem teleportationToolStripMenuItem;
        private PictureBox pictureGameField;
        private ToolStripLabel GameModeLabel;
        private ToolStripLabel TotalAreaLabel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
    }
}