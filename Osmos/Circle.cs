namespace Osmos
{
    internal class Circle
    {
        private int x;
        private int y;

        // area = Pi * radius^2
        private double radius;
        private double area;

        private double speed;
        private double angle;

        private Brush brush = Brushes.Green;

        public Circle()
        {
            x = 100;
            y = 200;
            radius = 150;
            speed = 100;
            angle = 100;
        }

        public void Draw(Graphics graphics)
        {
            graphics.FillEllipse(brush, x, y, (int)radius * 2, (int)radius * 2);
        }

        public void Update()
        {
            x += (int)(speed * Math.Sin(angle)* Math.PI / 180);
            y += (int)(speed * Math.Cos(angle) * Math.PI / 180);
        }
    }
}
