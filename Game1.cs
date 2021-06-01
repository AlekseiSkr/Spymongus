using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spymongus.Models;
using Spymongus.Sprites;
using Spymongus.Buttons;
using System.Collections.Generic;

namespace Spymongus
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D backGroundImage;
        private Texture2D icebergTexture;


        public static int ScreenWidth;
        public static int ScreenHeight;

        private List<Sprite> _sprites;
        private List<Component> _gameComponents;

        private bool _hasStarted = false;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            this.Window.AllowUserResizing = true;
            this.Window.Title = "Spy!Mongus SUS";
            ScreenHeight = this.Window.ClientBounds.Height;
            ScreenWidth = this.Window.ClientBounds.Width;
            //ScreenHeight = _graphics.PreferredBackBufferHeight;
            //ScreenWidth = _graphics.PreferredBackBufferWidth;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            var shipTexture = Content.Load<Texture2D>("ship");
            icebergTexture = Content.Load<Texture2D>("iceberg");

            //button 1 initiation
            var goodMove = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(ScreenWidth / 2, ScreenHeight / 4),
                Text = "Good Decision"
            };
            
            //button 2 initiation
            var badMove = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(ScreenWidth / 2, (ScreenHeight / 4) + 100),
                Text = "Bad Decision"
            };

            //buttons added to list
            _gameComponents = new List<Component>()
            {
                goodMove,
                badMove,
            };
            
            _sprites = new List<Sprite>()
            {
                //new Ship Sprite
                new Ship(shipTexture)
                {
                    Position = new Vector2(ScreenWidth / 5, ScreenHeight / 2),
                    Origin = new Vector2(shipTexture.Width/2, (int)shipTexture.Height/ 2),
                },

                //new Iceberg Sprite
                new Iceberg(icebergTexture)
                {
                    Position = new Vector2(ScreenWidth, (ScreenHeight / 2 ) - icebergTexture.Height / 2),
                    startPos = new Vector2(ScreenWidth, (ScreenHeight / 2 ) - icebergTexture.Height / 2),
                }
            };
        }

        private void GoodMove_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void BadMove_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);

            foreach (var component in _gameComponents)
                component.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            foreach (var sprite in _sprites)
                sprite.Draw(_spriteBatch);


            foreach (var component in _gameComponents)
                component.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DeleteSprites(Sprite sprite)
        {
            _sprites.Remove(sprite);
        }

        //spawn an iceberg texture sprite
        private void SpawnIceberg()
        {
            _sprites.Add(new Iceberg(icebergTexture)
            {
                Position = new Vector2(ScreenWidth, (ScreenHeight / 2) - icebergTexture.Height / 2)
            });
        }
    }
}
