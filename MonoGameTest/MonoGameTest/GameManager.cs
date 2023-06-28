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
        public GameManager()
        {
            currentEnemies = new List<Enemy>();
            firedBullets = new List<Bullet>();
        }

        public void CreateEnemy(Game1 gameOne, GraphicsDeviceManager graphics)
        {
            //FEEDBACK Stop dit blok code in een CreateEnemy() functie
            Random random = new Random();
            int spawnLocX = random.Next(1, graphics.PreferredBackBufferWidth);
            int spawnLocY = 2;
            //int spawnLocation = random.Next(spawnLocX, spawnLocY);
            Vector2 pos = new Vector2(spawnLocX, spawnLocY);

            Enemy newEnemy = new Enemy(pos, 0.05f, gameOne.Content.Load<Texture2D>("EnemyTexture"));

            currentEnemies.Add(newEnemy);
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

                Bullet newBullet = new Bullet(player.Position - (new Vector2(player.ShipTexture.Width / 2, player.ShipTexture.Height / 2)), 2f, gameOne.Content.Load<Texture2D>("BulletTexture")); ;

                firedBullets.Add(newBullet);
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

        public void Update(Game1 gameOne, Player player)
        {
            CreateBullet(gameOne, player);
            CheckPlayerShoot(gameOne);

            foreach (Bullet bullet in firedBullets)
            {
                bullet.Update();

            }

            foreach (Enemy enemy in currentEnemies)
            {
                enemy.Update();

            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            foreach (Enemy enemy in currentEnemies)
            {
                enemy.Draw(gameTime, spriteBatch);
            }

            foreach (Bullet bullet in firedBullets)
            {
                bullet.Draw(gameTime, spriteBatch);

            }

        }

    }
}
