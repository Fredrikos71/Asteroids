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
        Vector2 pos1 = new Vector2(100, -5);
        Vector2 pos;
        Vector2 velocity;
        int width;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            AsteroidTex = Content.Load<Texture2D>("Asteroid");
            velocity = new Vector2(2, 0);
            pos = new Vector2(0, 0);
            width = Window.ClientBounds.Width;

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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(Space, pos1, Color.White);
            spriteBatch.Draw(AsteroidTex, pos, Color.White);
            spriteBatch.End();

            // TODO: Add your drawing code here'

            base.Draw(gameTime);
        }
    }
}
