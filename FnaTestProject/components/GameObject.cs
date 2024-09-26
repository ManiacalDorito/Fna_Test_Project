using System;
using System.ComponentModel;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FnaTestProject;

public class GameObject
{
    public Texture2D texture2D;
    public string TexturePath;
    public Vector2 position;
    public float rotation;


    public GameObject()
    {
        
    }



    public bool HasTexture() {
        return TexturePath != null;
    }



}
