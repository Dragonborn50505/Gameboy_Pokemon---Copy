using System;
using Raylib_cs;
using System.Numerics;
public class Drawing
{

    public static (Rectangle, Rectangle, Rectangle, string) outsidePlacement(string level,
                Rectangle playerRect,
                Rectangle doorRect,
                Rectangle doorRect2)
    {

        level = "outside";
        playerRect.x = 300;
        playerRect.y = 140;
        doorRect.x = 260;
        doorRect.y = 70;

        doorRect2.x = 500;
        doorRect2.y = 70;

        return (playerRect, doorRect, doorRect2, level);
    }








     public static (Rectangle, Rectangle, Rectangle, string) startPlacement(string level,
                Rectangle playerRect,
                Rectangle doorRect,
                Rectangle bossRect)
    {

        level = "start";
        playerRect.x = 300;
        playerRect.y = 500;
        doorRect.x = 260;
        doorRect.y = 560;
        bossRect.x = 700;
        bossRect.y = 70;

        return (playerRect, doorRect, bossRect, level);
    }







    public static (Rectangle, Rectangle, string) shopPlacement(string level,
                Rectangle playerRect,
                Rectangle doorRect2)
    {

        level = "shop";
        playerRect.x = 500;
        playerRect.y = 500;
        doorRect2.x = 500;
        doorRect2.y = 560;

        return (playerRect, doorRect2, level);
    }




public static (string, string, int, int, Rectangle, Rectangle,  Vector2) fightPlacement(
    string fight, int hp_ai, string fightersDecided, int fightersHp, 
    Rectangle DrawRectangleRec, Rectangle lineHorisontelBossFight,
    Rectangle lineVerticalBossFight
                )
    {

            fight = "during";
            Vector2 mousePos = Raylib.GetMousePosition(); // give mouse a position
            Raylib.ClearBackground(Color.YELLOW); //drawing out all figures
            Raylib.DrawText($"{fightersDecided}", 50, 50, 40, Color.LIGHTGRAY);
            Raylib.DrawText($"{hp_ai}", 50, 100, 40, Color.LIGHTGRAY);
            Raylib.DrawText("name", 650, 450, 40, Color.LIGHTGRAY);
            Raylib.DrawText("Attack:", 50, 450, 40, Color.BLACK);
            Raylib.DrawText("Use headbutt", 50, 500, 40, Color.LIGHTGRAY);
            Raylib.DrawText("Use Kick", 50, 550, 40, Color.LIGHTGRAY);
            Raylib.DrawText("Run Away", 400, 450, 40, Color.BLACK);
            Raylib.DrawText($"{fightersHp}", 650, 500, 40, Color.LIGHTGRAY);
            Raylib.DrawRectangleRec(lineHorisontelBossFight, Color.BLACK);
            Raylib.DrawRectangleRec(lineVerticalBossFight, Color.BLACK);

        return (fight, fightersDecided, hp_ai, fightersHp, 
        DrawRectangleRec, lineHorisontelBossFight, lineVerticalBossFight);
    }














































}