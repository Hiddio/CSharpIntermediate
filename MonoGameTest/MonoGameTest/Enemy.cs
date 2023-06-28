using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameTest
{
    internal class Enemy
    {
        //FEEDBACK public Fields schrijf je met PascalCasing en ZONDER een underscore prefix "_"! 

        public Vector2 Position;
        public Texture2D EnemyTexture;
        float Scale;
        public Rectangle HitBox;
        public Enemy(Vector2 pos, float scale, Texture2D enemyTexture)
        {
            Position = pos;
            Scale = scale;
            EnemyTexture = enemyTexture;

            SetHitbox();
        }

        //FEEDBACK Methods schrijf je ALTIJD met PascalCasing
        public void SetHitbox()
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, EnemyTexture.Width, EnemyTexture.Height);
        }

        public void Update()
        {
            Position.Y += 10;

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(EnemyTexture, Position, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }
    }
}
