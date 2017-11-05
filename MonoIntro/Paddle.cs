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
        Texture2D image;
        Vector2 position;
        int maxHeight;
        Color tint;
        int speed;

        //constructor (Image, postion, tint, speed)
        public Paddle(Texture2D Image, Vector2 Position, int Speed, Color Tint, int MaxHeight)
        {
            image = Image;
            position = Position;
            speed = Speed;
            tint = Tint;
            speed = Speed;
            maxHeight = MaxHeight;
        }
        public void Update()
        {
    
        }
    }
}
