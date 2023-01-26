namespace Osmos
{
    internal class Game
    {
        private List<Circle> circles = new List<Circle>() { new Circle(300, 200, 50, 2, 0), new Circle(500, 200, 40, 1, 180) };

        public void Draw(Graphics graphics)
        {
            foreach (Circle circle in circles)
                circle.Draw(graphics);
        }

        public void Update()
        {
            foreach(Circle circle in circles)
                circle.Update(circles);
        }
    }
}
