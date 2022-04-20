using System;
using Raylib_cs;
using System.Numerics;

public class Movement
{
    public static (bool, bool, Rectangle, Vector2) LimitMovement(
                    float leftLimit,
                    float rightLimit,
                    float topLimit,
                    float bottomLimit,
                    Rectangle playerRect,
                    float speed)
    {
        Vector2 movement = ReadMovement(speed);
        playerRect.x += movement.X;
        playerRect.y += movement.Y;

        bool undoX = false;
        bool undoY = false;

        if (playerRect.x < leftLimit || playerRect.x > rightLimit)
        { undoX = true; }
        if (playerRect.y < topLimit || playerRect.y > bottomLimit)
        { undoY = true; }

        return (undoX, undoY, playerRect, movement);

    }

    public static Vector2 ReadMovement(float speed) //movement
    {
        Vector2 movement = new Vector2();
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y = -speed;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y = speed;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X = -speed;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X = speed;

        return movement;
    }
}