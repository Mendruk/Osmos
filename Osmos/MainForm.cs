namespace Osmos
{
    public partial class MainForm : Form
    {
        private Game game;
        public MainForm()
        {
            InitializeComponent();
            game = new Game();
        }
    }
}