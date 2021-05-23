using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spymongus.Models;
using Spymongus.Sprites;

namespace Spymongus.Sprites
{
    class Iceberg : Sprite
    {
        public bool HasPassedScreen = false;
        public bool HasHitShip = false;
        public Vector2 startPos;

        public Iceberg(Texture2D texture) : base(texture)
        {
            Speed = 10f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();
            
            if (HasPassedScreen)
            {
                return;
            }
        }

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.I))
            {
                Position.X -= Speed;
                if (Position.X < -200)
                {
                    HasPassedScreen = true;
                    Position = startPos;
                }
            }
        }
    }
}
