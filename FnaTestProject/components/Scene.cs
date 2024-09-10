using System;
using Microsoft.Xna.Framework;

namespace FnaTestProject;

public class Scene
{

    public string name;
    public required Dictionary<float, GameObject> sceneObjects;

    public Scene(string c_name) 
    {
        name = c_name;
    }

    // override for copying scenes
    public Scene(string c_name, Dictionary<float, GameObject> c_sceneobjects)
    {
        name = c_name;
        sceneObjects = c_sceneobjects;
    }

}
