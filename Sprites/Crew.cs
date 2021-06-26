using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spymongus.Models;
using Spymongus.Sprites;
using System.Net.NetworkInformation;

namespace Spymongus.Sprites
{
    public class Crew : Sprite
    {

        private float scale = 0.4f;
        private static int playerCount { get; } = 6;
        public static int captainIndex { get; set; } = -1; // undefined
        public static int chiefIndex { get; set; } = -1; // undefined

        private Texture2D captainHatTexture;
        private Texture2D chiefHatTexture;
        private Sprite captainSprite;
        private Sprite chiefSprite;
        private Vector2 hatOrigin;
        public Crew(Texture2D texture, Texture2D captainHatTexture, Texture2D chiefHatTexture)
            : base(texture)
        {
            this.captainHatTexture = captainHatTexture;
            this.chiefHatTexture = chiefHatTexture;
            captainSprite = new Sprite(captainHatTexture);
            chiefSprite = new Sprite(chiefHatTexture);
            Origin = new Vector2(0, (int)_texture.Height);
            hatOrigin = new Vector2(0, 0);
            randomCaptainChief();
        }

        public void randomCaptainChief()
        {
            var rand = new Random();
            captainIndex = rand.Next(playerCount);
            chiefIndex = rand.Next(playerCount - 1);
            if (chiefIndex >= captainIndex)
            {
                chiefIndex++;
            }
        }

        private Vector2 getHatPosition(int index)
        {
            int x = index % 2;
            int y = index / 2;
            int startX = (int)((float)(_texture.Width / 2 - captainHatTexture.Width / 2 - 2 ) * scale);
            int stepX = (int)((float)(_texture.Width) * 0.225 * scale);
            int startY = (int)((float)(_texture.Height) * 0.11 * scale);
            int stepY = (int)((float)(_texture.Height) * 0.29 * scale);
            return new Vector2(Position.X + startX + x * stepX, Position.Y - _texture.Height * scale + startY + y * stepY);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
            {
                spriteBatch.Draw(_texture, Position, null, Color.White, _rotation, Origin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(captainHatTexture, getHatPosition(captainIndex), null, Color.White, _rotation, hatOrigin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(chiefHatTexture, getHatPosition(chiefIndex), null, Color.White, _rotation, hatOrigin, scale, SpriteEffects.None, 0);
            }
        }

    }
}
