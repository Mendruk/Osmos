namespace Osmos
{
    internal class Circle
    {
        public int X;
        public int Y;

        // area = Pi * radius^2
        private double radius;
        private double area;

        private double speed;
        private double angle;

        private Brush brush = Brushes.Green;

        public Circle(int x, int y, int radius, int speed, int angle)
        {
            this.X = x;
            this.Y = y;
            this.radius = radius;
            this.speed = speed;
            this.angle = angle;
        }

        public void Draw(Graphics graphics)
        {
            graphics.FillEllipse(brush, X, Y, (int)radius * 2, (int)radius * 2);
        }

        public void Update(List<Circle>circles)
        {
            X += (int)(speed * Math.Cos((angle)* Math.PI / 180));
            Y += (int)(speed * Math.Sin((angle) * Math.PI / 180));

            foreach (Circle circle in circles)
            {
                if (circle == this)
                    continue;

                int distance= GetDistanceToCircle(circle);

                if (distance<circle.radius+radius)
                {
                    int deltaRadius = distance - (int)(radius + circle.radius);

                    if (circle.radius > radius)
                    {
                        circle.radius += deltaRadius;
                        radius -= deltaRadius;
                    }
                    else
                    {
                        radius += deltaRadius;
                        circle.radius -= deltaRadius;
                    }
                }
            }

        }

        public int GetDistanceToCircle(Circle circle)
        {
            return (int)Math.Sqrt(Math.Pow(X - circle.X, 2) +
                              Math.Pow(Y - circle.Y, 2));
        }

    }
}
