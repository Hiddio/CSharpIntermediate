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
        //FEEDBACK public Fields schrijf je met PascalCasing
        //FEEDBACK private Fields schrijf je met camelCasing + eventueel (optioneel) een underscore prefix: "_"
        //FEEDBACK Je kunt prima de "private" Access Modifier weglaten, maar wees hier dan consistent in!
        
        //FEEDBACK Deel lange functies op in meerdere kleinere functies, beste is om een functie maar één functionaliteit te geven
        //FEEDBACK CreateEnemy(), CreateBullet(), PlayerMovement(), KeepPlayerOnScreen() functies


        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        Song _backGroundMusic;

        Viewport _viewPort;
        Player _player;
        bool _justFired;
        List<Enemy> _activeEnemies = new List<Enemy>();
        List<Bullet> _firedBullets = new List<Bullet>();
        float _totalTime;
        float _timerTime = 5f;
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

        //FEEDBACK Splits de code in de Update functie op in meerdere kleinere functies en probeer alleen maar Method Calls te doen in de Update functie
        //FEEDBACK Zoals je _player.UpdatePlayer() hebt gedaan
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.UpdatePlayer();
            //_bullet.UpdateBullet();

            //Hier haal ik de "deltaTime" op
            _totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(_totalTime >= _timerTime)
            {
                //FEEDBACK Stop dit blok code in een CreateEnemy() functie
                Random random = new Random();
                int spawnLocX = random.Next(1, GraphicsDevice.Viewport.Width - 2);
                int spawnLocY = 2;
                //int spawnLocation = random.Next(spawnLocX, spawnLocY);
                Vector2 pos = new Vector2(spawnLocX, spawnLocY);

                Enemy newEnemy = new Enemy(pos, 0.05f, Content.Load<Texture2D>("EnemyTexture"));
                newEnemy.EnemyTexture = Content.Load<Texture2D>("EnemyTexture");
                _activeEnemies.Add(newEnemy);
                _timerTime = _timerTime + 5;
                //FEEDBACK end CreateEnemy() functie
            }


            foreach (Bullet bullet in _firedBullets)
            {
                bullet.UpdateBullet(false);
               
            }

            //FEEDBACK Stop dit blok in een CheckPlayerShoot() functie
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _justFired == false || GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed && _justFired == false)
            {
                _justFired = true;
                Console.WriteLine(_justFired);
                //FEEDBACK Je zou ook nog dit stukje in een CreateBullet() functie kunnen stoppen
                Bullet newBllet = new Bullet(_player._position, 2f);
                newBllet._texture = Content.Load<Texture2D>("BulletTexture");
                _firedBullets.Add(newBllet);
                //FEEDBACK end CreateBullet() functie
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space) && GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Released)
            { 
                _justFired = false;
            }
            //FEEDBACK end CheckPlayerShoot functie()

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
