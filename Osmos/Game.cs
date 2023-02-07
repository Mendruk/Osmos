namespace Osmos;

internal class Game
{
    public GameMode GameMode = GameMode.Reflection;
    public double TotalImpulse;
    public double TotalArea;

    public Point MousePoint;
    public bool IsPlayerJet;

    private GameState gameState;
    private Circle player;
    private List<Circle> circles;
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

        StartStandardGame();

        format.Alignment = StringAlignment.Center;
    }

    public void Draw(Graphics graphics)
    {
        foreach (Circle circle in circles)
        {
            if (circle == player)
            {
                circle.Draw(graphics, Brushes.Green);
                continue;
            }

            if (circle.Area <= player.Area)
                circle.Draw(graphics, Brushes.Blue);
            else
                circle.Draw(graphics, Brushes.Red);
        }

        switch (gameState)
        {
            case GameState.Play:
                break;
            case GameState.Victory:
                graphics.DrawString("Victory", font, Brushes.LawnGreen, gameFieldWidth / 2, gameFieldHeight / 2,
                    format);
                break;
            case GameState.Defeat:
                graphics.DrawString("Defeat", font, Brushes.DarkRed, gameFieldWidth / 2, gameFieldHeight / 2, format);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
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
            circle.Update(GameMode);
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
                    gameState = GameState.Victory;
                else
                    gameState = GameState.Play;
            }
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
        double areaSmallerCircleStart = smallerCircle.Area;
        double areaLargerCircleStart = largerCircle.Area;

        if (distance <= largerCircle.Radius)
        {
            largerCircle.AddArea(smallerCircle.Area);
            largerCircle.VelocityX = (areaLargerCircleStart * largerCircle.VelocityX +
                                      smallerCircle.Area * smallerCircle.VelocityX) /
                                     largerCircle.Area;
            largerCircle.VelocityY = (areaLargerCircleStart * largerCircle.VelocityY +
                                      smallerCircle.Area * smallerCircle.VelocityY) /
                                     largerCircle.Area;
            circles.Remove(smallerCircle);

            if (smallerCircle == player)
                gameState = GameState.Defeat;
            return;
        }

        double b = -distance;
        double c = (Math.Pow(distance, 2) - Math.Pow(largerCircle.Radius, 2) - Math.Pow(smallerCircle.Radius, 2)) / 2;

        double newRadius = (-b - Math.Sqrt(Math.Pow(b, 2) - 4 * c)) / 2;

        smallerCircle.Radius = newRadius;
        largerCircle.Radius = distance - newRadius;

        largerCircle.VelocityX = (areaLargerCircleStart * largerCircle.VelocityX +
                                  (areaSmallerCircleStart - smallerCircle.Area) * smallerCircle.VelocityX) /
                                 largerCircle.Area;
        largerCircle.VelocityY = (areaLargerCircleStart * largerCircle.VelocityY +
                                  (areaSmallerCircleStart - smallerCircle.Area) * smallerCircle.VelocityY) /
                                 largerCircle.Area;
    }


    public void PlayerJetMovement(int mouseX, int mouseY)
    {
        if (gameState == GameState.Defeat)
            return;

        double angle = Math.Atan((player.Y - mouseY) / (player.X - mouseX));

        if (player.X - mouseX >= 0)
            angle += Math.PI;

        Circle createdCircle = new((int)player.X, (int)player.Y, 0, Math.Cos(angle) * divisionFactor,
            Math.Sin(angle) * divisionFactor, gameFieldWidth, gameFieldHeight);

        createdCircle.AddArea(player.Area / divisionFactor);

        double playerStartArea = player.Area;
        player.RemoveArea(createdCircle.Area);

        createdCircle.X += Math.Cos(angle) * (player.Radius + createdCircle.Radius);
        createdCircle.Y += Math.Sin(angle) * (player.Radius + createdCircle.Radius);

        player.VelocityX = (playerStartArea * player.VelocityX - createdCircle.Area * createdCircle.VelocityX) /
                           player.Area;
        player.VelocityY = (playerStartArea * player.VelocityY - createdCircle.Area * createdCircle.VelocityY) /
                           player.Area;

        circles.Add(createdCircle);
    }

    public void StartStandardGame()
    {
        player = new Circle(gameFieldWidth / 2, gameFieldHeight / 2, 40, 0, 0, gameFieldWidth, gameFieldHeight);
        circles = new List<Circle> { player };

        for (int i = 0; i <= 20; i++)
            circles.Add(new Circle(random.Next(0, gameFieldWidth), random.Next(0, gameFieldHeight), random.Next(20, 30),
                random.Next(-1, 2), random.Next(-1, 2), gameFieldWidth, gameFieldHeight));

        gameState = GameState.Play;
    }

    public void StartStressGame()
    {
        player = new Circle(gameFieldWidth / 2, gameFieldHeight / 2, 5, 0, 0, gameFieldWidth, gameFieldHeight);
        circles = new List<Circle> { player };

        for (int i = 0; i <= 30000; i++)
            circles.Add(new Circle(random.Next(0, gameFieldWidth), random.Next(0, gameFieldHeight), random.Next(1, 2),
                random.Next(-1, 2), random.Next(-1, 2), gameFieldWidth, gameFieldHeight));

        gameState = GameState.Play;
    }

    public void StartCheckCollisionGame()
    {
        player = new Circle(gameFieldWidth / 3, gameFieldHeight / 2, 215, 10, 0, gameFieldWidth, gameFieldHeight);
        circles = new List<Circle>
        {
            player,
            new(gameFieldWidth * 2 / 3, gameFieldHeight / 2, 215, -10, 0, gameFieldWidth, gameFieldHeight)
        };

        gameState = GameState.Play;
    }
}