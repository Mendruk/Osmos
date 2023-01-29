
namespace Osmos
{
    internal class PlayerCircle:Circle
    {
        //todo rename
        private int Num = 10;
        public PlayerCircle(int x, int y, int radius, double velocityX, double velocityY, int gameFieldWidth, int gameFieldHeight) : base(x, y, radius, velocityX, velocityY, gameFieldWidth, gameFieldHeight)
        {
            brush = Brushes.Green;
        }

        public void CreateCircle(int mouseX, int mouseY, List<Circle>circles)
        {
            double Angle = Math.Atan((Y - mouseY) / (X - mouseX));

            if (X - mouseX >= 0)
                Angle += Math.PI;

            Circle createdCircle = new((int)X, (int)Y, 1, Math.Cos(Angle)*Num, Math.Sin(Angle) * Num, gameFiledWidth,
                gameFiledHeight);

            createdCircle.AddArea(Area / Num);
            RemoveArea(createdCircle.Area);

            createdCircle.X += Math.Cos(Angle) * (Radius + createdCircle.Radius);
            createdCircle.Y += Math.Sin(Angle) * (Radius + createdCircle.Radius);

            AddImpulse(-(int)createdCircle.ImpulseX, -(int)createdCircle.ImpulseY);

            circles.Add(createdCircle);
        }
    }
}
