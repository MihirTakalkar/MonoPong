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

        Ball ball;

        Paddle leftpaddle;
        Paddle rightpaddle;


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
            // GraphicsDevice.Viewport.Height
            ball = new Ball(Content.Load<Texture2D>("ball"),new Vector2 (400, 600),new Vector2 (7, 7), Color.White, new Vector2(1600, 900));
            leftpaddle = new Paddle(Content.Load<Texture2D>("Paddle"), new Vector2(0, 0), 6, Color.White);
            rightpaddle = new Paddle(Content.Load<Texture2D>("Paddle"), new Vector2(GraphicsDevice.Viewport.Width - leftpaddle.image.Width, 0),6,Color.White);

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
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.S))
            {
                leftpaddle.position.Y += 5;
            }
            if(ks.IsKeyDown(Keys.W))
            {
                leftpaddle.position.Y -= 5;
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                rightpaddle.position.Y -= 5;
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                rightpaddle.position.Y += 5;
            }
            ball.Update();
         
            base.Update(gameTime);
            leftpaddle.Update(GraphicsDevice.Viewport.Height);
            rightpaddle.Update(GraphicsDevice.Viewport.Height);
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

            ball.Draw(spriteBatch);

            leftpaddle.Draw(spriteBatch);
            rightpaddle.Draw(spriteBatch);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
