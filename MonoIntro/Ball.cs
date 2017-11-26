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
        public Texture2D image;
        public Vector2 position;
        public Vector2 speed;
        public Vector2 bounds;
        Color tint;
        public Rectangle hitbox;
       // public bool IsDebugMode { get; set; } = true;
        //private static Texture2D debugPixel;

        public Ball(Texture2D Image, Vector2 Position, Vector2 Speed, Color Tint, Vector2 Bounds)
        {
            image = Image;
            position = Position;
            speed = Speed;
            tint = Tint;
            bounds = Bounds;
            hitbox = new Rectangle((int)Position.X,(int)Position.Y, image.Height, image.Width);

       
//           if (debugPixel == null)
  //          {
    //            debugPixel = new Texture2D(image.GraphicsDevice, 1, 1);
      //          debugPixel.SetData(new[] { Color.White });
        //    }
        }

        public void Update(GraphicsDevice graphics)
        {
            position += speed;

            if (position.Y + image.Height > bounds.Y)
            {
                speed.Y = -Math.Abs(speed.Y);
               
            }

           
            if (position.Y < 0)
            {
                speed.Y = Math.Abs(speed.Y);
              
            }
           
            hitbox = new Rectangle((int)position.X,(int)position.Y, image.Width, image.Height);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(image, position, null, Color.White);

     
          //  if (IsDebugMode)
            //{
              //  batch.Draw(debugPixel, hitbox, Color.Orange* 0.5f);
            //}
        }

    }
}
