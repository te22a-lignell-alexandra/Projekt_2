using System.Diagnostics.Contracts;
using Raylib_cs;

class Door{
    public Texture2D image;
    public Rectangle rect;
    public bool isKeyPickedUp = false;


public void IsDoorLocked(Character character)
{
    if (isKeyPickedUp == true && Raylib.CheckCollisionRecs(character.rect, rect))
    {
        Raylib.DrawText("OPEN", (int)rect.X, (int)rect.Y + 40, 30, Color.Green);
    }
    else
    {
        Raylib.DrawText("LOCKED", (int)rect.X, (int)rect.Y + 40, 30, Color.Red);
    }
}
    
}