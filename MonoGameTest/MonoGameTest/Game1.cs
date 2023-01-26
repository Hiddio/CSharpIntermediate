using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System;

namespace MonoGameTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Song _backGroundMusic;

        Viewport _viewPort;
        Player _player;
        bool justFired;
        List<Enemy> _activeEnemies = new List<Enemy>();
        List<Bullet> _firedBullets = new List<Bullet>();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            _graphics.PreferredBackBufferHeight = 900;
            _graphics.PreferredBackBufferWidth = 1000;

            _graphics.ApplyChanges();
            _viewPort = _graphics.GraphicsDevice.Viewport;
        }

        protected override void LoadContent()
        {

            
            _player = new Player();

            _viewPort = new Viewport();

            _spriteBatch = new SpriteBatch(GraphicsDevice);

           
            _player._shipTexture = this.Content.Load<Texture2D>("SpaceShip");

            _backGroundMusic = this.Content.Load<Song>("Hypnotik - Ken Arai");
            MediaPlayer.Play(_backGroundMusic);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.UpdatePlayer();
            //_bullet.UpdateBullet();

            
            foreach(Bullet bullet in _firedBullets)
            {
                bullet.UpdateBullet(false);

            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed && justFired == false)
            {
                justFired = true;
                Console.WriteLine(justFired);
                Bullet newBllet = new Bullet(_player._position, 1f);
                newBllet._texture = Content.Load<Texture2D>("BulletTexture");
                _firedBullets.Add(newBllet);
                
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Released)
            {
                justFired = false;
            }

            foreach(Enemy enemy in _activeEnemies)
            {
                enemy.Update();

            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_player._shipTexture, _player._position, Color.White);

            foreach (Bullet bullet in _firedBullets)
            {
                bullet.Draw(gameTime, _spriteBatch);

            }
            foreach (Enemy enemy in _activeEnemies)
            {
                enemy.Draw(gameTime, _spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
