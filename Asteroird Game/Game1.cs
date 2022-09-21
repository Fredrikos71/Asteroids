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
    public class Game1 : Game
    {

        MouseState mouse;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public Texture2D AsteroidTex;
        Rectangle AsteroidRectangle = new Rectangle(100, 100, 100, 100);
        Texture2D Space;
        Vector2 pos1 = new Vector2(0, 0);
        Vector2 pos;
        Vector2 velocity;

        Random myRandom = new Random();

        int width;
        Asteroid Asteroid;

        Spacecraft[] Spacecrafts;  

        public Game1()
        {
            Window.Title = "Asteroids";
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Windownds screen
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 700;
            graphics.ApplyChanges();
            Window.AllowUserResizing= true;

            // Fullscreen
            /*
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            */

            Spacecrafts = new Spacecraft[5];
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //Array För spacecrafts
            Spacecrafts[0] = new Spacecraft(Content.Load<Texture2D>("spaceCraft_trans"), new Rectangle(500, 203, 180, 180));
            Spacecrafts[1] = new Spacecraft(Content.Load<Texture2D>("spaceCraft_trans"), new Rectangle(200, 500, 120, 120));
            Spacecrafts[2] = new Spacecraft(Content.Load<Texture2D>("spaceCraft_trans"), new Rectangle(1200, 200, 120, 120));
            Spacecrafts[3] = new Spacecraft(Content.Load<Texture2D>("spaceCraft_trans"), new Rectangle(1000, 500, 64, 64));
            Spacecrafts[4] = new Spacecraft(Content.Load<Texture2D>("spaceCraft_trans"), new Rectangle(1400, 400 , 64 , 64));

            AsteroidTex = Content.Load<Texture2D>("Asteroid");
            RandomVel();
            pos = new Vector2(960,540);
           width = Window.ClientBounds.Width;

            Vector2 pos2 = Vector2.Zero;
            pos2 = new Vector2(700, 540);
            RandomVel();
            Asteroid = new Asteroid(AsteroidTex, pos2, velocity);
            Space = Content.Load<Texture2D>("Rymden");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState();
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                
            }
            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) Keyboard.GetState().IsKeyDown(Keys.Escape);
                    Exit();
            */ mouse = Mouse.GetState();

            pos = pos + velocity;

            /* if (pos.X < 0 || pos.X > width - AsteroidTex.Width)
            {
               // velocity = velocity * -1;
            }
            */
                // TODO: Add your update logic here
                Asteroid.update();
                base.Update(gameTime);
        }

        void RandomVel()
        {
            velocity = Vector2.Zero;
            while (velocity == Vector2.Zero)
            {
                velocity.X = myRandom.Next(-3, 4);
                velocity.Y = myRandom.Next(-3, 4);
            }

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(Space, pos1, Color.White);
            foreach (Spacecraft Spacecrafts in Spacecrafts)
                Spacecrafts.Draw(spriteBatch);
            spriteBatch.Draw(AsteroidTex, pos, Color.White);
            Asteroid.Draw(spriteBatch);
            spriteBatch.End();

            // TODO: Add your drawing code here'

            base.Draw(gameTime);
        }
    }
}
