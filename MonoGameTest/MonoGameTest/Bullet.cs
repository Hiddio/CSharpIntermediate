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
        public Rectangle HitBox;
        public List<Enemy> currentEnemies;
        public Bullet(Vector2 pos, float scale, Texture2D texture)
        {
            Console.WriteLine("BAM!");

            Position = pos;

            Scale = scale;

            Texture = texture;

            SetHitbox();
        }

        public void SetHitbox()
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public void EnemyCollision()
        {
            foreach (Enemy enemy in currentEnemies)
            {
                if (enemy.HitBox.Contains(this.HitBox))
                {

                }
            }
        }

        public void Update()
        {
            //FEEDBACK Ik raad je aan om de Bullet een richting (direction) te geven i.p.v. deze boolean
            //FEEDBACK Voor de Player kun je dan new Vector2(0,-10) gebruiken en voor de Enemy new Vector2(0,10)
            //FEEDBACK Het mooiste is om dit aan de constructor toe te voegen

            //FEEDBACK Op deze manier kun je de Bullet class makkelijker in verschillende scenarios gebruiken
            //FEEDBACK Dan staat de Bullet class los van de Player class en de Enemy class


            Position.Y -= 10;
            // edit, weggehaald "enemy bool check" voor else als enemy bullet schoot

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }
    }
}
