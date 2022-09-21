using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Asteroid
{
    class Asteroid
    {
        private Texture2D asteroidSprite;
        private Vector2 asteroidPos;
        public Vector2 velocity;
        public Rectangle hitBox;
        public bool isDestroyed = false;

        private MouseState previousMouseState;
        private MouseState currentMouseState;

        public Asteroid(Texture2D asteroidSprite, Vector2 asteroidPos, Vector2 velocity, Rectangle hitBox)
        {
            this.asteroidSprite = asteroidSprite;
            this.asteroidPos = asteroidPos;
            this.velocity = velocity;
            this.hitBox = hitBox;
        }

        public void Update()
        {
            if (isDestroyed)
                return;

            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton != ButtonState.Pressed || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.RightTrigger))
            {
                if (hitBox.Contains(Mouse.GetState().Position))
                {
                    isDestroyed = true;
                }
            }

            asteroidPos += velocity;
            hitBox.Location = asteroidPos.ToPoint();
            if (asteroidPos.X > - asteroidSprite.Width || asteroidPos.Y >  - asteroidSprite.Height || asteroidPos.X < -100 || asteroidPos.Y < -100)
            {
                isDestroyed = true;
            }

        }

        public void Draw(SpriteBatch asteroidSpriteBatch)
        {
            //if (isDestroyed)
              //  return;
            asteroidSpriteBatch.Draw(asteroidSprite, asteroidPos, Color.White);
        }

        public void Displace(int direction)
        {
            asteroidPos.X += direction * 10;
            hitBox.X += direction * 10;
        }
    }
}