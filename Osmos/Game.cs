namespace Osmos;

internal class Game
{
    public GameMode GameMode = GameMode.Reflection;
    public double TotalArea;

    private readonly Random random = new();
    private readonly PlayerCircle player;
    private readonly List<Circle> circles;

    public Game(int gameFieldWidth, int gameFieldHeight)
    {
        player = new PlayerCircle(gameFieldWidth / 2, gameFieldHeight / 2, 40, 0, 0, gameFieldWidth, gameFieldHeight);

        circles = new List<Circle> { player };

        for (int i = 0; i <= 10; i++)
            circles.Add(new Circle(random.Next(0, gameFieldWidth), random.Next(0, gameFieldHeight), random.Next(20, 30),
                random.Next(-1, 2), random.Next(-1, 2), gameFieldWidth, gameFieldHeight));
    }

    public void Draw(Graphics graphics)
    {
        TotalArea = 0;

        foreach (Circle circle in circles)
        {
            circle.Draw(graphics);
            TotalArea += circle.Area;
        }
    }

    public void Update()
    {
        for (int i = 0; i < circles.Count; i++)
        {
            circles[i].Update();

            for (int j = i + 1; j < circles.Count; j++)
            {
                if (circles[i].GetDistanceToCircle(circles[j]) >= circles[i].Radius + circles[j].Radius)
                    continue;
                double deltaRadius = circles[i].Radius + circles[j].Radius -
                                     circles[i].GetDistanceToCircle(circles[j]);

                if (circles[j].Radius < circles[i].Radius)
                    MergeCircles(circles[j], circles[i], deltaRadius);
                else
                    MergeCircles(circles[i], circles[j], deltaRadius);
            }

            //todo
            if (GameMode == GameMode.Reflection)
                circles[i].behaviorAtBorder = circles[i].ReflectionBehavior;

            if (GameMode == GameMode.Teleportation)
                circles[i].behaviorAtBorder = circles[i].TeleportationBehavior;

            if (circles[i] == player)
                continue;

            if (circles[i].Area <= player.Area)
                circles[i].brush = Brushes.Blue;
            else
                circles[i].brush = Brushes.Red;
        }
    }

    private void MergeCircles(Circle smallerCircle, Circle largerCircle, double deltaRadius)
    {
        double areaStart = smallerCircle.Area;
        double impulseXStart = smallerCircle.ImpulseX;
        double impulseYStart = smallerCircle.ImpulseY;

        smallerCircle.RemoveRadius(deltaRadius);

        if (smallerCircle.Radius <= 0)
        {
            largerCircle.AddArea(areaStart);
            largerCircle.AddImpulse((int)impulseXStart, (int)impulseYStart);
            circles.Remove(smallerCircle);
            return;
        }

        double deltaArea = areaStart - smallerCircle.Area;

        largerCircle.AddArea(deltaArea);
        largerCircle.AddImpulse((int)(impulseXStart - smallerCircle.ImpulseX),
            (int)(impulseYStart - smallerCircle.ImpulseY));
    }

    public void PlayerShot(int mouseX, int mouseY)
    {
        player.CreateCircle(mouseX, mouseY, circles);
    }
}