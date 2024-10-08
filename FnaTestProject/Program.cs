﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using FnaTestProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

class MainScript : Game {
    [STAThread]
    static void Main() 
    {
        using (MainScript g = new MainScript())
        {
            g.Run();
        }
    }

    // Set this up to eventually draw all our sprites.
    private SpriteBatch spriteBatch;
    private Scene currentRenderedScene;
    public GameObject[] loadedObjs;

    private KeyboardState keyboardState;
    private Camera currentGameCamera;

    private SpriteFont debugFont;

    /*
    The general run order of the engine is as such:

    1: Initialize everything
        This is where we set up all of our basic stuff for this main loop here.
        

    2: Load the scene
        Scenes are collections of gameobjects, which have components (including scripts).
        We will have a ObjectsToDraw list, that gameobjects with any renderer get added to.
        Gameobjects will also always have a transform, aka a position and a rotation.
        We will also have to add an easy way to manipulate these, i will have to program a seperate editor
        script that gets loaded just for editing scenes.

        We are going to use a custom class called GameScript, which is a script that is loaded per scene.
        This is so that i can attach scripts to gameobjects and save loading scripts we dont want

        When the editor is active we do not want non-editor things running, so it will have a
        seperate way of running things. This should make stuff easier for us.

    */

    private MainScript() 
    {
        GraphicsDeviceManager gdm = new GraphicsDeviceManager(this);

        // sets up for loading our scenes later.
        Content.RootDirectory = "Content";

        // should load a config here, will have some default values if none is found.
        gdm.PreferredBackBufferWidth = 1280;
        gdm.PreferredBackBufferHeight = 720;
        gdm.IsFullScreen = false;
        gdm.SynchronizeWithVerticalRetrace = true;

    }


    protected override void Initialize()
    {
        currentRenderedScene = new Scene("Test Scene");

        loadedObjs = new GameObject[100];

        keyboardState = new KeyboardState();
        currentRenderedScene.sceneObjects = new GameObject[100];

        currentGameCamera = new Camera(Vector2.Zero, Color.Aqua, 100f, keyboardState);

        GameObject test = new GameObject("Sprites/TestSprite", Vector2.Zero, 0.0f);
        // a testing gameobject
        currentRenderedScene.sceneObjects[0] = test;

        /* good place to start the engine and load all that.
        * do it after loading config in the constructor
        */
        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();

        spriteBatch = new SpriteBatch(GraphicsDevice);

        debugFont = Content.Load<SpriteFont>("Fonts/DePixelBreit");

        // Now load all the gameobjects in the scene, which are collections of components.
        // Do a foreach for every gameobject, make a list of loaded gameobjects
        // We want to check if the gameobject has a sprite component, and if it does, we will
        // add it to the 

        GameObject loadingObj;

        foreach (GameObject loopObj in currentRenderedScene.sceneObjects) 
        {
            if (loopObj == null)
            {
                return;
            }

            // In this loop, check for every component on an object that needs loading.
            if (loopObj.HasTexture()) 
            {
                // make a new empty object
                loadingObj = new GameObject(loopObj.texturePath, loopObj.position, loopObj.rotation);
                loadingObj.texture2D = Content.Load<Texture2D>(loopObj.texturePath);
                loadedObjs[0] = loadingObj;
            }


        }

        // Load textures, sounds, etc....
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
        // unload shit we're not using
    }

    protected override void Update(GameTime gameTime)
    {

        currentGameCamera.CameraMove();
        

        // Run game logic, do not render here.
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // Render stuff, do not run game logic here.
        GraphicsDevice.Clear(Color.White);
        spriteBatch.Begin();

        

        foreach (GameObject loadedObj in loadedObjs) 
        {

            if (loadedObj != null)
            {
                if (loadedObj.HasTexture())
                {
                    // We add the cameras position to the objects position to account for camera movement.
                    spriteBatch.Draw(loadedObj.texture2D, loadedObj.position + currentGameCamera.cameraPos, Color.White);
                }
    
            }
        }

        spriteBatch.DrawString(debugFont, gameTime.ElapsedGameTime.ToString(), Vector2.Zero, Color.Aqua);
        spriteBatch.End();

        

        base.Draw(gameTime);

    

    }





// THE REST OF THE ENGINE FUNCTIONALITY IS BELOW THIS LINE //




/// <summary>
/// The scene for the Game to load next.
/// </summary>
/// <param name="newScene"></param>


    public void LoadScene(Scene newScene) 
    {
        // thats it, this is just a helper function.
        currentRenderedScene = newScene;

    }


}