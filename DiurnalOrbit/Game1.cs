using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Runtime.CompilerServices;

namespace DiurnalOrbit
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Ship ship;
        private Texture2D shipTexture;

        private AsteroidManager am;
        private Texture2D asteroidTexture;

        private SpriteFont verdana;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            verdana = this.Content.Load<SpriteFont>("Verdana24");

            shipTexture = this.Content.Load<Texture2D>("Ship");

            ship = new Ship(shipTexture, 0.25f, 
                new Vector2(_graphics.PreferredBackBufferWidth/2, _graphics.PreferredBackBufferHeight/2), 
                150, 0, 5f, 5f);

            asteroidTexture = this.Content.Load<Texture2D>("Asteroid");

            am = new AsteroidManager(asteroidTexture);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            ship.Update(gameTime);
            am.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            ship.Draw(_spriteBatch);
            am.Draw(_spriteBatch);

            _spriteBatch.DrawString(verdana, $"{ship.Radius}", new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
