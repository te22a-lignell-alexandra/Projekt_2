using System.Numerics;
using Raylib_cs;

class Character
{
    public Texture2D image;
    public Rectangle rect;
    public Vector2 movement = new Vector2(0,0);
    public int hp;

/* -----------------------------------------------------------------------------------------------------
== METODER ==
-------------------------------------------------------------------------------------------------------*/

// (Från projekt 1, först kopierat från genomgång vv)
// playerCharacter vector movement code
    public static Vector2 Movement(out Vector2 movement, float speed)
{
    movement = Vector2.Zero;

        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            movement.X = -1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            movement.X = 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            movement.Y = -1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            movement.Y = 1;
        }
        if (movement.Length() > 0)
        {
            movement = Vector2.Normalize(movement) * speed;
        }

    return movement;
}
// PlayerCharacter can move around (not outside of the screen)
public static void PlayerCharacterMovement(Character character)
{
    character.movement = Movement(out character.movement, 5);

    character.rect.X += character.movement.X;
    if (character.rect.X > 1100 - character.rect.Width || character.rect.X < 0)
    {
        character.rect.X -= character.movement.X;
    }
    
    character.rect.Y += character.movement.Y;
    if (character.rect.Y > 900 - character.rect.Height || character.rect.Y < 0)
    {
        character.rect.Y -= character.movement.Y;
    }
}

// Choose your character in the beginning
public static (Texture2D, Rectangle) ChoosePlayerCharacter(Character character, Character[] option)
{
    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), option[0].rect) && Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            character.image = Raylib.LoadTexture("img/PCwitch.png");
            character.rect = new(500, 400, 64, 64);
        }
    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), option[1].rect) && Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            character.image = Raylib.LoadTexture("img/PCwizard.png");
            character.rect = new(500, 400, 64, 64);
        }
    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), option[2].rect) && Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            character.image = Raylib.LoadTexture("img/PCpotionsWitch.png");
            character.rect = new(500, 400, 64, 64);
        }
    
    return (character.image, character.rect);
    // Kan man göra om det med bara en if sats??
}

public static string DrawCharacterStart(string scene, Character[] CharacterChoice, Character playerCharacter)
{
    foreach (Character character in CharacterChoice)
    {
        Raylib.DrawTexture(character.image, (int)character.rect.X, (int)character.rect.Y, Color.White);
    }

    if (playerCharacter.image.Width != 0)
    {
        scene = "entrance";
    }

    return scene;
}
}
