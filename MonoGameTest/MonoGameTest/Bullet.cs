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
        //FEEDBACK public Fields schrijf je met PascalCasing en ZONDER een underscore prefix "_"! 
        public Vector2 Position;
        public Texture2D Texture;
        public float Scale;
        Rectangle hitBox;

        public Bullet(Vector2 pos, float scale, Texture2D texture)
        {
           Position = pos;
           Scale = scale;
            Texture = texture;
        }

        public void SetHitbox()
        {
            hitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public void UpdateBullet(bool enemy)
        {
            //FEEDBACK Ik raad je aan om de Bullet een richting (direction) te geven i.p.v. deze boolean
            //FEEDBACK Voor de Player kun je dan new Vector2(0,-10) gebruiken en voor de Enemy new Vector2(0,10)
            //FEEDBACK Het mooiste is om dit aan de constructor toe te voegen
            
            //FEEDBACK Op deze manier kun je de Bullet class makkelijker in verschillende scenarios gebruiken
            //FEEDBACK Dan staat de Bullet class los van de Player class en de Enemy class
            if(enemy == true)
            {
                Position.Y += 10;
            }
            else
            {
                Position.Y -= 10;
            }
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }
    }
}
