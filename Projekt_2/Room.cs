using Raylib_cs;

class Room{
    public static void DrawBasicScene(Character playerCharacter, List<Rectangle> walls, List<Door> doors, List<Item> items, Color bgColor, Color wallColor)
{
    Raylib.ClearBackground(bgColor);
    // Draw All Walls
    foreach (Rectangle wall in walls) Raylib.DrawRectangleRec(wall, wallColor);

    // Draw All Doors
    foreach (Door door in doors)
    {
        Raylib.DrawTexture(door.image, (int)door.rect.X, (int)door.rect.Y, Color.White);
        // Write open or locked by the door
        
    }

    // Draw All Items
    foreach (Item item in items) 
    {

        // Nåt är fel FUNKAR FORTFARANDE INTE ---------------------------------------------
        // --------------------------------------------------------
        if (!item.isPickedUp)
        {
            Raylib.DrawTexture(item.image, (int)item.rect.X, (int)item.rect.Y, Color.White);
            item.IsPickedUp(playerCharacter);
        }
    }
}
}