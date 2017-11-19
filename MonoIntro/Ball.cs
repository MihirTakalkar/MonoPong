using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoIntro
{
    class Ball
    {
        Texture2D image;
        Vector2 position;
        Vector2 speed;
        Vector2 bounds;
        Color tint;
        Rectangle hitbox;
        /*
         * code below is meant for debugging
         * */
        public bool IsDebugMode { get; set; } = true;
        // this is static because we want only 1 debugPixel across all classes
        private static Texture2D debugPixel;

        public Ball(Texture2D Image, Vector2 Position, Vector2 Speed, Color Tint, Vector2 Bounds)
        {
            image = Image;
            position = Position;
            speed = Speed;
            tint = Tint;
            bounds = Bounds;
            hitbox = new Rectangle((int)Position.X,(int)Position.Y, image.Width, image.Height);

            /*
         * code below is meant for debugging
         * */
            if (debugPixel == null)
            {
                debugPixel = new Texture2D(image.GraphicsDevice, 1, 1);
                // what does SetData do?
                // this sets the data of the pixels
                debugPixel.SetData(new[] { Color.White });
            }
        }

        //update
        public void Update()
        {
            position += speed;

            if (position.Y + image.Height > bounds.Y)
            {
                speed.Y = -Math.Abs(speed.Y);
            }

            if (position.X + image.Width > bounds.X)
            {
                speed.X = -Math.Abs(speed.X);
            }
            if (position.Y < 0)
            {
                speed.Y = Math.Abs(speed.Y);
            }
            if (position.X < 0)
            {
                speed.X = Math.Abs(speed.X);
            }
            hitbox = new Rectangle((int)position.X,(int)position.Y, image.Height, image.Width);
        }
        //draw
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(image, position, null, Color.White);

            /*
         * code below is meant for debugging
         * */
            if (IsDebugMode)
            {
                batch.Draw(debugPixel, hitbox, Color.Orange* 0.5f);
            }
        }

    }
}
