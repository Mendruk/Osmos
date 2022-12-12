namespace Osmos
{
    internal class Game
    {
        private Circle circle = new Circle();

        public void Draw(Graphics graphics)
        {
            circle.Draw(graphics);
        }

        public void Update()
        {
            circle.Update();
        }
    }
}
