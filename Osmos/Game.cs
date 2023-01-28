namespace Osmos
{
    internal class Game
    {
        private readonly Random random = new();
        private readonly Font font = new(FontFamily.GenericSansSerif, 20, FontStyle.Bold);

        private List<Circle> circles;

        public Game(int gameFieldWidth, int gameFieldHeight)
        {
            circles = new();
            for (int i = 0; i <= 300; i++)
            {
                circles.Add(new Circle(random.Next(0,gameFieldWidth),random.Next(0,gameFieldHeight),
                    random.Next(5,15),gameFieldWidth,gameFieldHeight));
            }
        }

        public void Draw(Graphics graphics)
        {
            double area = 0;
            double impulseX = 0;
            double impulseY = 0;

            foreach (Circle circle in circles)
            {
                circle.Draw(graphics);
                area += circle.area;
                impulseX += Math.Abs(circle.ImpulseX);
                impulseY += Math.Abs(circle.ImpulseY);
            }

            graphics.DrawString(area.ToString(), font, Brushes.Black, 50, 50);
            graphics.DrawString(impulseX.ToString(), font, Brushes.Black, 50, 100);
            graphics.DrawString(impulseY.ToString(), font, Brushes.Black, 50, 150);
        }

        public void Update()
        {
            for (int i = 0; i < circles.Count; i++)
                for (int j = i + 1; j < circles.Count; j++)
                    ConnectCircles(circles[i], circles[j]);
            
            foreach (Circle circle in circles)
                circle.Update(circles);
        }

        private void ConnectCircles(Circle circle1, Circle circle2)
        {
            double distance = Math.Sqrt(Math.Pow(circle1.X - circle2.X, 2) + Math.Pow(circle1.Y - circle2.Y, 2));

            if (distance < circle1.radius + circle2.radius)
            {
                double deltaRadius = circle1.radius + circle2.radius - distance;

                if (circle1.radius > circle2.radius)
                    ConfluenceOfCircles(circle1, circle2, deltaRadius);
                else
                    ConfluenceOfCircles(circle2, circle1, deltaRadius);
            }
        }

        private void ConfluenceOfCircles(Circle larger, Circle smaller, double deltaRadius)
        {
            double impulseXStart = smaller.ImpulseX;
            double impulseYStart = smaller.ImpulseY;

            double radiusStart = smaller.radius;

            smaller.RemoveRadius(deltaRadius);

            if ((int)smaller.radius <= 0)
            {
                circles.Remove(smaller);
                larger.AddRadius(radiusStart);
                larger.AddImpulse((int)(impulseXStart), (int)(impulseYStart));
                return;
            }

            larger.AddImpulse((int)(impulseXStart - smaller.ImpulseX), (int)(impulseYStart - smaller.ImpulseY));

            larger.AddRadius(deltaRadius);


        }
    }
}