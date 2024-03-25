using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Raylib_cs;

class Door{
    public Texture2D image;
    public Rectangle rect;
    public bool isKeyPickedUp;


public void IsDoorLocked(Character character)
{
    // Nåt är fel ------------------------------------------------
    // -----------------------------------------------------------
    if (Raylib.CheckCollisionRecs(character.rect, rect) && Raylib.IsKeyDown(KeyboardKey.E))
    {
        if (isKeyPickedUp == true) 
        {
            Raylib.DrawText("Unlocked", (int)rect.X, (int)rect.Y + 40, 30, Color.Green);
        }

        else 
        {
            Raylib.DrawText("Use Key To Unlock", (int)rect.X - 30, (int)rect.Y + 100, 20, Color.Red);
        }
    }
}
    
}