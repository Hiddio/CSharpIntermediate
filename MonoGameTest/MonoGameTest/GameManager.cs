using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameTest
{
    internal class GameManager
    {
        public List<Enemy> currentEnemies;
        public List<Bullet> firedBullets;
        Player player;
        bool justFired;
        int bulletIndex;
        int enemyIndex;
        public GameManager()
        {
            currentEnemies = new List<Enemy>();
            firedBullets = new List<Bullet>();

            bulletIndex = 0;
            enemyIndex = 0;

        }

        public void CreateEnemy(Game1 gameOne, GraphicsDeviceManager graphics)
        {
            //FEEDBACK Stop dit blok code in een CreateEnemy() functie
            Random random = new Random();

            float scale = 0.05f;
            var tex = gameOne.Content.Load<Texture2D>("EnemyTexture");

            int spawnLocX = random.Next(0, graphics.PreferredBackBufferWidth - (int)(tex.Width * scale));
            int spawnLocY = 0 - (int)(tex.Height * scale);


            Vector2 pos = new Vector2(spawnLocX, spawnLocY);
            Enemy newEnemy = new Enemy(pos, scale, tex, enemyIndex);


            currentEnemies.Add(newEnemy);
            enemyIndex++;
            foreach (Bullet bullet in firedBullets)
            {
                bullet.currentEnemies.Add(newEnemy);
            }
            //FEEDBACK end CreateEnemy() functie
        }

        public void CreateBullet(Game1 gameOne, Player player)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && justFired == false || GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed && justFired == false)
            {
                justFired = true;

                Bullet newBullet = new Bullet(player.Position - (new Vector2(player.ShipTexture.Width / 2, player.ShipTexture.Height / 2)), 2f, gameOne.Content.Load<Texture2D>("BulletTexture"), bulletIndex);

                

                firedBullets.Add(newBullet);
                bulletIndex++;
            }



        }

        public void CheckPlayerShoot(Game1 gameOne)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && justFired == false || GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed && justFired == false)
            {
                justFired = true;

            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space) && GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Released)
            {
                justFired = false;
            }

        }

        public void Update(Game1 gameOne, Player player, GameTime gameTime)
        {
            CreateBullet(gameOne, player);
            CheckPlayerShoot(gameOne);

            for (int i = firedBullets.Count - 1; i >= 0; i--)
            {
                Bullet bullet = firedBullets[i];
                bullet.Update(gameTime);

                if (firedBullets[i].Remove)
                {

                    firedBullets.RemoveAt(i);
                    

                }
                for (int j = currentEnemies.Count - 1; j >= 0; j--)
                {

                    if (bullet.HitBox.Intersects(currentEnemies[j].HitBox))
                    {
                        Console.WriteLine($"Bullet hit enemy: {j}");
                        Console.WriteLine(i);
                        firedBullets[i].Remove = true;
                        currentEnemies[j].Remove = true;

                    }
                }
                
            }
            for (int j = currentEnemies.Count - 1; j >= 0; j--)
            {
                Enemy enemy = currentEnemies[j];
                enemy.Update(gameTime);
                if (currentEnemies[j].Remove)
                {

                    currentEnemies.RemoveAt(j);


                }
            }


            CollisionManager();

        }

        public void CollisionManager()
        {
           

            //foreach(Bullet bullet in firedBullets)
            //{
                
            //    foreach (Enemy enemy in currentEnemies)
            //    {
            //        if (bullet.HitBox.Intersects(enemy.HitBox))
            //        {
            //            Console.WriteLine($"Bullet hit enemy: {enemy.Index}");
            //            Console.WriteLine(bullet.Index);
            //            firedBullets.RemoveAt(bullet.Index);
                        
            //        }
            //    }

            //}
        }

       


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D pixel)
        {

            foreach (Enemy enemy in currentEnemies)
            {
                enemy.Draw(gameTime, spriteBatch, pixel);
            }

            foreach (Bullet bullet in firedBullets)
            {
                bullet.Draw(gameTime, spriteBatch, pixel);

            }

        }

    }
}
