using System.Numerics;
using Raylib_cs;

class Character
{
    public Texture2D image;
    public Rectangle rect;
    public Vector2 movement = new Vector2(0,0);

// Från projekt 1, först kopierat från genomgång vv
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
}