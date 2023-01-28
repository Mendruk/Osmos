namespace Osmos
{
    internal class Circle
    {
        static Random random = new Random();

        private readonly Font font = new(FontFamily.GenericSansSerif, 20, FontStyle.Bold);
        private Brush brush = Brushes.Green;

        public double X;
        public double Y;
        public double radius;
        public double velocityX;
        public double velocityY;

        private int gameFiledWidth;
        private int gameFiledHeight;

        public double area => Math.PI * Math.Pow(radius, 2);
        public double ImpulseX => velocityX * area;
        public double ImpulseY => velocityY * area;

        public Circle(int x, int y, int radius, int gameFieldWidth, int gameFieldHeight)
        {
            this.gameFiledHeight = gameFieldHeight;
            this.gameFiledWidth = gameFieldWidth;
            X = x;
            Y = y;
            this.radius = radius;
            velocityX = random.Next(-1, 2);
            velocityY = random.Next(-1, 2);
        }

        public void Draw(Graphics graphics)
        {
            graphics.FillEllipse(brush, (int)X - (int)radius, (int)Y - (int)radius, (int)radius * 2, (int)radius * 2);
            graphics.DrawEllipse(Pens.Black, (int)X - (int)radius, (int)Y - (int)radius, (int)radius * 2,
                (int)radius * 2);
            //graphics.DrawString(area.ToString(), font, Brushes.Black, (int)X, (int)Y);
        }

        public void Update(List<Circle> circles)
        {
            X += velocityX;
            Y += velocityY;

            if (X - radius < 0 || X + radius >= gameFiledWidth)
            {
                velocityX = -velocityX;
            }

            if (Y - radius < 0 || Y + radius >= gameFiledHeight)
            {
                velocityY = -velocityY;
            }
        }

        public void AddRadius(double deltaRadius)
        {
            radius = Math.Sqrt(Math.Pow(radius, 2) + Math.Pow(deltaRadius, 2));
        }

        public void RemoveRadius(double deltaRadius)
        {
            radius = Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(deltaRadius, 2));
        }

        public void AddImpulse(int impulseX, int impulseY)
        {
            velocityX = (ImpulseX + impulseX) / area;
            velocityY = (ImpulseY + impulseY) / area;
        }
    }
}