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
        public Rectangle hitbox;
     //  Texture2D depugPixel;  

        public Paddle(Texture2D Image, Vector2 Position, int Speed, Color Tint)
        {
            image = Image;
            position = Position;
            speed = Speed;
            tint = Tint;
            speed = Speed;
            hitbox = new Rectangle((int)Position.X,(int)Position.Y,image.Width, image.Height);

           // if(depugPixel == null)
          //  {
          //      depugPixel = new Texture2D(image.GraphicsDevice, 1, 1);
          //      depugPixel.SetData(new[] { Color.White });
          //  }
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
            hitbox = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, tint);
           // spriteBatch.Draw(depugPixel, hitbox, Color.Green*0.5f);
        }
    }
}
