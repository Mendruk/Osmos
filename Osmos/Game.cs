using System;

namespace Osmos
{
    internal class Game
    {
        private readonly Random random = new();
        private readonly Font font = new(FontFamily.GenericSansSerif, 20, FontStyle.Bold);

        private readonly List<Circle> circles;

        public Game(int gameFieldWidth, int gameFieldHeight)
        {
            circles = new();
            for (int i = 0; i <= 1000; i++)
            {
                circles.Add(new Circle(random.Next(0, gameFieldWidth), random.Next(0, gameFieldHeight), random.Next(1, 10), 
                    random.Next(-2, 3), random.Next(-2, 3), gameFieldWidth, gameFieldHeight));
            }
        }

        public void Draw(Graphics graphics)
        {
            double totalArea = 0;

            foreach (Circle circle in circles)
            {
                circle.Draw(graphics);
                totalArea += circle.Area;
            }

            graphics.DrawString("Total area: "+(int)totalArea, font, Brushes.Black, 50, 50);

        }

        public void Update()
        {
            List<Circle> circlesToDelete = new();

            foreach (Circle circle in circles)
                circle.Update(circles,circlesToDelete);

            foreach (Circle circle in circlesToDelete)
            {
                circles.Remove(circle);
            }
        }
    }
}