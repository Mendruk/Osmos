using System.Drawing.Drawing2D;

namespace Osmos;

public partial class MainForm : Form
{
    private readonly Game game;

    public MainForm()
    {
        InitializeComponent();

        SetStyle(ControlStyles.DoubleBuffer |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint, true);

        game = new Game(pictureGameField.Width, pictureGameField.Height);
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        game.Update();
        totalAreaLabel.Text = "Total area: " + (int)game.TotalArea;
        totalImpulseLabel.Text = "Total Impulse " + (int)game.TotalImpulse;
        Refresh();
    }

    private void reflectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        game.SetGameModeAllCircles(GameMode.Reflection);
        GameModeLabel.Text = GameMode.Reflection.ToString();
    }

    private void teleportationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        game.SetGameModeAllCircles(GameMode.Teleportation);
        GameModeLabel.Text = GameMode.Teleportation.ToString();
    }

    private void pictureGameField_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        game.Draw(e.Graphics);
    }

    private void standardToolStripMenuItem_Click(object sender, EventArgs e)
    {
        game.StartStandartGame();
        timer.Interval = 20;
    }

    private void stressToolStripMenuItem_Click(object sender, EventArgs e)
    {
        game.StartStressGame();
        timer.Interval = 20;
    }

    private void collisionCheckToolStripMenuItem_Click(object sender, EventArgs e)
    {
        game.StartCheckCollisionGame();
        timer.Interval = 1000;
    }

    private void pictureGameField_MouseDown(object sender, MouseEventArgs e)
    {
        game.IsPlayerJet = true;
    }

    private void pictureGameField_MouseUp(object sender, MouseEventArgs e)
    {
        game.IsPlayerJet = false;
    }

    private void pictureGameField_MouseMove(object sender, MouseEventArgs e)
    {
        game.MousePoint.X = e.X;
        game.MousePoint.Y = e.Y;
    }
}