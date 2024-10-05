namespace FnaTestProject;

using System.Diagnostics;
using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Camera {

    private KeyboardState keyboardPrev = new KeyboardState();

    /// <summary>
    /// The cameras current movement speed.
    /// </summary>
    public float moveSpeed;

    /// <summary>
    /// The cameras current position.
    /// </summary>
    public Microsoft.Xna.Framework.Vector2 cameraPos;

    /// <summary>
    /// The color for the background of the camera.
    /// </summary>
    public Color cameraClearColor;

    // Constructor for the camera object.
    public Camera(Microsoft.Xna.Framework.Vector2 initalPos, Color clearColor, float c_movespeed, KeyboardState c_keyboard)
    {

        cameraPos = initalPos;
        cameraClearColor = clearColor;
        moveSpeed = c_movespeed;
        keyboardPrev = c_keyboard;
        
    }

    // Changes the cameras position according to Input.
    public void CameraMove() 
    {
        if (true)
        {
            cameraPos.Y++;
            Debug.WriteLine("W pressed");
        }

        if (keyboardPrev.IsKeyDown(Keys.A))
        {
            cameraPos.X -= moveSpeed;
        }

        if (keyboardPrev.IsKeyDown(Keys.D))
        {
            cameraPos.X += moveSpeed;
        }

        if (keyboardPrev.IsKeyDown(Keys.S))
        {
            cameraPos.Y -= moveSpeed;
        }
    }

    // A simple setter for the cameras speed
    public void SetCameraSpeed(float speed)
    {
        moveSpeed = speed;
        Console.WriteLine("Camera speed set to: ", speed);
    }

    // Simple method for resetting the cameras position
    public void ResetCameraPosition()
    {
        cameraPos = new Microsoft.Xna.Framework.Vector2(0,0);
        Console.WriteLine("Camera position reset.");
    }

    // Simple method for setting the cameras position
    public void SetCameraPosition(Microsoft.Xna.Framework.Vector2 newPos)
    {
        cameraPos = newPos;
        Console.WriteLine("Camera position changed to: ", cameraPos);
    }
}