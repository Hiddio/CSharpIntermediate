using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MonoGameTest
{
    internal class Bullet
    {
        //FEEDBACK public Fields schrijf je met PascalCasing en ZONDER een underscore prefix "_"! 
        Vector2 position;
        Texture2D texture;
        float scale;
        Rectangle? hitBox;
        public Rectangle HitBox
        {

            get
            {
                hitBox ??= new(0, 0, (int)(texture.Width * scale), (int)(texture.Height * scale));

                Rectangle rect = hitBox.Value;

                rect.X = (int)position.X;
                rect.Y = (int)position.Y;

                return rect;
            }
        }

        public List<Enemy> currentEnemies;
        float timer;
        public bool Remove;
        public Bullet(Vector2 pos, float scale, Texture2D texture)
        {
            position = pos;
            this.scale = scale;
            this.texture = texture;
            currentEnemies = new List<Enemy>();
        }
        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(timer > 2)
            {
                Remove = true;
            }
            position.Y -= 10;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}
