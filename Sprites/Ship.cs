using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spymongus.Models;
using Spymongus.Sprites;

namespace Spymongus.Sprites
{
    public class Ship : Sprite
    {
        public bool HasSunk = false;
        public int Health { get; set; }

        public bool isSunk
        {
            get
            {
                return Health <= 0;
            }
        }

        public Ship(Texture2D texture) 
            : base(texture) 
        {
            Speed = 5f;
        }

        public override void Update (GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            if (isSunk)
            {
                return;
            }

            foreach (var sprite in sprites)
            {
                if (sprite is Ship)
                    continue;

                if (sprite.Rectangle.Intersects
                    (this.Rectangle))
                {
                    Health -= 20;
                    //DamageAnimation = true or DamageAnimation(); TBR
                }
            }
        }

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Position.Y += 4;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Position.Y -= 4;
            }
        }
    }
}
