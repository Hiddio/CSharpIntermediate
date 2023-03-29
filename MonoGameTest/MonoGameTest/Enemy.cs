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

        public Vector2 _position;
        public Texture2D _enemyTexture;
        public float _scale;
        Rectangle hitBox;
        public Enemy(Vector2 pos, float scale)
        {
            _position = pos;
            _scale = scale;

            //FEEDBACK je error komt doordat je in setHitbox() de _enemyTexture gebruikt. Die is op dit moment (in de constructor) nog null
            
            //FEEDBACK Dit staat in je Game1 class:
            //FEEDBACK      Enemy newEnemy = new Enemy(pos, 1); <= hier gebruik je dus al setHitbox en gebruik je al _enemyTexture
            //FEEDBACK      newEnemy._enemyTexture = Content.Load<Texture2D>("EnemyTexture"); <= terwijl hij hier pas gezet wordt
            setHitbox();
        }
        
        //FEEDBACK Methods schrijf je ALTIJD met PascalCasing
        public void setHitbox()
        {
            hitBox = new Rectangle((int)_position.X, (int)_position.Y, _enemyTexture.Width, _enemyTexture.Height);
        }


        //FEEDBACK Ik denk niet dat je een Spawn() functie nodig hebt... Als je een Enemy instance maakt wordt de Constructor aangeroepen
        //FEEDBACK Als je in de Game1 class het volgende doet: "Enemy newEnemy = new Enemy(...)" Dan maak je een nieuwe Enemy instance aan
        //FEEDBACK en "Spawned" hij als het ware al...
        public void Spawn()
        {

        }
        public void Update()
        {
            _position.Y -= 10;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_enemyTexture, _position, null, Color.White, 0, Vector2.Zero, _scale, SpriteEffects.None, 0);
        }
    }
}
