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
        bool justFired;
        float totalTime;
        float timerTime = 5f;
        float addedTime = 5f;
        
        public GameManager()
        {
            currentEnemies = new List<Enemy>();
            firedBullets = new List<Bullet>();
        }

        public void CreateEnemy(Game1 gameOne, GraphicsDeviceManager graphics, GameTime gameTime)
        {
            totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (totalTime >= timerTime)
            {
                Random random = new Random();

                float scale = 0.05f;
                var tex = gameOne.Content.Load<Texture2D>("EnemyTexture");

                int spawnLocX = random.Next(0, graphics.PreferredBackBufferWidth - (int)(tex.Width * scale));
                int spawnLocY = 0 - (int)(tex.Height * scale);


                Vector2 pos = new Vector2(spawnLocX, spawnLocY);
                Enemy newEnemy = new Enemy(pos, scale, tex);


                currentEnemies.Add(newEnemy);

                foreach (Bullet bullet in firedBullets)
                {
                    bullet.currentEnemies.Add(newEnemy);
                }
                

                if (addedTime > 1)
                {
                    addedTime--;
                }

                timerTime = totalTime + addedTime;
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
        }

        public void CreateBullet(Game1 gameOne, Player player, GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && justFired == false || GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed && justFired == false)
            {
                justFired = true;

                Bullet newBullet = new Bullet(player.Position - (new Vector2(player.ShipTexture.Width / 2, player.ShipTexture.Height / 2)), 2f, gameOne.Content.Load<Texture2D>("BulletTexture"));

                firedBullets.Add(newBullet);
            }

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

        public void PlayerHit(Player player)
        {
            for (int j = currentEnemies.Count - 1; j >= 0; j--)
            {
                if (player.HitBox.Intersects(currentEnemies[j].HitBox))
                {
                    Console.WriteLine($"Player got hit");
                    currentEnemies[j].Remove = true;
                    player.PlayerDeath = true;
                }
            }
        }

        public void PlayerDeath(Game1 gameOne, bool playerDeath)
        {
            if(playerDeath == true)
            {
                gameOne.Exit();
            }
        }

        public void Update(Game1 gameOne, Player player, GameTime gameTime, GraphicsDeviceManager graphics)
        {
            CreateEnemy(gameOne, graphics, gameTime);
            CreateBullet(gameOne, player, gameTime);
            CheckPlayerShoot(gameOne);
            PlayerHit(player);
            PlayerDeath(gameOne, player.PlayerDeath);
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
