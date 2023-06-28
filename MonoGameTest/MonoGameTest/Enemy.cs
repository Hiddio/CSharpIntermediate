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
        public int Index;
        public Enemy(Vector2 pos, float scale, Texture2D enemyTexture, int index)
        {
            Position = pos;
            Scale = scale;
            EnemyTexture = enemyTexture;
            Index = index;

            HitBox = new Rectangle((int)Position.X, (int)Position.Y, EnemyTexture.Width / 20, EnemyTexture.Height / 20);
            
        }

        //FEEDBACK Methods schrijf je ALTIJD met PascalCasing
        public void SetHitbox()
        {
            
        }

        public void Update()
        {
            Position.Y += 10;
            HitBox.X = (int)Position.X;
            HitBox.Y = (int)Position.Y;

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D pixel)
        {
            spriteBatch.Draw(EnemyTexture, Position, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, HitBox, Color.White);
        }
    }
}
