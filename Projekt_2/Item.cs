using System.Numerics;
using Raylib_cs;

class Item{
    public string name = "";
    public Rectangle rect;
    public Texture2D image;
    public bool isPickedUp = false;

    public bool IsPickedUp(Character character)
    {
        if (Raylib.CheckCollisionRecs(character.rect, rect) && Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            return true;
        }
        
        else return false;
    }
}