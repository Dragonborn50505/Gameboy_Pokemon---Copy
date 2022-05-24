using Raylib_cs;
using System.Collections.Generic;

/*
 
Screen room1 = new Screen();
Screen room2 = new Screen();

Rectangle door1 = new Rectangle(100, 100, 28, 28);

room1.AddExit(door1, room2);
room2.AddExit(door1, room1);

...

Screen currentScreen = room1;

nextScreen = currentScreen.CheckExitCollions(playerRect);
if (nextScreen != null) {
    currentScreen = nextScreen;
} 

*/

class Screen {
    Dictionary<Rectangle, Screen> exits = new Dictionary<Rectangle, Screen>();

    void AddExit(Rectangle rect, Screen screen) {
        exits.Add(rect, screen);
    }

    public Screen CheckExitCollision(Rectangle playerRect) {
        foreach(KeyValuePair<Rectangle, Screen> exit in exits) {
            if (Raylib.CheckCollisionRecs(exit.Key, playerRect)) {
                return exit.Value;
            }
        }
        return null;
    }
}