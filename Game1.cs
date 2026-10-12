using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyFirstGame.Graphics;

namespace MyFirstGame;



public class Game1 : Game

{

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _whale;
    
    // Texture region that defines the slime sprite within the texture atlas
    private TextureRegion _slime;

    // Texture region that defines the bat sprite within the texture atlas
    private TextureRegion _bat;


    public Game1()

    {

        _graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";

        IsMouseVisible = true;

    }



    protected override void Initialize()

    {

        // TODO: Add your initialization logic here



        base.Initialize();

    }



    protected override void LoadContent()

    {

        _spriteBatch = new SpriteBatch(GraphicsDevice);



        // TODO: use this.Content to load your game content here
        //_whale = Content.Load<Texture2D>("images/whale_sprite2");

        // Load the atlas texture using the content manager
        Texture2D atlasTexture = Content.Load<Texture2D>("images/atlas");

        // Create a TextureAtlas instance from the atlas
        TextureAtlas atlas = new TextureAtlas(atlasTexture);

        // Add the regions to the texture atlas for the slime and the bat
        atlas.AddRegion("slime", 0, 0, 20, 20);
        atlas.AddRegion("bat", 20, 0, 20, 20);

        // Retrieve the texture regions for the slime and the bat from the texture atlas
        _slime = atlas.GetRegion("slime");
        _bat = atlas.GetRegion("bat");

    }



    protected override void Update(GameTime gameTime)

    {

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))

            Exit();



        // TODO: Add your update logic here



        base.Update(gameTime);

    }



    protected override void Draw(GameTime gameTime)

    {

        GraphicsDevice.Clear(Color.CornflowerBlue);



        // TODO: Add your drawing code here
        // _spriteBatch.Begin();

        // _spriteBatch.Draw(
        //     _whale,                     // texture
        //     new Vector2(                // position
        //         Window.ClientBounds.Width, 
        //         Window.ClientBounds.Height) * 0.5f
        //     , 
        //     null,                       // sourceRectangle
        //     Color.White,                // color
        //     0.0f,                       // rotation
        //     new Vector2(                // origin
        //         _whale.Width,
        //         _whale.Height) * 0.5f
        //     ,
        //     3.0f,                       // scale
        //     SpriteEffects.None,         // effects
        //     0.0f                        // layerDepth
        // );

        // _spriteBatch.End();

        // Begin the sprite batch to prepare for rendering, keeps the scaled pixel art looking sharp
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Draw the slime texture region at a scale of 4.0f
        _slime.Draw(
            _spriteBatch,
            Vector2.Zero,
            Color.White, 
            0.0f,
            Vector2.One,
            4.0f,
            SpriteEffects.None,
            0.0f
        );


        // Draw the bat texture region 10px to the right of the slime texture region at a scale of 4.0f
        _bat.Draw(
            _spriteBatch,
            new Vector2(_slime.Width * 4.0f + 10, 0),
            Color.White,
            0.0f,
            Vector2.One,
            4.0f,
            SpriteEffects.None,
            0.0f
        );

        // Always end the sprite batch when finished
        _spriteBatch.End();

        base.Draw(gameTime);

    }

}

