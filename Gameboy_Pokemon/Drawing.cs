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
        doorRect.x = 300;
        doorRect.y = 70;

        doorRect2.x = 500;
        doorRect2.y = 70;

        return (playerRect, doorRect, doorRect2, level);
    }






    public static (Rectangle, Rectangle, Rectangle, string) outside2Placement(string level,
                Rectangle playerRect,
                Rectangle doorRect,
                Rectangle doorRect2)
    {

        level = "outside";
        playerRect.x = 500;
        playerRect.y = 140;
        doorRect.x = 300;
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
        doorRect.x = 300;
        doorRect.y = 560;
        bossRect.x = 700;
        bossRect.y = 70;

        return (playerRect, doorRect, bossRect, level);
    }





    public static (Rectangle, Rectangle, Rectangle) startDrawing(Rectangle playerRect, Rectangle doorRect, Rectangle bossRect)
    {
        Raylib.ClearBackground(Color.BLUE);
        playerRecAndDorrRec(playerRect, doorRect);
        Raylib.DrawRectangleRec(bossRect, Color.PURPLE);
        return (playerRect, doorRect, bossRect);
    }

    public static (Rectangle, Rectangle, Rectangle) outsideDrawing(Texture2D winterBackground, Rectangle playerRect, Rectangle doorRect, Rectangle doorRect2)
    {
        Raylib.ClearBackground(Color.PINK);
        playerRecAndDorrRec(playerRect, doorRect);
        Raylib.DrawRectangleRec(doorRect2, Color.BLACK);
        return (playerRect, doorRect, doorRect2);
    }




    static void playerRecAndDorrRec(Rectangle q, Rectangle w)
    {
        Raylib.DrawRectangleRec(q, Color.BROWN);
        Raylib.DrawRectangleRec(w, Color.BLACK);
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




    public static (string, Vector2, string, int, int, Rectangle, Rectangle) fightPlacement(
        string fight, int hp_ai, string fightersDecided, int fightersHp, Rectangle lineHorisontelBossFight,
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

        return (fight, mousePos, fightersDecided, hp_ai, fightersHp, lineHorisontelBossFight, lineVerticalBossFight);
    }

    public static (string, string) menuPlacement(string wellcomeTest, string heroSynbol)
    {

        Raylib.ClearBackground(Color.PINK);
        Raylib.DrawText($"{wellcomeTest}", 10, 10, 40, Color.BLACK);
        Raylib.DrawText("Your mission is to beat Tu Towns", 10, 50, 40, Color.BLACK);
        Raylib.DrawText("champion to become the best syumbol trainer", 10, 90, 40, Color.BLACK);
        Raylib.DrawText("in the continent", 10, 130, 40, Color.BLACK);

        Raylib.DrawText("Controles", 10, 200, 40, Color.BLACK);
        Raylib.DrawText("W: move upp", 10, 250, 40, Color.BLACK);
        Raylib.DrawText("D: move right", 10, 300, 40, Color.BLACK);
        Raylib.DrawText("A: move left", 10, 350, 40, Color.BLACK);
        Raylib.DrawText("S: move down", 10, 400, 40, Color.BLACK);
        Raylib.DrawText("M: Menu", 10, 450, 40, Color.BLACK);

        Raylib.DrawText("Chose your fighter", 300, 200, 40, Color.BLACK);
        Raylib.DrawText("Press 1 for Circle", 300, 250, 40, Color.BLACK);
        Raylib.DrawText("Press 2 for triangle", 300, 300, 40, Color.BLACK);
        Raylib.DrawText("Press 3 for rectangle", 300, 350, 40, Color.BLACK);

        Raylib.DrawText("After picking fighter", 300, 450, 40, Color.BLACK);
        Raylib.DrawText("pess M to leave menu", 300, 500, 40, Color.BLACK);

        Raylib.DrawText("Fighter:", 10, 550, 40, Color.LIGHTGRAY);
        Raylib.DrawText($"{heroSynbol}", 200, 550, 40, Color.LIGHTGRAY);

        return (wellcomeTest, heroSynbol);
    }












    public static (int, string, string, int) winLose(int hp_ai, string fight, string level, int fightersHp)
    {
        if (hp_ai <= 0) //trigger victory if fight happend
        {
            fight = "noDuring";
            level = "victory";

        }
        if (fightersHp <= 0) //trigger game over
        {
            fight = "noDuring";
            level = "game over";
        }
        return (hp_ai, fight, level, fightersHp);
    }








    public static (string, string, string) DrawWinLose(string level, string heroSynbol, string fightersDecided)
    {
        if (level == "victory")
        { //victory
            Raylib.ClearBackground(Color.BLUE);
            Raylib.DrawText("You Won!", 400, 280, 40, Color.BLACK);

        }

        else if (level == "game over")
        { //game over
            Raylib.ClearBackground(Color.RED);
            Raylib.DrawText("You lost", 400, 280, 40, Color.BLACK);
            //why lost
            if (heroSynbol == "triangle" && fightersDecided == "cirle")
            {
                Raylib.DrawText("You may have lost becuse cirle is stronger against triangle", 200, 350, 40, Color.BLACK);
            }
            if (heroSynbol == "rectangle" && fightersDecided == "triangle")
            {
                Raylib.DrawText("You may have lost becuse triangle is stronger against rectangle", 200, 350, 40, Color.BLACK);
            }
            if (heroSynbol == "circle" && fightersDecided == "rectangle")
            {
                Raylib.DrawText("You may have lost becuse rectangle is stronger against circle", 200, 350, 40, Color.BLACK);
            }




        }
        return (level, heroSynbol, fightersDecided);
    }





}