using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Asteroird_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public Texture2D AsteroidTex;
        Texture2D Space;
        Vector2 pos1 = new Vector2(0, -5);
        Vector2 pos;
        Vector2 velocity;
        int width;

        Spacecraft[] Spacecrafts;  

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Spacecrafts = new Spacecraft[4];
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Array För spacecrafts
            Spacecrafts[0] = new Spacecraft(Content.Load<Texture2D>("spaceCraft_trans"), new Rectangle(500, 203, 120, 120));
            Spacecrafts[1] = new Spacecraft(Content.Load<Texture2D>("spaceCraft_trans"), new Rectangle(64, 120, 120, 120));
            Spacecrafts[2] = new Spacecraft(Content.Load<Texture2D>("spaceCraft_trans"), new Rectangle(350, 200, 64, 64));
            Spacecrafts[3] = new Spacecraft(Content.Load<Texture2D>("spaceCraft_trans"), new Rectangle(300, 30, 64, 64));

            AsteroidTex = Content.Load<Texture2D>("Asteroid");
            velocity = new Vector2(2, 1);
            pos = new Vector2(0, 0);
            width = Window.ClientBounds.Width;

            Vector2 pos2 = Vector2.Zero;
            Vector2 velocity2 = new Vector2(1, 3);
            Asteroid = new Asteroid(AsteroidTex, pos, velocity2);
            Space = Content.Load<Texture2D>("Space2");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            pos = pos + velocity;

            if (pos.X < 0 || pos.X > width - AsteroidTex.Width)
            {
                velocity = velocity * -1;
            }
            // TODO: Add your update logic here
            Asteroid.update();
            base.Update(gameTime);
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
