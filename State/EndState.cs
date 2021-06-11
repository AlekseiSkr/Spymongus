using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spymongus.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spymongus.State
{
    class EndState : State
    {
        private List<Buttons.Component> _components;

        Texture2D UpperBoxTexture;
        Rectangle UpperBoxRectangle;

        Texture2D LowerBoxTexture;
        Rectangle LowerBoxRectangle;

        Texture2D BackgroundTexture;
        Rectangle BackgroundRectangle;

        int screenWidth = 800, screenHeight = 600;

        Buttons.Button btnToLobby;

        public EndState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            UpperBoxTexture = _content.Load<Texture2D>("Rectangle 10");
            UpperBoxRectangle = new Rectangle(200, 100, 400, 200);

            LowerBoxTexture = _content.Load<Texture2D>("Rectangle 11");
            LowerBoxRectangle = new Rectangle(200, 305, 400, 150);

            BackgroundTexture = _content.Load<Texture2D>("DEATH");
            BackgroundRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            btnToLobby = new Buttons.Button(_content.Load<Texture2D>("Rectangle 12"), _content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(200, 460),
                Text = "Back to Lobby",
            };

            btnToLobby.Click += btnToLobby_Click;

            var btnQuit = new Buttons.Button(_content.Load<Texture2D>("Rectangle 12"), _content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(405, 460),
                Text = "Host your lobby",
            };

            btnQuit.Click += btnQuit_Click;

            _components = new List<Buttons.Component>()
            {
                btnToLobby,
                btnQuit,
            };
        }

        public override void LoadContent()
        {

        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void btnToLobby_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var _backgroundColor = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackgroundTexture, BackgroundRectangle, Color.White);//Mainbackground
            spriteBatch.Draw(UpperBoxTexture, UpperBoxRectangle, Color.White);//UpperBox
            spriteBatch.Draw(LowerBoxTexture, LowerBoxRectangle, Color.White);//LowerBox
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }
    }
}
