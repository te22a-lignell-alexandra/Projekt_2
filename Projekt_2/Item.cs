using System.Numerics;
using Raylib_cs;

class Item{
    public string name = "";
    public Rectangle rect;
    public Texture2D image;
    public bool isPickedUp;

    public bool IsPickedUp(Character character)
    {
        // Nåt är fel ----------------------------------------------
        // ---------------------------------------------------------
        if (Raylib.CheckCollisionRecs(character.rect, rect) && Raylib.IsKeyPressed(KeyboardKey.E))
        {
            return isPickedUp = true;
        }
        
        else return isPickedUp = false;
    }
}