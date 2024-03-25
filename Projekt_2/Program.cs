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




/*VIKTIGT ATT HA MED!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
Runtime-fel hindras av t.ex. try eller tryparse (gör i konsollspel istället)
Användaren informeras om vad hen gjort fel minst 1 gång (locked/need key to unlock 
visas om man försöker öppna dörren utan nyckeln)
Motiverar valet av array eller lista i kommentar (har gjort)
Använder olika typer av loopar (while nuddar trapdoor, if satser i kring locked/unlocked)*/

string scene = "start";

// Array eftersom antalet karaktärer aldrig ändras, bara viktigt 1 gång i början
Character[] CharacterOptions = {
    new() {rect = new(70, 300, 256, 256), image = Raylib.LoadTexture("img/PCwitch256px.png")},
    new() {rect = new(420, 300, 256, 256), image = Raylib.LoadTexture("img/PCwizard256px.png")},
    new() {rect = new(750, 300, 256, 256), image = Raylib.LoadTexture("img/PCpotionsWitch256px.png")}
};

Character playerCharacter = new();
Texture2D shadow = Raylib.LoadTexture("img/skugga.png");

// Listor, eftersom det läggs till och tas bort saker i nya rum
List<Rectangle> walls = new();
List<Door> doors = new();
List<Item> items = new();


/*Inventory system idea:
lista, nån loop m i i listan, om klicka på nån tangent = i + eller - 1. Byt mellan olika föremål?*/
List<Item> inventory = new();


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
        // MAIN -entrance- --------------------------------------------------------------------------------
        if (scene == "entrance")
        {
            walls.Clear();
            doors.Clear();
            // Create the walls
            walls.Add(new(200, 200, 700, 50));
            walls.Add(new(200, 200, 50, 500));
            walls.Add(new(900, 200, 50, 500));
            walls.Add(new(200, 700, 300, 50));
            walls.Add(new(650, 700, 300, 50));
            // Trapdoor
            doors.Add(new() {rect = new(556, 386, 128, 128), image = Raylib.LoadTexture("img/trapdoor.png")});
            // Items in room
            items.Add(new() {name = "trapdoorKey", rect = new(518, 50, 64, 64), image = Raylib.LoadTexture("img/key.png"), isPickedUp = false;});
            
            // foreach (Item item in items)
            // {
            //     if (item.IsPickedUp(playerCharacter) == true) door.isKeyPickedUp = true;
            // }
        }

        // Player can move around freely on the screen, not outside of the screen or through walls
        playerCharacter.CharacterMovement(walls);

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
        // ------------------------------------------------------------------------
        // Drawing -entrance- (borde väl funka utan loop eftersom listorna ändras med rummen)
        Room.DrawBasicScene(playerCharacter, walls, doors, items, Color.Brown, Color.DarkBrown);

        // Things that should be drawn top of the rest 
        Raylib.DrawTexture(playerCharacter.image, (int)playerCharacter.rect.X, (int)playerCharacter.rect.Y, Color.White);
        Raylib.DrawTexture(shadow, (int)playerCharacter.rect.X - 1100, (int)playerCharacter.rect.Y - 900, Color.White);
        Raylib.DrawText($"HP: {playerCharacter.hp}", 10, 10, 40, Color.Red);
    }

    Raylib.EndDrawing();
}