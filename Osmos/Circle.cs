namespace Osmos;

internal class Circle
{
    private readonly Font font = new(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
    private readonly Brush brush = Brushes.Green;

    private readonly int gameFiledWidth;
    private readonly int gameFiledHeight;

    public double X;
    public double Y;
    public double Radius;
    public double VelocityX;
    public double VelocityY;

    public double Area => Math.PI * Math.Pow(Radius, 2);
    public double ImpulseX => VelocityX * Area;
    public double ImpulseY => VelocityY * Area;

    public Circle(int x, int y, int radius, double velocityX, double velocityY, int gameFieldWidth,
        int gameFieldHeight)
    {
        gameFiledHeight = gameFieldHeight;
        gameFiledWidth = gameFieldWidth;
        X = x;
        Y = y;
        Radius = radius;
        VelocityX = velocityX;
        VelocityY = velocityY;
    }

    public void Draw(Graphics graphics)
    {
        graphics.FillEllipse(brush, (int)X - (int)Radius, (int)Y - (int)Radius, (int)Radius * 2, (int)Radius * 2);
        graphics.DrawEllipse(Pens.Black, (int)X - (int)Radius, (int)Y - (int)Radius, (int)Radius * 2,
            (int)Radius * 2);
        graphics.DrawString(((int)Area).ToString(), font, Brushes.Black, (int)X, (int)Y);
    }

    public void Update(List<Circle> circles, List<Circle> circlesToDelete)
    {
        X += VelocityX;
        Y += VelocityY;

        if (X - Radius < 0 || X + Radius >= gameFiledWidth)
            VelocityX = -VelocityX;

        if (Y - Radius < 0 || Y + Radius >= gameFiledHeight)
            VelocityY = -VelocityY;

        foreach (Circle circle in circles)
        {
            if (circle == this)
                continue;

            if (GetDistanceToCircle(circle) >= Radius + circle.Radius)
                continue;
            double deltaRadius = Radius + circle.Radius - GetDistanceToCircle(circle);

            if (circle.Radius < Radius)
                MergeCircles(circle, this, deltaRadius, circlesToDelete);
            else
                MergeCircles(this, circle, deltaRadius, circlesToDelete);
        }

        if (X - Radius < 0)
            X = Radius;

        if (Y - Radius < 0)
            Y = Radius;

        if (X + Radius >= gameFiledWidth)
            X = gameFiledWidth - Radius;

        if (Y + Radius >= gameFiledHeight)
            Y = gameFiledHeight - Radius;
    }

    public void AddArea(double deltaArea)
    {
        Radius = Math.Sqrt(Math.Pow(Radius, 2) + deltaArea / Math.PI);
    }

    public void RemoveRadius(double deltaRadius)
    {
        Radius -= deltaRadius;
    }

    public void AddImpulse(int impulseX, int impulseY)
    {
        VelocityX = (ImpulseX + impulseX) / Area;
        VelocityY = (ImpulseY + impulseY) / Area;
    }

    public double GetDistanceToCircle(Circle circle)
    {
        return Math.Sqrt(Math.Pow(X - circle.X, 2) + Math.Pow(Y - circle.Y, 2));
    }

    private void MergeCircles(Circle smallerCircle, Circle largerCircle, double deltaRadius,
        List<Circle> circlesToDelete)
    {
        double areaStart = smallerCircle.Area;
        double impulseXStart = smallerCircle.ImpulseX;
        double impulseYStart = smallerCircle.ImpulseY;

        smallerCircle.RemoveRadius(deltaRadius);

        if (smallerCircle.Radius <= 0)
        {
            largerCircle.AddArea(areaStart);
            largerCircle.AddImpulse((int)impulseXStart, (int)impulseYStart);
            circlesToDelete.Add(smallerCircle);

            return;
        }

        double deltaArea = areaStart - smallerCircle.Area;

        largerCircle.AddArea(deltaArea);
        largerCircle.AddImpulse((int)(impulseXStart - smallerCircle.ImpulseX),
            (int)(impulseYStart - smallerCircle.ImpulseY));
    }
}