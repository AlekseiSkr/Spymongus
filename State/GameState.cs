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
        private List<Buttons.Component> _crewButtons;
        private List<Sprites.Sprite> _sprite;

        private Texture2D bcGrd;
        private Texture2D displaymove;
        private Texture2D roundLabel;

        private Texture2D shipTexture;
        private Texture2D icebergTexture;

        private Texture2D defaultNode;
        private Texture2D endNode;

        private Texture2D crewBox;
        private Texture2D crewTexture;

        public static int ScreenWidth = 800;
        public static int ScreenHeight = 600;

        //private SpriteBatch _sprites;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            bcGrd = _content.Load<Texture2D>("backGroundGame");

            crewBox = _content.Load<Texture2D>("Controls/Group 38");
            crewTexture = _content.Load<Texture2D>("Controls/sailor");

            var badButton = _content.Load<Texture2D>("Controls/ButtonBad");
            var goodButton = _content.Load<Texture2D>("Controls/ButtonGood");

            defaultNode = _content.Load<Texture2D>("DecisionNodes/DefaultDecision");
            endNode = _content.Load<Texture2D>("DecisionNodes/endNode");

            shipTexture = _content.Load<Texture2D>("ship");
            icebergTexture = _content.Load<Texture2D>("iceberg");

            displaymove = _content.Load<Texture2D>("displayMove");

            roundLabel = _content.Load<Texture2D>("RoundLabel");

            var _font = _content.Load<SpriteFont>("Fonts/Font");

            var crewButton1 = new ButtonCrew(crewTexture, _font)
            {
                Position = new Vector2(55, 430),
                Text = "Bot1",
            };
            crewButton1.Click += crewButton1_Click;

            var crewButton2 = new ButtonCrew(crewTexture, _font)
            {
                Position = new Vector2(100, 430),
                Text = "Bot2",
            };
            crewButton2.Click += crewButton2_Click;

            var crewButton3 = new ButtonCrew(crewTexture, _font)
            {
                Position = new Vector2(100, 475),
                Text = "Bot3",
            };
            crewButton3.Click += crewButton3_Click;

            var crewButton4 = new ButtonCrew(crewTexture, _font)
            {
                Position = new Vector2(100, 520),
                Text = "Bot4",
            };
            crewButton4.Click += crewButton4_Click;

            var crewButton5 = new ButtonCrew(crewTexture, _font)
            {
                Position = new Vector2(55, 520),
                Text = "Bot5",
            };
            crewButton5.Click += crewButton5_Click;

            var crewButton6 = new ButtonCrew(crewTexture, _font)
            {
                Position = new Vector2(55, 475),
                Text = "Bot6",
            };
            crewButton6.Click += crewButton6_Click;

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

            _crewButtons = new List<Component>()
            {
                crewButton1,
                crewButton2,
                crewButton3,
                crewButton4,
                crewButton5,
                crewButton6,
            };

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
                    Position = new Vector2(ScreenWidth/5, ScreenHeight/2),
                    Origin = new Vector2(shipTexture.Width/2, shipTexture.Height/ 2),
                },

                //new Iceberg Sprite
                new Iceberg(icebergTexture)
                {
                    Position = new Vector2(ScreenWidth, (ScreenHeight / 2 ) - icebergTexture.Height / 2),
                    startPos = new Vector2(ScreenWidth, (ScreenHeight / 2 ) - icebergTexture.Height / 2),
                },

                new Node(defaultNode)
                {
                    Position = new Vector2( 225, 440),
                },

                new Node(endNode)
                {
                    Position = new Vector2( 275, 440),
                    
                }
            };
        }

        private void crewButton1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        private void crewButton2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        private void crewButton3_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        private void crewButton4_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void crewButton5_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        private void crewButton6_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
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
            foreach (var sprite in _sprite)
                sprite.Update(gameTime, _sprite);

            foreach (var component in _components)
                component.Update(gameTime);

            foreach (var crewButtons in _crewButtons)
                crewButtons.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bcGrd, new Rectangle(-4, -5, 810, 610), Color.White);

            spriteBatch.Draw(roundLabel, new Rectangle(10, 10, 100, 35), Color.White);

            spriteBatch.Draw(displaymove, new Rectangle(160, 415, 625, 170), Color.White);

            spriteBatch.Draw(crewBox, new Rectangle(1, 415, 165, 170), Color.White);

            foreach (var sprite in _sprite)
            {
                sprite.Draw(gameTime, spriteBatch);
            }

            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            foreach (var crewButtons in _crewButtons) 
            {
                crewButtons.Draw(gameTime, spriteBatch);
            }
        }
    }
}
