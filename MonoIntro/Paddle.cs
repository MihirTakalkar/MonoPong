using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoIntro
{
    class Paddle
    {
        public Texture2D image;
        public Vector2 position;
        public Color tint;
        public int speed;

        //constructor (Image, postion, tint, speed)
        public Paddle(Texture2D Image, Vector2 Position, int Speed, Color Tint)
        {
            image = Image;
            position = Position;
            speed = Speed;
            tint = Tint;
            speed = Speed;
        }
        public void Update(int heightOfScreen)
        {
            if (position.Y < 0)
            {
                position = new Vector2(position.X, 0);
            }

            else if(position.Y + image.Height > heightOfScreen)
            {
                position = new Vector2(position.X, heightOfScreen- image.Height);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, tint);
        }
    }
}
