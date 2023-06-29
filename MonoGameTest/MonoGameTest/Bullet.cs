using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MonoGameTest
{
    internal class Bullet
    {
        //FEEDBACK public Fields schrijf je met PascalCasing en ZONDER een underscore prefix "_"! 
        public Vector2 Position;
        public Texture2D Texture;
        public float Scale;
        private Rectangle? hitBox;
        public Rectangle HitBox
        {

            get
            {
                hitBox ??= new(0, 0, (int)(Texture.Width * Scale), (int)(Texture.Height * Scale));

                Rectangle rect = hitBox.Value;

                rect.X = (int)Position.X;
                rect.Y = (int)Position.Y;

                return rect;
            }

        }
        public List<Enemy> currentEnemies;
        public int Index;
        public float timer;
        public bool Remove;
        public Bullet(Vector2 pos, float scale, Texture2D texture, int index)
        {

            Position = pos;

            Scale = scale;

            Texture = texture;

            Index = index;

            currentEnemies = new List<Enemy>();

            Index = index;

            
        }

       
       
        

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(timer > 2)
            {
                Remove = true;
            }

            Position.Y -= 10;

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D pixel)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, HitBox, Color.White);
        }
    }
}
