using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoGameTest
{
    internal class Bullet
    {
        public Vector2 _position;
        public Texture2D _texture;
        public float _scale;

        public Bullet(Vector2 pos, float scale)
        {
           _position = pos;
           _scale = scale;
        }

        public void UpdateBullet(bool enemy)
        {
            if(enemy == true)
            {
                _position.Y += 10;
            }
            else
            {
                _position.Y -= 10;
            }
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, Color.White, 0, Vector2.Zero, _scale, SpriteEffects.None, 0);
        }
    }
}
