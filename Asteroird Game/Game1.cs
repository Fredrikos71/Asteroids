using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        Vector2 AsteroidsPosition;
        Vector2 Asteroidvelocity;
        Rectangle AsteroidRect;

        Texture2D Space; 
        Vector2 pos1 = new Vector2(0, 0);
        private Vector2 pos;

        //crossair
        Texture2D crosshairTexture;
        Rectangle crosshairRect;
        Vector2 crosshairPosition;
        // Vector2 crosshairVelocity;

        //add scorce
        int score;

        Random rand = new Random();

        Random myRandom = new Random();

        int width;
        Asteroid Asteroid;
         
        Spacecraft[] Spacecrafts;  

        public Game1()
        {
            Window.Title = "Asteroids";
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {

            score = 0;

            crosshairPosition.X = 400.0f;
            crosshairPosition.Y = 400.0f;
            crosshairRect = new Rectangle(400, 400, 32, 32);


                // Windownds screen
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 700;
            graphics.ApplyChanges();
            Window.AllowUserResizing= true;



            AsteroidRect = new Rectangle(600, 600, 64, 64);
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
            Spacecrafts[4] = new Spacecraft(Content.Load<Texture2D>("spaceCraft_trans"), new Rectangle(100, 400 , 64 , 64));

            AsteroidTex = Content.Load<Texture2D>("Asteroid");
            RandomVel();
            pos = new Vector2(960,540);
            width = Window.ClientBounds.Width;


            crosshairTexture = Content.Load<Texture2D>("crosshair");

            Vector2 pos2 = Vector2.Zero;
            pos2 = new Vector2(700, 540);
            RandomVel();
            Asteroid = new Asteroid(AsteroidTex, pos2, Asteroidvelocity);
            Space = Content.Load<Texture2D>("Rymden");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            //mouse crosshair 
            crosshairPosition.X = Mouse.GetState().X;
            crosshairPosition.Y = Mouse.GetState().Y;

            crosshairRect.X = (int)crosshairPosition.X;
            crosshairRect.Y = (int)crosshairPosition.Y;

            AsteroidRect.X = (int)AsteroidsPosition.X;
            AsteroidRect.Y = (int)AsteroidsPosition.Y;
            
            
            //mouse click

            if (crosshairRect.Intersects(AsteroidRect))
            {
                AsteroidsPosition.X = rand.Next(300, 500);
                AsteroidsPosition.Y = rand.Next(200, 600);

                score += 10;
            }


           /* if(AsteroidsPosition.X > graphics.GraphicsDevice.Viewport.Width)
            {
                Asteroidvelocity.X *= -1;
            }
            if (AsteroidsPosition.Y > graphics.GraphicsDevice.Viewport.Height)
            {
                Asteroidvelocity.Y *= -1;
            }
           */
            mouse = Mouse.GetState();
            //if (mouse.LeftButton == ButtonState.Pressed)
            {
                
            }
            /*
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) Keyboard.GetState().IsKeyDown(Keys.Escape);
                    Exit();
            */ 
            
            mouse = Mouse.GetState();

            pos = pos + Asteroidvelocity;

            // if (pos.X < 0 || pos.X > width - AsteroidTex.Width)
            {
                //Asteroidvelocity = Asteroidvelocity * -1;
            }
            
                // TODO: Add your update logic here
                Asteroid.update();
                base.Update(gameTime);
        }

        void RandomVel()
        {
            Asteroidvelocity = Vector2.Zero;
            while (Asteroidvelocity == Vector2.Zero)
            {
                Asteroidvelocity.X = myRandom.Next(-3, 4);
                Asteroidvelocity.Y = myRandom.Next(-3, 4);
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
            spriteBatch.Draw(crosshairTexture, crosshairRect, Color.Red);

            Window.Title = "Asteroid Game" + "  Score " + score;
            spriteBatch.End();

            // TODO: Add your drawing code here'

            base.Draw(gameTime);
        }
    }
}
