using System;
using System.ComponentModel;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FnaTestProject;

public class GameObject
{
    public Texture2D texture2D;
    public string texturePath;
    public Vector2 position;
    public float rotation;


    public GameObject(string c_path, Vector2 c_position, float c_rotation)
    {
        texturePath = c_path;
        position = c_position;
        rotation = c_rotation;
    }



    public bool HasTexture() {
        return texturePath != null;
    }



}
