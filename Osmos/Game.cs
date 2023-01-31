namespace Osmos;

internal class Game
{
    public GameMode GameMode = GameMode.Reflection;
    public double TotalArea;
    public double TotalImpulse;

    private readonly Random random = new();
    private List<Circle> circles;
    private Circle player;
    private readonly int divisionFactor = 10;

    private readonly int gameFieldWidth;
    private readonly int gameFieldHeight;

    public Game(int gameFieldWidth, int gameFieldHeight)
    {
        this.gameFieldWidth = gameFieldWidth;
        this.gameFieldHeight = gameFieldHeight;

        StartStandartGame();
    }

    public void Draw(Graphics graphics)
    {
        TotalArea = 0;
        TotalImpulse = 0;

        foreach (Circle circle in circles)
        {
            circle.Draw(graphics);
            TotalArea += circle.Area;
            TotalImpulse += Math.Abs(circle.ImpulseX);
            TotalImpulse+=Math.Abs(circle.ImpulseY);
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

    public void SetGameMode(GameMode gameMode)
    {
        GameMode = gameMode;

        foreach (Circle circle in circles)
            switch (gameMode)
            {
                case GameMode.Reflection:
                    circle.behaviorAtBorder = circle.ReflectionBehavior;
                    break;
                case GameMode.Teleportation:
                    circle.behaviorAtBorder = circle.TeleportationBehavior;
                    break;
                default://todo
                    break;
            }
        
    }

    public void PlayerShot(int mouseX, int mouseY)
    {
        PlayerJetMovement(mouseX, mouseY);
    }

    public void PlayerJetMovement(int mouseX, int mouseY)
    {
        double angle = Math.Atan((player.Y - mouseY) / (player.X - mouseX));

        if (player.X - mouseX >= 0)
            angle += Math.PI;

        Circle createdCircle = new((int)player.X, (int)player.Y, 0, Math.Cos(angle) * divisionFactor,
            Math.Sin(angle) * divisionFactor, gameFieldWidth,gameFieldHeight);

        createdCircle.AddArea(player.Area / divisionFactor);
        player.RemoveArea(createdCircle.Area);

        createdCircle.X += Math.Cos(angle) * (player.Radius + createdCircle.Radius);
        createdCircle.Y += Math.Sin(angle) * (player.Radius + createdCircle.Radius);

        player.AddImpulse(-(int)createdCircle.ImpulseX, -(int)createdCircle.ImpulseY);

        circles.Add(createdCircle);
    }

    public void StartStandartGame()
    {

        player = new Circle(gameFieldWidth / 2, gameFieldHeight / 2, 40, 0, 0, gameFieldWidth, gameFieldHeight);
        player.brush = Brushes.Green;
        circles = new List<Circle> { player };

        for (int i = 0; i <= 20; i++)
            circles.Add(new Circle(random.Next(0, gameFieldWidth), random.Next(0, gameFieldHeight), random.Next(20, 30),
                random.Next(-1, 2), random.Next(-1, 2), gameFieldWidth, gameFieldHeight));
    }

    public void StartStressGame()
    {
        player = new Circle(gameFieldWidth / 2, gameFieldHeight / 2, 2, 0, 0, gameFieldWidth, gameFieldHeight);
        player.brush = Brushes.Green;
        circles = new List<Circle> { player };

        for (int i = 0; i <= 30000; i++)
            circles.Add(new Circle(random.Next(0, gameFieldWidth), random.Next(0, gameFieldHeight), random.Next(1, 2),
                random.Next(-1, 2), random.Next(-1, 2), gameFieldWidth, gameFieldHeight));
    }

    public void StartCheckCollisionGame()
    {
        player = new Circle(gameFieldWidth /3, gameFieldHeight / 2, 220, 10, 0, gameFieldWidth, gameFieldHeight);
        player.brush = Brushes.Green;
        circles = new List<Circle> { player };

        circles.Add(new Circle(gameFieldWidth * 2 / 3, gameFieldHeight / 2, 215, -1, 0, gameFieldWidth, gameFieldHeight));

    }

}
