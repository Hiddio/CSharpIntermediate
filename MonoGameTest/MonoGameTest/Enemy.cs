using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameTest
{
    internal class Enemy
    {
        public Vector2 _position;
        public Texture2D _enemyTexture;
        public float _scale;
        Rectangle hitBox;

        
        public Enemy(Vector2 pos, float scale)
        {
            _position = pos;
            _scale = scale;
            hitBox = new Rectangle((int)_position.X, (int)_position.Y, _enemyTexture.Width, _enemyTexture.Height);
        }

        public void Spawn()
        {

        }

        public void Update()
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_enemyTexture, _position, null, Color.White, 0, Vector2.Zero, _scale, SpriteEffects.None, 0);
        }
    }
}
