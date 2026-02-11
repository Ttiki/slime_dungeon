using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GenericGameLibrary;

namespace MonoGameProject1;

public class Game1 : Core
{

    private Texture2D _logo;
    
    public Game1() : base("Dungeon Slime", 1280, 720, false)
    {
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        base.LoadContent();
        
        _logo = Content.Load<Texture2D>("images/monogame_logo");

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin();

        // Draw the logo texture
        SpriteBatch.Draw(
            _logo,  // texture
            new Vector2(    // position
                Window.ClientBounds.Width,
                Window.ClientBounds.Height) * 0.5f,
            null,   // sourceRectangle
            Color.White,    // color
            MathHelper.ToRadians(90),   // rotation
            // We set the origin of the texture from the top-left to the center
            new Vector2(    // origin
                _logo.Width,
                _logo.Height) * 0.5f,
            1.0f,   // scale
            SpriteEffects.None, // effects
            0.0f    // layerDepth
        );


        // Always end the sprite batch when finished.
        SpriteBatch.End();

        
        base.Draw(gameTime);
    }
}