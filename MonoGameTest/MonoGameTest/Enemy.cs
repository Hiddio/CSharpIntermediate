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
        public Vector2 Position;
        public Texture2D EnemyTexture;
        public float Scale;

        // backing field
        private Rectangle? hitbox;
        // public hitbox property
        public Rectangle HitBox
        {
            // only has getter, it cannot be set to a value from anywhere
            get
            {
                // if the backing field is null, then we set it to a new Rectangle with the correct scale.
                hitbox ??= new(0, 0, (int)(EnemyTexture.Width * Scale), (int)(EnemyTexture.Height * Scale));
                // be cause the backingfield is nullable, we get the value cuz struct will be of type Nullable<Rectangle>
                Rectangle rect = hitbox.Value;
                // set the position of the hitbox according to the objects position
                rect.X = (int)Position.X;
                rect.Y = (int)Position.Y;
                // return the final hitbox
                return rect;
            }
        }

        public float timer;
        public bool Remove;

        public Enemy(Vector2 pos, float scale, Texture2D enemyTexture)
        {
            Position = pos;
            Scale = scale;
            EnemyTexture = enemyTexture;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > 2)
            {
                Remove = true;
            }
            Position.Y += 10;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D pixel)
        {
            spriteBatch.Draw(EnemyTexture, Position, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, HitBox, Color.White);
        }
    }
}
