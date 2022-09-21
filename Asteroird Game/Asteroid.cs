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
    public class Asteroid
    {
        Texture2D AsteroidTex;
        public Vector2 pos;
        public Vector2 Asteroidvelocity;
        int width;
        Vector2 velocity;

        public Asteroid(Texture2D AsteroidTex, Vector2 pos, Vector2 velocity )
        {
            this.AsteroidTex = AsteroidTex;
            this.pos = pos;
            this.Asteroidvelocity = velocity;
        }
        public void update()
        {
            pos = pos + Asteroidvelocity;

            if (pos.X < 0 || pos.X > width - AsteroidTex.Width)
            {
                velocity = velocity * -1;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(AsteroidTex, pos, Color.White);
        }
    }
}
