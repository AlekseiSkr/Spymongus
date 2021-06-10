using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Spymongus.Buttons;

namespace Spymongus.State
{
    class GameState : State
    {
        private List<Buttons.Component> _components;
        private Texture2D bcGrd;
        private Texture2D displaymove;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            bcGrd = _content.Load<Texture2D>("backGroundGame");

            var badButton = _content.Load<Texture2D>("Controls/ButtonBad");
            var goodButton = _content.Load<Texture2D>("Controls/ButtonGood");

            var ballTexture = _content.Load<Texture2D>("ship");

            displaymove = _content.Load<Texture2D>("displayMove");

            var roundLabel = _content.Load<Texture2D>("RoundLabel");

            var _font = _content.Load<SpriteFont>("Fonts/Font");

            var newBadButton = new ButtonGame(badButton, _font)
            {
                Position = new Vector2(635, 430),
                Text = "Bad Button",
            };

            newBadButton.Click += BadDecision_Click;

            var newGoodButton = new ButtonGame(goodButton, _font)
            {
                Position = new Vector2(520, 430),
                Text = "Good Button",
            };

            newGoodButton.Click += GoodDecision_Click;

            _components = new List<Component>()
            {
                newBadButton,
                newGoodButton,
            };
        }

        private void BadDecision_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void GoodDecision_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public override void LoadContent()
        {
            //throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bcGrd, new Rectangle(-4, -5, 810, 610), Color.White);

            spriteBatch.Draw(displaymove, new Rectangle(25, 425, 750, 160), Color.White);
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }
    }
}
