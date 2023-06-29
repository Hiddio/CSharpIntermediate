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
        Player _player;
        Vector2 _playerPos;
        GameManager _gameManager;

        float _totalTime;
        float _timerTime = 5f;
        float _addedTime = 5f;

        Texture2D _pixel;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.PreferredBackBufferWidth = 1000;

            _graphics.ApplyChanges();

            _pixel = new Texture2D(GraphicsDevice, 1, 1);

            _pixel.SetData(new Color[] { new Color(255, 0, 0, 50) });

            base.Initialize();


        }

        protected override void LoadContent()
        {

            _playerPos = new Vector2(0, 0);
            _player = new Player(_playerPos, 1, Content.Load<Texture2D>("SpaceShip"));

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _gameManager = new GameManager();

            _backGroundMusic = Content.Load<Song>("Hypnotik - Ken Arai");
            MediaPlayer.Play(_backGroundMusic);



        }

        //FEEDBACK Splits de code in de Update functie op in meerdere kleinere functies en probeer alleen maar Method Calls te doen in de Update functie
        //FEEDBACK Zoals je _player.UpdatePlayer() hebt gedaan
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.Update(_graphics);
            //_bullet.UpdateBullet();

            //Hier haal ik de "deltaTime" op
            _totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_totalTime >= _timerTime)
            {

                _gameManager.CreateEnemy(this, _graphics);

                if (_addedTime > 1)
                {
                    _addedTime--;

                }

                _timerTime = _totalTime + _addedTime;

            }

            _gameManager.Update(this, _player, gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            
            _player.Draw(gameTime, _spriteBatch, _pixel);

            _gameManager.Draw(gameTime, _spriteBatch, _pixel);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
