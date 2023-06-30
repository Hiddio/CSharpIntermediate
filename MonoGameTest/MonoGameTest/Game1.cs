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
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        

        Song backGroundMusic;
        Player player;
        Vector2 playerPos;
        GameManager gameManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1000;

            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            playerPos = new Vector2(0, 0);

            player = new Player(playerPos, 1, Content.Load<Texture2D>("SpaceShip"));

            spriteBatch = new SpriteBatch(GraphicsDevice);

            gameManager = new GameManager(this);

            backGroundMusic = Content.Load<Song>("Hypnotik - Ken Arai");

            MediaPlayer.Play(backGroundMusic);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(graphics);
            gameManager.Update(this, player, gameTime, graphics);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MidnightBlue);

            spriteBatch.Begin();
            
            player.Draw(gameTime, spriteBatch);
            gameManager.Draw(gameTime, spriteBatch, graphics);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
