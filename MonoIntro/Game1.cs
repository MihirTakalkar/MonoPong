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

        SpriteFont font;

        bool drawScore;


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
            font = Content.Load<SpriteFont>("font");
            ball = new Ball(Content.Load<Texture2D>("apple"),new Vector2 (400, 600),new Vector2 (7, 7), Color.White, new Vector2(1600, 900));
            leftpaddle = new Paddle(Content.Load<Texture2D>("samsungLeft"), new Vector2(0, 0), 6, Color.White);
            rightpaddle = new Paddle(Content.Load<Texture2D>("samsungRight"), new Vector2(GraphicsDevice.Viewport.Width - leftpaddle.image.Width, 0),6,Color.White);

            drawScore = false;

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

            if(leftpaddle.hitbox.Intersects(ball.hitbox))
            {
                ball.speed.X = Math.Abs(ball.speed.X);
            }
            
            if(rightpaddle.hitbox.Intersects(ball.hitbox))
            {
                ball.speed.X = -Math.Abs(ball.speed.X);
                drawScore = true;
            }
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            ball.Draw(spriteBatch);
            leftpaddle.Draw(spriteBatch);
            rightpaddle.Draw(spriteBatch);
            if (drawScore)
            {
                spriteBatch.DrawString(font, "Hello world!", new Vector2(1600/2, 900/2), Color.OrangeRed);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
