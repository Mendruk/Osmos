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
            this.totalAreaLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.totalImpulseLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.standartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collisionCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureGameField = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGameField)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.GameModeLabel,
            this.toolStripSeparator1,
            this.totalAreaLabel,
            this.toolStripSeparator2,
            this.totalImpulseLabel,
            this.toolStripSeparator3,
            this.toolStripDropDownButton2,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1349, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripDropDownButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reflectionToolStripMenuItem,
            this.teleportationToolStripMenuItem});
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.Black;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(105, 24);
            this.toolStripDropDownButton1.Text = "Game mode";
            // 
            // reflectionToolStripMenuItem
            // 
            this.reflectionToolStripMenuItem.Name = "reflectionToolStripMenuItem";
            this.reflectionToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.reflectionToolStripMenuItem.Text = "Reflection";
            this.reflectionToolStripMenuItem.Click += new System.EventHandler(this.reflectionToolStripMenuItem_Click);
            // 
            // teleportationToolStripMenuItem
            // 
            this.teleportationToolStripMenuItem.Name = "teleportationToolStripMenuItem";
            this.teleportationToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.teleportationToolStripMenuItem.Text = "Teleportation";
            this.teleportationToolStripMenuItem.Click += new System.EventHandler(this.teleportationToolStripMenuItem_Click);
            // 
            // GameModeLabel
            // 
            this.GameModeLabel.ForeColor = System.Drawing.Color.Black;
            this.GameModeLabel.Name = "GameModeLabel";
            this.GameModeLabel.Size = new System.Drawing.Size(76, 24);
            this.GameModeLabel.Text = "Reflection";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // totalAreaLabel
            // 
            this.totalAreaLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.totalAreaLabel.ForeColor = System.Drawing.Color.Black;
            this.totalAreaLabel.Name = "totalAreaLabel";
            this.totalAreaLabel.Size = new System.Drawing.Size(135, 24);
            this.totalAreaLabel.Text = "Total area 0000000";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // totalImpulseLabel
            // 
            this.totalImpulseLabel.BackColor = System.Drawing.SystemColors.Control;
            this.totalImpulseLabel.ForeColor = System.Drawing.Color.Black;
            this.totalImpulseLabel.Name = "totalImpulseLabel";
            this.totalImpulseLabel.Size = new System.Drawing.Size(153, 24);
            this.totalImpulseLabel.Text = "Total Impulse: 000000";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standartToolStripMenuItem,
            this.stressToolStripMenuItem,
            this.collisionCheckToolStripMenuItem});
            this.toolStripDropDownButton2.ForeColor = System.Drawing.Color.Black;
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(95, 24);
            this.toolStripDropDownButton2.Text = "Game case";
            // 
            // standartToolStripMenuItem
            // 
            this.standartToolStripMenuItem.Name = "standartToolStripMenuItem";
            this.standartToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.standartToolStripMenuItem.Text = "Standart";
            this.standartToolStripMenuItem.Click += new System.EventHandler(this.standartToolStripMenuItem_Click);
            // 
            // stressToolStripMenuItem
            // 
            this.stressToolStripMenuItem.Name = "stressToolStripMenuItem";
            this.stressToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.stressToolStripMenuItem.Text = "Stress";
            this.stressToolStripMenuItem.Click += new System.EventHandler(this.stressToolStripMenuItem_Click);
            // 
            // collisionCheckToolStripMenuItem
            // 
            this.collisionCheckToolStripMenuItem.Name = "collisionCheckToolStripMenuItem";
            this.collisionCheckToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.collisionCheckToolStripMenuItem.Text = "Collision check";
            this.collisionCheckToolStripMenuItem.Click += new System.EventHandler(this.collisionCheckToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // pictureGameField
            // 
            this.pictureGameField.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureGameField.Location = new System.Drawing.Point(0, 31);
            this.pictureGameField.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureGameField.Name = "pictureGameField";
            this.pictureGameField.Size = new System.Drawing.Size(1352, 928);
            this.pictureGameField.TabIndex = 1;
            this.pictureGameField.TabStop = false;
            this.pictureGameField.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureGameField_Paint);
            this.pictureGameField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureGameField_MouseDown);
            this.pictureGameField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureGameField_MouseMove);
            this.pictureGameField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureGameField_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1349, 956);
            this.Controls.Add(this.pictureGameField);
            this.Controls.Add(this.toolStrip1);
            this.ForeColor = System.Drawing.Color.Lavender;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
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
        private ToolStripLabel totalAreaLabel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel totalImpulseLabel;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem standartToolStripMenuItem;
        private ToolStripMenuItem stressToolStripMenuItem;
        private ToolStripMenuItem collisionCheckToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
    }
}