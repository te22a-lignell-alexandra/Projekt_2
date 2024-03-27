using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Raylib_cs;

class Door{
    public Texture2D image;
    public Rectangle rect;
    public bool isUnlocked;

// Check if door is locked or not
public static bool IsDoorUnlocked(Door door, Item item, Character character)
{
    if (item.isPickedUp == true && Raylib.CheckCollisionRecs(character.rect, door.rect) && Raylib.IsKeyPressed(KeyboardKey.E))
    {
        door.isUnlocked = true;
    }

    return door.isUnlocked;
}

// Changing the scene when going through door
public static string GoToNewRoom(Door door, Character character, string newScene, string scene)
{
    if (door.isUnlocked == true && Raylib.CheckCollisionRecs(character.rect, door.rect) && Raylib.IsKeyPressed(KeyboardKey.E))
    {
        scene = newScene;
            // Gör scenelista med strings för om det finns flera rum?
    }

    return scene;
}

// Draw "Locked" or "Unlocked"
public static void DrawIsDoorUnlocked(Door door, Character character)
{
    if (door.isUnlocked == true && Raylib.CheckCollisionRecs(character.rect, door.rect) && Raylib.IsKeyPressed(KeyboardKey.E))
    {
        Raylib.DrawText("Unlocked", (int)door.rect.X, (int)door.rect.Y + 100, 30, Color.Green);
    }
    else if (door.isUnlocked == false && Raylib.CheckCollisionRecs(character.rect, door.rect) && Raylib.IsKeyPressed(KeyboardKey.E))
    {
        Raylib.DrawText("Use Key To Unlock", (int)door.rect.X - 30, (int)door.rect.Y + 100, 20, Color.Red);
    }
    else 
    {
        Raylib.DrawText("Locked", (int)door.rect.X, (int)door.rect.Y + 100, 30, Color.Red);
    }
}




}

