using System.Diagnostics.Contracts;
using Raylib_cs;

class DoorItem{
    public Texture2D image;
    public Rectangle rect;
    public bool isKeyPickedUp;


public void IsDoorLocked()
{
    if (isKeyPickedUp == true)
    {
        Raylib.DrawText("OPEN", 556, 430, 30, Color.Green);
        // doorItems.RemoveAll("nycklar??")
    }
    else
    {
        Raylib.DrawText("LOCKED", 556, 430, 30, Color.Red);
    }
}
    
}