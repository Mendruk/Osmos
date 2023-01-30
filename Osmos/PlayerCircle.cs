namespace Osmos;

internal class PlayerCircle : Circle
{
    private readonly int divisionFactor = 10;

    public PlayerCircle(int x, int y, int radius, double velocityX, double velocityY, int gameFieldWidth,
        int gameFieldHeight) : base(x, y, radius, velocityX, velocityY, gameFieldWidth, gameFieldHeight)
    {
        brush = Brushes.LawnGreen;
    }

    public void CreateCircle(int mouseX, int mouseY, List<Circle> circles)
    {
        double angle = Math.Atan((Y - mouseY) / (X - mouseX));

        if (X - mouseX >= 0)
            angle += Math.PI;

        Circle createdCircle = new((int)X, (int)Y, 0, Math.Cos(angle) * divisionFactor,
            Math.Sin(angle) * divisionFactor, gameFiledWidth,
            gameFiledHeight);

        createdCircle.AddArea(Area / divisionFactor);
        RemoveArea(createdCircle.Area);

        createdCircle.X += Math.Cos(angle) * (1.5*Radius + createdCircle.Radius);
        createdCircle.Y += Math.Sin(angle) * (1.5*Radius + createdCircle.Radius);

        AddImpulse(-(int)createdCircle.ImpulseX, -(int)createdCircle.ImpulseY);

        circles.Add(createdCircle);
    }
}