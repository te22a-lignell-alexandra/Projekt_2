// Console.WriteLine("hej");


// Enemy e = new() {name = "Goomba"};
// Enemy e2 = new() {name = "Bowser"};
// Enemy e3 = new() {name = "Gannon"};

// e2.hp = 9;

// Console.WriteLine(e2.hp);

// List<Enemy> enemies = new();
// enemies.Add(new() {name = "Fireplant"});


// e2.weapon = new Weapon() {name = "Axe"};


// e.Hurt(30);

using Raylib_cs;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

Raylib.InitWindow(1100, 900, "screen");
Raylib.SetTargetFPS(60);


/* Vad ska finnas i spelet?
- Labyrint, man ska kunna gå mellan rum genom dörrar, när man gått genom en dörr ska det vara som om skärmen
flyttats så att man nu ser det nya rummet, dvs att man hamnar på motsatt sida, som om man kom in från dörren
- Inventory? Lista som man ska kunna bläddra i på något sätt, plocka upp och använd -> olika knappar, engångsgrejer
- Om man kan lägga in att det blir mörkt nån sekund medans man byter scen (hur gör man för att nåt ska hända i x sekunder?)
- Låsa upp nya rum genom att göra saker, instruktioner till lösning visas vid låsta dörrar 
- För att välja mellan tre karaktärer i början att spela som. Två metoder; get mouse position (get Vector2 för var
muspekaren är), och check collisions point rec (eller nåt sånt, kollar om Vector2 är innuti en rektangel), 
sen if satser för de tre karaktärerna, playerCharacter.img = blablabla.png */

/*För metoder 
Skapa static void Name() {} metod. Lägg in koden. Kolla efter fel och rätta de som finns.
Behövs inte värdet som variablen har från början kan man "skapa den igen" i metoden och sedan retunera med
orginalvariabel = Metod(); i main. Gå inte direkt till parametrar eller ref! försök med return. 

Lägga i klasser, skriv public före --> public static void Metod()
Glöm ej Klassnamn.Metod() vid anropning*/

string scene = "start";

Texture2D[] playerCharacterTextures = {Raylib.LoadTexture("img/PCwitch256px.png"), Raylib.LoadTexture("img/PCwizard256px.png"), Raylib.LoadTexture("img/PCpotionsWitch256px.png")};
Rectangle[] playerCharacterRecs = {new(50, 300, 200, 200)};

Character playerCharacter = new() {rect = new(500, 400, 64, 64)};



while (!Raylib.WindowShouldClose())
{
    /* --------------------------------------------------------------------------------------------------
    == MAIN ==
    ----------------------------------------------------------------------------------------------------*/
    if (scene == "start")
    {
        if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), )
        {

        }
    }
   
    if (scene != "ending" || scene != "start")
    {
        // Player can move around freely on the screen, not outside of the screen
        Character.PlayerCharacterMovement(playerCharacter);
    }

    /*----------------------------------------------------------------------------------------------------
    == DRAWING ==
    -----------------------------------------------------------------------------------------------------*/
    Raylib.BeginDrawing();

    if (scene == "start")
    {
        Raylib.ClearBackground(Color.DarkGreen);
        Raylib.DrawText("Click On The Character You Want To Play As", 160, 100, 30, Color.Gold);
        
        

        
    }

    else if (scene != "start" || scene != "end")
    {
        Raylib.ClearBackground(Color.DarkGreen);
        Raylib.DrawTexture(playerCharacter.image, (int)playerCharacter.rect.X, (int)playerCharacter.rect.Y, Color.White);
    }


    Raylib.EndDrawing();

}