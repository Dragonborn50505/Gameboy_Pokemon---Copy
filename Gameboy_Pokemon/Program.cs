using System;
using System.Numerics;
using Raylib_cs;
using System.Collections.Generic;

// Ingen strid har hänt
// Strid påbörjas/setup
// Strid händer JUST NU
// Mellan strider

Raylib.InitWindow(800, 600, "The title of my window");
Raylib.SetTargetFPS(60);
Random generator = new Random();
string fight = "noDuring"; // Before, During, Between
string setup = "noBeingDone";
float speed = 6f;
float specialBonus = 5;
string turn = "player";
int playerTimer = 0;
int enemyTimer = 0;
string potionHp = "inactive";
string[] fightersOptions = { "triangle", "square", "circle" };
int n = generator.Next(fightersOptions.Length);
string fightersDecided = fightersOptions[n];
Raylib.DrawText($"{fightersDecided}", 50, 500, 40, Color.LIGHTGRAY);

string[] herosOptions = { "triangle", "square", "circle" };
int h = generator.Next(fightersOptions.Length);
string heroSynbol = herosOptions[h];
Raylib.DrawText($"{heroSynbol}", 200, 500, 40, Color.LIGHTGRAY);


//Generate figures 
Rectangle playerRect = new Rectangle(100, 100, 50, 50);
Rectangle doorRect = new Rectangle(260, 560, 40, 40);
Rectangle doorRect2 = new Rectangle(300, 560, 40, 40);
Rectangle bossRect = new Rectangle(700, 70, 40, 40);

Rectangle bossFighter = new Rectangle(600, 100, 40, 40);
Rectangle fighter = new Rectangle(100, 350, 40, 40);
Rectangle shopkeeper = new Rectangle(600, 100, 40, 40);
Rectangle potion = new Rectangle(50, 100, 40, 40);

//Text for boss battle
Raylib.DrawText("Use headbutt", 50, 500, 40, Color.LIGHTGRAY);
Raylib.DrawText("Use Kick", 50, 550, 40, Color.LIGHTGRAY);
Raylib.DrawText("Run Away", 400, 450, 40, Color.BLACK);





//-----------------Tester-----------------------------------------------------------------------------------------------------

static void playerRecAndDorrRec(Rectangle q, Rectangle w)
{
    Raylib.DrawRectangleRec(q, Color.BROWN);
    Raylib.DrawRectangleRec(w, Color.BLACK);
}


//-----------------Tester-----------------------------------------------------------------------------------------------------






Rectangle headbutt = new Rectangle(50, 500, 250, 40);
Rectangle kick = new Rectangle(50, 550, 200, 40);
Rectangle runAway = new Rectangle(400, 450, 200, 40);


//lol
//Rectangle test = new Rectangle(50, 500, 200, 40);
//lol
Rectangle lineHorisontelBossFight = new Rectangle(0, 400, 800, 5);
Rectangle lineVerticalBossFight = new Rectangle(600, 400, 5, 200);
Texture2D winterBackground = Raylib.LoadTexture("Vinterprojektet.png");

//  <------ nice
//hp and time for bossfight
float time = 0;
int fightersHp = 100;
int hp_ai = 100;
float blackAndWhite = 0;



string level = "start";
bool undoX = false;
bool undoY = false;

// static void StartingArea()
// {
//  level = "start";
//         playerRect.x = 300;
//         playerRect.y = 500;
//         doorRect.x = 260;
//         doorRect.y = 560;
//         bossRect.x = 700;
//         bossRect.y = 70;
// }

static void DrawShop(Rectangle p, Rectangle d, Rectangle s)
{
    Raylib.ClearBackground(Color.RED);
    Raylib.DrawRectangleRec(p, Color.BROWN);
    Raylib.DrawRectangleRec(d, Color.BLACK);
    Raylib.DrawRectangleRec(s, Color.PINK);
}




Vector2 movement = new Vector2();

while (!Raylib.WindowShouldClose()) //the game
{
    undoX = false;
    undoY = false;

    time += Raylib.GetFrameTime();

    
    if (time > 60 && fightersHp < 100 && level != "bossfight" && fight != "during") // heal gighter if you in combat
    {
        fightersHp++;
        time = 0;
    }




    if (level == "start" || level == "shop") // borders for indors where size is the same & player movement
    {
        // playerRect = CheckMovement();

        movement = ReadMovement(speed);
        playerRect.x += movement.X;
        playerRect.y += movement.Y;

        if (playerRect.x < 0 || playerRect.width > Raylib.GetScreenWidth())
        { undoX = true; }
        if (playerRect.y < 0 || playerRect.width > Raylib.GetScreenWidth())
        { undoY = true; }
        if (playerRect.x < 0 || playerRect.x + playerRect.width > Raylib.GetScreenWidth())
        { undoX = true; }
        if (playerRect.y < 100 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
        { undoY = true; }
    }

    else if (level == "outside") // borders for outside & player movement
    {

        movement = ReadMovement(speed);
        playerRect.x += movement.X;
        playerRect.y += movement.Y;

        if (playerRect.x < 0 || playerRect.width > Raylib.GetScreenWidth())
        { undoX = true; }
        if (playerRect.y > 400 || playerRect.width > Raylib.GetScreenWidth())
        { undoY = true; }
        if (playerRect.x < 280 || playerRect.x + playerRect.width > Raylib.GetScreenWidth())
        { undoX = true; }
        if (playerRect.y < 100 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
        { undoY = true; }

    }


    if (Raylib.CheckCollisionRecs(playerRect, doorRect) && level == "start") //trigger for dorr to from start to outside
    {
        level = "outside";
        playerRect.x = 300;
        playerRect.y = 140;
        doorRect.x = 260;
        doorRect.y = 70;

        doorRect2.x = 500;
        doorRect2.y = 70;

    }

    else if (Raylib.CheckCollisionRecs(playerRect, doorRect) && level == "outside") //dorr from outside to start
    {
        level = "start";
        playerRect.x = 300;
        playerRect.y = 500;
        doorRect.x = 260;
        doorRect.y = 560;
        bossRect.x = 700;
        bossRect.y = 70;
    }

    else if (Raylib.CheckCollisionRecs(playerRect, doorRect2) && level == "outside") //dorr to shop
    {
        level = "shop";
        playerRect.x = 500;
        playerRect.y = 500;
        doorRect2.x = 500;
        doorRect2.y = 560;
    }

    if (Raylib.CheckCollisionRecs(playerRect, doorRect2) && level == "shop") //dorr from shop outside
    {
        level = "outside";
        playerRect.x = 500;
        playerRect.y = 140;
        doorRect.x = 260;
        doorRect.y = 70;

        doorRect2.x = 500;
        doorRect2.y = 70;

    }

    if (Raylib.CheckCollisionRecs(playerRect, bossRect) && level == "start") //trigger bossfight
    {
        level = "bossfight";

    }



    if (undoX == true) playerRect.x -= movement.X;
    if (undoY == true) playerRect.y -= movement.Y;

    Raylib.BeginDrawing(); //place all generated figures
    {

        if (level == "start")
        {
            Raylib.ClearBackground(Color.BLUE);
            playerRecAndDorrRec(playerRect, doorRect);
            Raylib.DrawRectangleRec(bossRect, Color.PURPLE);
        }
        

        else if (level == "outside")
        {
            Raylib.ClearBackground(Color.PINK);
            Raylib.DrawTexture(winterBackground, 0, 0, Color.WHITE);
            playerRecAndDorrRec(playerRect, doorRect);
            Raylib.DrawRectangleRec(doorRect2, Color.BLACK);
            

        }



        else if (level == "shop")
        {
            DrawShop(playerRect, doorRect2, shopkeeper);

            Vector2 mousePos = Raylib.GetMousePosition();
            if (Raylib.CheckCollisionPointRec(mousePos, shopkeeper) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                level = "buy"; //my try to make a shop
            }
        }

        else if (level == "buy")
        {
            Raylib.DrawText("potion", 50, 100, 40, Color.LIGHTGRAY);
            potionHp = "active"; //Item to buy
            level = "shop";
        }

        else if (level == "victory")
        { //victory
            Raylib.ClearBackground(Color.BLUE);
            Raylib.DrawText("You Won!", 400, 280, 40, Color.BLACK);
        }

        else if (level == "game over")
        { //game over
            Raylib.ClearBackground(Color.RED);
            Raylib.DrawText("You lost", 400, 280, 40, Color.BLACK);
        }


        if (blackAndWhite >= 120)
        {
        setup = "beingDone";
        }
        if (setup == "beingDone" && fight == "noDuring")
        {
            hp_ai = 100;
            setup = "noBeingDone";

        }
        if (fight == "during"){
             setup = "noBeingDone";
        }

        
       

        if (level == "bossfight" && blackAndWhite >= 120 && setup == "noBeingDone") //bossfight after starting sequence
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


            //lol
            //Raylib.DrawRectangleRec(test, Color.BLACK); Testar knapparna för attack osv
            //lol

            Raylib.DrawRectangleRec(bossFighter, Color.RED); //player´s and the bosses fighers
            Raylib.DrawRectangleRec(fighter, Color.BLUE);


            if (Raylib.CheckCollisionPointRec(mousePos, headbutt) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON) && turn == "player" && playerTimer == 0)
            {//player fight generator

                int HitOrMissName = generator.Next(1, 11);

                if (HitOrMissName == 1)
                {
                    enemyTimer = 120;
                    turn = "enemy";
                }
                else
                {
                    int damage = 10 + generator.Next(0, 21);
                    hp_ai -= damage;
                    damage = 0;
                    enemyTimer = 120;
                    turn = "enemy";
                }

            }

            if (Raylib.CheckCollisionPointRec(mousePos, kick) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                int KickOrMissName = generator.Next(1, 5);

                if (KickOrMissName == 1)
                {
                    enemyTimer = 120;
                    turn = "enemy";
                }
                else
                {
                    int damage = 20 + generator.Next(0, 26);
                    hp_ai -= damage;
                    damage = 0;
                    enemyTimer = 120;
                    turn = "enemy";
                }
            }
            if (Raylib.CheckCollisionPointRec(mousePos, runAway) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                level = "start";
                playerRect.x = 300;
                playerRect.y = 500;
                doorRect.x = 260;
                doorRect.y = 560;
                bossRect.x = 700;
                bossRect.y = 70;
            }

            while (turn == "enemy" && enemyTimer == 0)
            {
                //fights back'

                int ai_choice = generator.Next(1, 6);

                if (ai_choice == 1)
                {
                    int KickOrMissAI = generator.Next(1, 12);

                    if (KickOrMissAI == 1)
                    {

                    }
                    else
                    {
                        int damage = 20 + generator.Next(0, 26);
                        fightersHp -= damage;
                        damage = 0;
                    }
                }

                //________________________________________________________________________________

                else
                {
                    int HitOrMissAI = generator.Next(1, 21);

                    if (HitOrMissAI == 1)
                    {

                    }

                    else
                    {
                        int damage = 10 + generator.Next(0, 21);
                        fightersHp -= damage;
                        damage = 0;
                    }
                }

                playerTimer = 120;
                turn = "player";
            }

            if (playerTimer > 0) playerTimer--;
            if (enemyTimer > 0) enemyTimer--;


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


        }




    }
    if (level == "bossfight" && blackAndWhite < 120) //My favorite part of the code, beteween being a even and uneven number it changes back and fourth from black to white to stimulate playing pokemone on gameboye
    {
        if ((blackAndWhite / 10) % 2 == 0) //if anything is left that cant be devided in 2 and stay integer (heltal)
        {
            Raylib.ClearBackground(Color.BLACK);
        }
        else
        {
            Raylib.ClearBackground(Color.WHITE);
        }
        blackAndWhite++;
       
    }

    if (potionHp == "active" && hp_ai <= 0)
    { //Was planed to give the player a health boost if you bought it but were not able to make it work in time
        int hp = 20;
        fightersHp = +hp;

        hp--;

    }

    Raylib.EndDrawing();
}


static Vector2 ReadMovement(float speed) //movement
{
    Vector2 movement = new Vector2();
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y = -speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y = speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X = -speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X = speed;

    return movement;
}

static  Vector3 damgeResults(float damage,string heroSynbol, string fightersDecided) 
{
    Vector3 specialBonus = new Vector3();
    if (heroSynbol == "triangle" && fightersDecided =="cirle") damage =+ SpecialBonus;
//    if (trinagle && circle)
//    if (Rectangle && cirle)
//    if (Rectangle && triangle)
//    if (Circle && triangle)
//    if (Circle && Rectangle)
//    


    return specialBonus;
}


//static  Vector3 damgeResults(float damage,string heroSynbol, string fightersDecided) 
//{
//    Vector3 AIspecialBonus = new Vector3();
//    if (heroSynbol == "triangle" && fightersDecided =="cirle") damage =+ AIspecialBonus;
//    if (trinagle && circle)
//    if (Rectangle && cirle)
//    if (Rectangle && triangle)
//    if (Circle && triangle)
//    if (Circle && Rectangle)
//   

//    return AIspecialBonus;
//}


//static void CheckMovement(){

//}