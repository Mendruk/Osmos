namespace Osmos;

internal class Game
{
    public GameMode GameMode = GameMode.Reflection;
    public double TotalImpulse;
    public double TotalArea;

    public Point MousePoint;
    public bool IsPlayerJet;
    
    private Circle player;
    private List<Circle> circles;
    private Action<Graphics> drawMessageTextAction;
    private int currentReloadingTime;
    private readonly int reloadingTime = 10;
    private readonly Font font = new(FontFamily.GenericSansSerif, 80, FontStyle.Bold);
    private readonly StringFormat format = new();
    private readonly Random random = new();
    private readonly int divisionFactor = 10;
    private readonly int gameFieldWidth;
    private readonly int gameFieldHeight;

    public Game(int gameFieldWidth, int gameFieldHeight)
    {
        this.gameFieldWidth = gameFieldWidth;
        this.gameFieldHeight = gameFieldHeight;

        drawMessageTextAction = DrawEmptyText;
        StartStandartGame();

        format.Alignment = StringAlignment.Center;
    }

    public void Draw(Graphics graphics)
    {
        foreach (Circle circle in circles)
            circle.Draw(graphics);

        drawMessageTextAction?.Invoke(graphics);  
    }

    public void Update()
    {
        if (IsPlayerJet && currentReloadingTime >= reloadingTime)
        {
            PlayerJetMovement(MousePoint.X, MousePoint.Y);
            currentReloadingTime = 0;
        }

        currentReloadingTime++;

        TotalArea = 0;
        TotalImpulse = 0;

        foreach (Circle circle in circles)
        {
            circle.Update();
            TotalArea += circle.Area;
            TotalImpulse += circle.ImpulseX;
            TotalImpulse += circle.ImpulseY;
        }

        for (int i = 0; i < circles.Count; i++)
        {
            for (int j = i + 1; j < circles.Count; j++)
            {
                if (circles[i].GetDistanceToCircle(circles[j]) >= circles[i].Radius + circles[j].Radius)
                    continue;

                //distance between centers of circles
                double distance = circles[i].GetDistanceToCircle(circles[j]);

                if (circles[j].Radius <= circles[i].Radius)
                    MergeCircles(circles[j], circles[i], distance);
                else
                    MergeCircles(circles[i], circles[j], distance);
            }

            if (circles[i] == player)
            {
                if (player.Area >= TotalArea / 2)
                    drawMessageTextAction = DrawWinningText;
                else
                    drawMessageTextAction = DrawEmptyText;
                
                continue;
            }
            
            if (circles[i].Area <= player.Area)
                circles[i].brush = Brushes.Blue;
            else
                circles[i].brush = Brushes.Red;
        }
    }

    /// <summary>
    /// Merging two circles
    /// </summary>
    /// <param name="smallerCircle"> Smaller circle</param>
    /// <param name="largerCircle">Larger circle</param>
    /// <param name="distance">Distance between smaller circles and larger circles centers </param>
    private void MergeCircles(Circle smallerCircle, Circle largerCircle, double distance)
    {
        double impulseXStart = smallerCircle.ImpulseX;
        double impulseYStart = smallerCircle.ImpulseY;

        if (distance <= largerCircle.Radius)
        {
            largerCircle.AddArea(smallerCircle.Area);
            largerCircle.AddImpulse((int)impulseXStart, (int)impulseYStart);
            circles.Remove(smallerCircle);

            if (smallerCircle == player)
                drawMessageTextAction = DrawLosingText;
            return;
        }

        double b = -distance;
        double c = (Math.Pow(distance, 2) - Math.Pow(largerCircle.Radius, 2) - Math.Pow(smallerCircle.Radius, 2)) / 2;

        double newRadius = (-b - Math.Sqrt(Math.Pow(b, 2) - 4 * c)) / 2;

        smallerCircle.Radius = newRadius;
        largerCircle.Radius = distance - newRadius;

        largerCircle.AddImpulse((int)(impulseXStart - smallerCircle.ImpulseX),
            (int)(impulseYStart - smallerCircle.ImpulseY));
    }

    public void SetGameModeAllCircles(GameMode gameMode)
    {
        GameMode = gameMode;

        foreach (Circle circle in circles)
            SetGameMode(gameMode, circle);
    }

    private void SetGameMode(GameMode gameMode, Circle circle)
    {
        switch (gameMode)
        {
            case GameMode.Reflection:
                circle.BehaviorAtBorder = circle.ReflectionBehavior;
                break;
            case GameMode.Teleportation:
                circle.BehaviorAtBorder = circle.TeleportationBehavior;
                break;
        }
    }

    public void PlayerJetMovement(int mouseX, int mouseY)
    {
        double angle = Math.Atan((player.Y - mouseY) / (player.X - mouseX));

        if (player.X - mouseX >= 0)
            angle += Math.PI;

        Circle createdCircle = new((int)player.X, (int)player.Y, 0, Math.Cos(angle) * divisionFactor,
            Math.Sin(angle) * divisionFactor, gameFieldWidth, gameFieldHeight);

        createdCircle.AddArea(player.Area / divisionFactor);
        player.RemoveArea(createdCircle.Area);

        createdCircle.X += Math.Cos(angle) * (player.Radius + createdCircle.Radius);
        createdCircle.Y += Math.Sin(angle) * (player.Radius + createdCircle.Radius);
        SetGameMode(GameMode, createdCircle);

        player.AddImpulse(-(int)createdCircle.ImpulseX, -(int)createdCircle.ImpulseY);

        circles.Add(createdCircle);
    }

    public void StartStandartGame()
    {
        player = new Circle(gameFieldWidth / 2, gameFieldHeight / 2, 40, 0, 0, gameFieldWidth, gameFieldHeight)
        {
            brush = Brushes.Green
        };

        circles = new List<Circle> { player };

        for (int i = 0; i <= 20; i++)
            circles.Add(new Circle(random.Next(0, gameFieldWidth), random.Next(0, gameFieldHeight), random.Next(20, 30),
                random.Next(-1, 2), random.Next(-1, 2), gameFieldWidth, gameFieldHeight));

        SetGameModeAllCircles(GameMode);
    }

    public void StartStressGame()
    {
        player = new Circle(gameFieldWidth / 2, gameFieldHeight / 2, 5, 0, 0, gameFieldWidth, gameFieldHeight)
        {
            brush = Brushes.Green
        };
        circles = new List<Circle> { player };

        for (int i = 0; i <= 30000; i++)
            circles.Add(new Circle(random.Next(0, gameFieldWidth), random.Next(0, gameFieldHeight), random.Next(1, 2),
                random.Next(-1, 2), random.Next(-1, 2), gameFieldWidth, gameFieldHeight));

        SetGameModeAllCircles(GameMode);
    }

    public void StartCheckCollisionGame()
    {
        player = new Circle(gameFieldWidth / 3, gameFieldHeight / 2, 215, 10, 0, gameFieldWidth, gameFieldHeight)
        {
            brush = Brushes.Green
        };

        circles = new List<Circle>
        {
            player,
            new (gameFieldWidth * 2 / 3, gameFieldHeight / 2, 215, -10, 0, gameFieldWidth, gameFieldHeight)
        };

        SetGameModeAllCircles(GameMode);
    }

    private void DrawWinningText(Graphics graphics)
    {
        graphics.DrawString("Victory", font, Brushes.LawnGreen, gameFieldWidth / 2, gameFieldHeight / 2, format);
    }

    private void DrawLosingText(Graphics graphics)
    {
        graphics.DrawString("Defeat", font, Brushes.DarkRed, gameFieldWidth / 2, gameFieldHeight / 2, format);
    }

    private void DrawEmptyText(Graphics graphics)
    {
        graphics.DrawString(" ", font, Brushes.Red, gameFieldWidth / 2, gameFieldHeight / 2, format);
    }
}