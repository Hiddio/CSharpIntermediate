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
        public float Scale;
        Rectangle hitBox;
        public Enemy(Vector2 pos, float scale, Texture2D enemyTexture)
        {
            Position = pos;
            Scale = scale;
            EnemyTexture = enemyTexture;
            //FEEDBACK je error komt doordat je in setHitbox() de EnemyTexture gebruikt. Die is op dit moment (in de constructor) nog null
            
            //FEEDBACK Dit staat in je Game1 class:
            //FEEDBACK      Enemy newEnemy = new Enemy(pos, 1); <= hier gebruik je dus al setHitbox en gebruik je al EnemyTexture
            //FEEDBACK      newEnemy.EnemyTexture = Content.Load<Texture2D>("EnemyTexture"); <= terwijl hij hier pas gezet wordt
            SetHitbox();
        }
        
        //FEEDBACK Methods schrijf je ALTIJD met PascalCasing
        public void SetHitbox()
        {
            hitBox = new Rectangle((int)Position.X, (int)Position.Y, EnemyTexture.Width, EnemyTexture.Height);
        }


        //FEEDBACK Ik denk niet dat je een Spawn() functie nodig hebt... Als je een Enemy instance maakt wordt de Constructor aangeroepen
        //FEEDBACK Als je in de Game1 class het volgende doet: "Enemy newEnemy = new Enemy(...)" Dan maak je een nieuwe Enemy instance aan
        //FEEDBACK en "Spawned" hij als het ware al...
        public void Spawn()
        {

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
