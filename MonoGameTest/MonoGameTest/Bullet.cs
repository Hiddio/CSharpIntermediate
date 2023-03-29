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
            //FEEDBACK Ik raad je aan om de Bullet een richting (direction) te geven i.p.v. deze boolean
            //FEEDBACK Voor de Player kun je dan new Vector2(0,-10) gebruiken en voor de Enemy new Vector2(0,10)
            //FEEDBACK Het mooiste is om dit aan de constructor toe te voegen
            
            //FEEDBACK Op deze manier kun je de Bullet class makkelijker in verschillende scenarios gebruiken
            //FEEDBACK Dan staat de Bullet class los van de Player class en de Enemy class
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
