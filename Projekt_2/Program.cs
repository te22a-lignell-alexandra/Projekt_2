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
- Inventory? Lista som man ska kunna bläddra i på något sätt, tryck för att plocka upp (inom ett visst avstånd), 
inventory visas längst ner, saker går sönder eller försvinner efter att ha använts ett visst antal gånger.
- Om man kan lägga in att det blir mörkt nån sekund medans man byter scen (hur gör man för att nåt ska hända i x sekunder?)
- Låsa upp nya rum genom att göra saker, instruktioner till lösning visas vid låsta dörrar 
- random movement fiende - random generator x och y, while (scene == rum && fiende is alive) while x != random x
x++, while y != random y, y++. om x = random x och/eller y = random y, ny random x och y
- Mörkt runt omkring, kan bara se i en cirkel runt sig: gör en png svart rektangel m måtten 2 ggr skärmen + lite till
och en cirkel m ingenting i mitten, position = playerCharacter x och y så följer med när man går*/

/*För metoder 
Skapa static void Name() {} metod. Lägg in koden. Kolla efter fel och rätta de som finns.
Behövs inte värdet som variablen har från början kan man "skapa den igen" i metoden och sedan retunera med
orginalvariabel = Metod(); i main. Gå inte direkt till parametrar eller ref! försök med return. 

Lägga i klasser, skriv public före --> public static void Metod()
Glöm ej Klassnamn.Metod() vid anropning*/

string scene = "start";

Character[] CharacterOptions = {
    new() {rect = new(70, 300, 256, 256), image = Raylib.LoadTexture("img/PCwitch256px.png")},
    new() {rect = new(420, 300, 256, 256), image = Raylib.LoadTexture("img/PCwizard256px.png")},
    new() {rect = new(750, 300, 256, 256), image = Raylib.LoadTexture("img/PCpotionsWitch256px.png")}
};

Character playerCharacter = new();


while (!Raylib.WindowShouldClose())
{
    /* --------------------------------------------------------------------------------------------------
    == MAIN ==
    ----------------------------------------------------------------------------------------------------*/
    if (scene == "start")
    { 
        (playerCharacter.image, playerCharacter.rect) = Character.ChoosePlayerCharacter(playerCharacter, CharacterOptions);    
        playerCharacter.hp = 10;
    }
   /*---------------------------------------------------------------------------------------------------
   MAIN -game-
   -----------------------------------------------------------------------------------------------------*/
    if (scene != "ending" || scene != "start")
    {
        // Player can move around freely on the screen, not outside of the screen
        Character.PlayerCharacterMovement(playerCharacter);

        // MAIN -entrance- --------------------------------------------------------------------------------
        if (scene == "entrance")
        {
            
        }

    }

    /*----------------------------------------------------------------------------------------------------
    == DRAWING ==
    -----------------------------------------------------------------------------------------------------*/
    Raylib.BeginDrawing();

    if (scene == "start")
    {
        Raylib.ClearBackground(Color.DarkGreen);

        Raylib.DrawText("Who Are You Playing As?", 200, 200, 30, Color.Gold);
        scene = Character.DrawCharacterStart(scene, CharacterOptions, playerCharacter);

    }
/*---------------------------------------------------------------------------------------------------
DRAWING -game-
----------------------------------------------------------------------------------------------------*/
    else if (scene != "start" || scene != "end")
    {
        Raylib.ClearBackground(Color.DarkGreen);
        Raylib.DrawTexture(playerCharacter.image, (int)playerCharacter.rect.X, (int)playerCharacter.rect.Y, Color.White);

        // Drawing -entrance- ------------------------------------------------------------------------
        if (scene == "entrance")
        {
            Raylib.ClearBackground(Color.DarkGray);
        }
        
        Raylib.DrawText($"HP: {playerCharacter.hp}", 10, 10, 40, Color.Red);
    }


    Raylib.EndDrawing();

}