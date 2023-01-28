
namespace Osmos
{
    internal class PlayerCircle:Circle
    {
        public PlayerCircle(int x, int y, int radius, double velocityX, double velocityY, int gameFieldWidth, int gameFieldHeight) : base(x, y, radius, velocityX, velocityY, gameFieldWidth, gameFieldHeight)
        {
            brush = Brushes.Blue;
        }

        public void CreateCircle(int mouseX, int mouseY, List<Circle>circles)
        {
            //Circle createdCircle = new (mouseX,mouseY, 1, -VelocityX, -VelocityY, gameFiledWidth,
            //    gameFiledHeight);
            //createdCircle.AddArea(Area/20);
            //RemoveArea(createdCircle.Area);
            //circles.Add(createdCircle);
        }
    }
}
