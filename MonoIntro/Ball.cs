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


        public Ball(Texture2D Image, Vector2 Position, Vector2 Speed, Color Tint, Vector2 Bounds)
        {
            image = Image;
            position = Position;
            speed = Speed;
            tint = Tint;
            bounds = Bounds;
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
        }
        //draw
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(image, position, null, Color.White);
        }

    }
}
