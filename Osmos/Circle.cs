﻿using System.Drawing.Drawing2D;

namespace Osmos;

internal class Circle
{
    public double X;
    public double Y;
    public double Radius;
    public double VelocityX;
    public double VelocityY;

    private readonly int gameFiledWidth;
    private readonly int gameFiledHeight;
    public double ImpulseX => VelocityX * Area;
    public double ImpulseY => VelocityY * Area;
    public double Area => Math.PI * Math.Pow(Radius, 2);

    public Circle(int x, int y, double radius, double velocityX, double velocityY, int gameFieldWidth,
        int gameFieldHeight)
    {
        X = x;
        Y = y;
        gameFiledHeight = gameFieldHeight;
        gameFiledWidth = gameFieldWidth;

        Radius = radius;
        VelocityX = velocityX;
        VelocityY = velocityY;
    }

    public void Draw(Graphics graphics, Brush brush)
    {
        graphics.FillEllipse(brush, (int)X - (int)Radius, (int)Y - (int)Radius, (int)Radius * 2, (int)Radius * 2);
    }

    public void Update(GameMode gameMode)
    {
        X += VelocityX;
        Y += VelocityY;

        switch (gameMode)
        {
            case GameMode.Reflection:
                ReflectionBehavior();
                break;
            case GameMode.Teleportation:
                TeleportationBehavior();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameMode), gameMode, null);
        }
    }

    public void AddArea(double deltaArea)
    {
        Radius = Math.Sqrt(Math.Pow(Radius, 2) + deltaArea / Math.PI);
    }

    public void RemoveArea(double deltaArea)
    {
        Radius = Math.Sqrt(Math.Pow(Radius, 2) - deltaArea / Math.PI);
    }

    public double GetDistanceToCircle(Circle circle)
    {
        return Math.Sqrt(Math.Pow(X - circle.X, 2) + Math.Pow(Y - circle.Y, 2));
    }

    public void ReflectionBehavior()
    {
        if (X - Radius < 0 || X + Radius >= gameFiledWidth)
            VelocityX = -VelocityX;

        if (Y - Radius < 0 || Y + Radius >= gameFiledHeight)
            VelocityY = -VelocityY;
        if (X - Radius < 0)
            X = Radius;

        if (Y - Radius < 0)
            Y = Radius;

        if (X + Radius >= gameFiledWidth)
            X = gameFiledWidth - Radius;

        if (Y + Radius >= gameFiledHeight)
            Y = gameFiledHeight - Radius;
    }

    public void TeleportationBehavior()
    {
        if (X < 0)
            X = gameFiledWidth - 1;

        if (Y < 0)
            Y = gameFiledHeight - 1;

        if (X >= gameFiledWidth)
            X = 0;

        if (Y >= gameFiledHeight)
            Y = 0;
    }
}