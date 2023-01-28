using System.Drawing.Drawing2D;

namespace Osmos
{
    public partial class MainForm : Form
    {
        private Game game;
        public MainForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.DoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);

            game = new Game(Width,Height);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Refresh();
            game.Update();
            Refresh();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            game.Draw(e.Graphics);
        }
    }
}