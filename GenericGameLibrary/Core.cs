using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GenericGameLibrary;

public class Core : Game
{
    internal static Core s_instance;

    /// <summary>
    ///     Creates a new Core instance.
    /// </summary>
    /// <param name="title">The title to display in the title bar of the game window</param>
    /// <param name="width">The initial width, in pixels, of the game window</param>
    /// <param name="height">The initial height, in pixels, of the game window</param>
    /// param name="fullscreen">Indicates if the game should start in fullscreen mode
    /// </param>
    public Core(string title, int width, int height, bool fullScreen)
    {
        // Enforce Singleton
        if (s_instance != null)
            throw new InvalidOperationException("SINGLETON VIOLATION! Only a single Core instance can be created!");

        s_instance = this;

        Graphics = new GraphicsDeviceManager(this);

        //Set graphics default
        Graphics.PreferredBackBufferWidth = width;
        Graphics.PreferredBackBufferHeight = height;
        Graphics.IsFullScreen = fullScreen;

        Graphics.ApplyChanges();

        Window.Title = title;

        //Set core's content manager to a reference of the base Game's content manager
        Content = base.Content;

        Content.RootDirectory = "Content";

        IsMouseVisible = true;
    }

    /// <summary>
    ///     Gets a reference to the Core instance.
    /// </summary>
    public static Core Instance => s_instance;

    /// <summary>
    ///     Gets the graphics device manager to control the presentation of graphics
    /// </summary>
    public static GraphicsDeviceManager Graphics { get; private set; }

    /// <summary>
    ///     Gets the graphics device used to create graphical resources and perform primitive rendering.
    /// </summary>
    public new static GraphicsDevice GraphicsDevice { get; private set; }

    /// <summary>
    ///     Gets the sprite batch used for all 2D rendering.
    /// </summary>
    public static SpriteBatch SpriteBatch { get; private set; }

    /// <summary>
    ///     Gets the content manager used to load global assets.
    /// </summary>
    public new static ContentManager Content { get; private set; }

    protected override void Initialize()
    {
        base.Initialize();

        //Set core's graphics device to a ref of the base Game's graphics device
        GraphicsDevice = base.GraphicsDevice;

        SpriteBatch = new SpriteBatch(GraphicsDevice);
    }
}