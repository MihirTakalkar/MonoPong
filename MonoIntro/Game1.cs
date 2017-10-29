using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoIntro
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D image;
        Vector2 position;
        Vector2 speed;
        Color tint;

        Texture2D mimage;
        Vector2 mposition;
        Vector2 mspeed;
        Color mtint;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            position = new Vector2(200, 200);
            speed = new Vector2(4, 3);
            tint = Color.White;
            image = Content.Load<Texture2D>("ball");
            mposition = new Vector2(0, 0);
            mspeed = new Vector2(0, 6);
            mtint = Color.White;
            mimage = Content.Load<Texture2D>("Paddle");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {


            position += speed;

            if (position.Y + image.Height > GraphicsDevice.Viewport.Height)
            {
                speed.Y = -Math.Abs(speed.Y);
            }

            if(position.X + image.Width > GraphicsDevice.Viewport.Width)
            {
                speed.X = -Math.Abs(speed.X);
            }
            if(position.Y < 0)
            {
                speed.Y = Math.Abs(speed.Y);
            }
            if(position.X < 0)
            {
                speed.X = Math.Abs(speed.X);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(image, position, tint);
            spriteBatch.Draw(mimage, mposition, mtint);
            

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
