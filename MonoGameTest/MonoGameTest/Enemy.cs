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
        public bool Remove;

        Vector2 position;
        Texture2D enemyTexture;
        float scale;
        // backing field
        float timer;
        Rectangle? hitbox;
        // public hitbox property
        public Rectangle HitBox
        {
            // only has getter, it cannot be set to a value from anywhere
            get
            {
                // if the backing field is null, then we set it to a new Rectangle with the correct scale.
                hitbox ??= new(0, 0, (int)(enemyTexture.Width * scale), (int)(enemyTexture.Height * scale));
                // be cause the backingfield is nullable, we get the value cuz struct will be of type Nullable<Rectangle>
                Rectangle rect = hitbox.Value;
                // set the position of the hitbox according to the objects position
                rect.X = (int)position.X;
                rect.Y = (int)position.Y;
                // return the final hitbox
                return rect;
            }
        }


        public Enemy(Vector2 pos, float scale, Texture2D enemyTexture)
        {
            position = pos;
            this.scale = scale;
            this.enemyTexture = enemyTexture;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > 2)
            {
                Remove = true;
            }
            position.Y += 10;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, position, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}
