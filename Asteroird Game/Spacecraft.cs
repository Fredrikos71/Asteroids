using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Asteroird_Game
{
     class Spacecraft
    {
        Texture2D texture;
        Rectangle rectangle;
        public Spacecraft(Texture2D Newtexture, Rectangle Newrectangle)
        {
            texture= Newtexture;
            rectangle= Newrectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
