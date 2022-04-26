using System;
using Raylib_cs;
using System.Numerics;




public class Fight
{



//ai
    public static (Random, string, string, int, int, string) AiFightTurn(Random generator, string heroSynbol,
    string fightersDecided, int fightersHp, int playerTimer, string turn)
    {

        int aiChoice = generator.Next(1, 6);

        if (aiChoice == 1)
        {
            int KickOrMissAI = generator.Next(1, 12);

            if (KickOrMissAI == 1)
            {

            }
            else
            {
                int damage = 20 + generator.Next(0, 26);
                damage = AIdamgeResults(damage, heroSynbol, fightersDecided);
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
                damage = AIdamgeResults(damage, heroSynbol, fightersDecided);
                fightersHp -= damage;
                damage = 0;
            }
        }
        playerTimer = 120;
        turn = "player";

        return (generator, heroSynbol, fightersDecided,
        fightersHp, playerTimer, turn);
    }

    static int AIdamgeResults(int damage, string heroSynbol, string fightersDecided)
    {

        int AIspecialBonus = 5;
        if (fightersDecided == "triangle" && heroSynbol == "cirle") damage -= AIspecialBonus;
        if (fightersDecided == "triangle" && heroSynbol == "rectangle") damage += AIspecialBonus;
        if (fightersDecided == "rectangle" && heroSynbol == "cirle") damage += AIspecialBonus;
        if (fightersDecided == "rectangle" && heroSynbol == "triangle") damage -= AIspecialBonus;
        if (fightersDecided == "circle" && heroSynbol == "triangle") damage += AIspecialBonus;
        if (fightersDecided == "circle" && heroSynbol == "rectangle") damage -= AIspecialBonus;

        return damage;
 
    }




 public static (Vector2, Rectangle, int ,Random, int, string, string, string, int, Rectangle, Rectangle,
 Rectangle, Rectangle, Rectangle, string) FightTurn(Vector2 mousePos, Rectangle headbutt, int playerTimer ,Random generator, 
 int enemyTimer, string turn, string heroSynbol, string fightersDecided, int hp_ai, Rectangle kick,
 Rectangle runAway, Rectangle playerRect, Rectangle doorRect, Rectangle bossRect, string level)
    {

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
                    damage = DamgeResults(damage, heroSynbol, fightersDecided);
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
                    damage = DamgeResults(damage, heroSynbol, fightersDecided);
                    hp_ai -= damage;
                    damage = 0;
                    enemyTimer = 120;
                    turn = "enemy";
                }
            }
            if (Raylib.CheckCollisionPointRec(mousePos, runAway) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
               (playerRect, doorRect, bossRect, level) = Drawing.startPlacement
                (level, playerRect, doorRect, bossRect);
            }

    return (mousePos, headbutt, playerTimer, generator, enemyTimer, turn, heroSynbol, fightersDecided, hp_ai, 
            kick, runAway, playerRect, doorRect, bossRect, level);
    }

            


static int DamgeResults(int damage, string heroSynbol, string fightersDecided)
{

    int specialBonus = 5;
    if (heroSynbol == "triangle" && fightersDecided == "cirle") damage -= specialBonus;
    if (heroSynbol == "triangle" && fightersDecided == "rectangle") damage += specialBonus;
    if (heroSynbol == "rectangle" && fightersDecided == "cirle") damage += specialBonus;
    if (heroSynbol == "rectangle" && fightersDecided == "triangle") damage -= specialBonus;
    if (heroSynbol == "circle" && fightersDecided == "triangle") damage += specialBonus;
    if (heroSynbol == "circle" && fightersDecided == "rectangle") damage -= specialBonus;

    return damage;
}














}