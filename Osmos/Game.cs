﻿namespace Osmos
{
    internal class Game
    {
        private readonly Random random = new();
        private readonly Font font = new(FontFamily.GenericSansSerif, 20, FontStyle.Bold);
        private PlayerCircle player;

        private List<Circle> circles;

        public Game(int gameFieldWidth, int gameFieldHeight)
        {
            player = new PlayerCircle(gameFieldWidth / 2, gameFieldHeight / 2, 20, 0, 0, gameFieldWidth, gameFieldHeight);
            circles = new() { player };

            for (int i = 0; i <= 4000; i++)
            {
                circles.Add(new Circle(random.Next(0, gameFieldWidth), random.Next(0, gameFieldHeight), random.Next(2, 5),
                    random.Next(-2, 3), random.Next(-2, 3), gameFieldWidth, gameFieldHeight));
            }
        }

        public void Draw(Graphics graphics)
        {
            double totalArea = 0;

            foreach (Circle circle in circles)
            {
                circle.Draw(graphics);
                totalArea += circle.Area;
            }

            graphics.DrawString("Total area: " + (int)totalArea, font, Brushes.Black, 50, 50);
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

                if(circles[i]==player)
                    continue;

                if (circles[i].Area <= player.Area)
                    circles[i].brush = Brushes.GreenYellow;
                else
                    circles[i].brush = Brushes.OrangeRed;
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
            player.CreateCircle(mouseX,mouseY,circles);
        }
    }
}