using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Spymongus.Buttons;
using Spymongus.Sprites;

namespace Spymongus.State
{
    class GameState : State
    {
        private List<Buttons.Component> _components;
        private List<Sprites.Sprite> _sprite;

        private Texture2D bcGrd;
        private Texture2D displaymove;
        private Texture2D roundLabel;

        private Texture2D shipTexture;
        private Texture2D icebergTexture;
        private Texture2D defaultNode;

        public static int ScreenWidth;
        public static int ScreenHeight;

        //private SpriteBatch _sprites;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            bcGrd = _content.Load<Texture2D>("backGroundGame");

            var badButton = _content.Load<Texture2D>("Controls/ButtonBad");
            var goodButton = _content.Load<Texture2D>("Controls/ButtonGood");

            defaultNode = _content.Load<Texture2D>("DecisionNodes/DefaultDecision");

            shipTexture = _content.Load<Texture2D>("ship");
            icebergTexture = _content.Load<Texture2D>("iceberg");

            displaymove = _content.Load<Texture2D>("displayMove");

            roundLabel = _content.Load<Texture2D>("RoundLabel");

            var _font = _content.Load<SpriteFont>("Fonts/Font");

            var newBadButton = new ButtonGame(badButton, _font)
            {
                Position = new Vector2(635, 430),
            };

            newBadButton.Click += BadDecision_Click;

            var newGoodButton = new ButtonGame(goodButton, _font)
            {
                Position = new Vector2(520, 430),
            };

            newGoodButton.Click += GoodDecision_Click;

            _components = new List<Component>()
            {
                newBadButton,
                newGoodButton,
            };

            _sprite = new List<Sprite>()
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

            spriteBatch.Draw(roundLabel, new Rectangle(10, 10, 100, 35), Color.White);

            spriteBatch.Draw(displaymove, new Rectangle(25, 425, 750, 160), Color.White);
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }
    }
}
