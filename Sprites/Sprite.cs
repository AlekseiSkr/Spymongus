using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spymongus.Models;

namespace Spymongus.Sprites
{
    public class Sprite
    {
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;

        public Vector2 Origin;
        public Vector2 Position;


        public Color Color = Color.White;

        public float Speed = 0f;
        protected float _rotation;

        public bool isRemoved = false;

        public Input Input;

        public Texture2D _texture;

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
            {
                spriteBatch.Draw(_texture, Position, null, Color.White, _rotation, Origin, 1, SpriteEffects.None, 0);
            }
        }
    }
}
