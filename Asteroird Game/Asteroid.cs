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
        public Texture2D Tex;
        public Vector2 pos;
        public Vector2 Velocity;

        public Asteroid(Texture2D tex, Vector2 pos, Vector2 velocity )
        {
            Tex = tex;
            this.pos = pos;
            Velocity = velocity;
        }
    }
}
