﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameTest
{
    internal class Player
    {
        public Vector2 Position;
        public Texture2D ShipTexture;
        float Scale;
        public Rectangle HitBox;
        public List<Enemy> currentEnemies;
        public Player(Vector2 pos, float scale, Texture2D shipTexture)
        {

            Position = pos;

            Scale = scale;

            ShipTexture = shipTexture;

            currentEnemies = new List<Enemy>();

            HitBox = new Rectangle((int)Position.X, (int)Position.Y, ShipTexture.Width, ShipTexture.Height);
        }

        public void SetHitbox()
        {
            HitBox.X = (int)Position.X;
            HitBox.Y = (int)Position.Y;
        }

        public bool EnemyCollision()
        {
            bool collided = false;
            foreach (Enemy enemy in currentEnemies)
            {
                if (this.HitBox.Contains(enemy.HitBox))
                {
                    collided = true;
                    Console.WriteLine("PLAYER HIT");
                }
                else
                {
                    collided = false;
                }
            }

            return collided;
        }

        public void Update(GraphicsDeviceManager graphics)
        {
            KeepPlayerOnScreen(graphics);
            PlayerMovement();
            SetHitbox();
        }

        public void KeepPlayerOnScreen(GraphicsDeviceManager graphics)
        {
            if (Position.X > graphics.PreferredBackBufferWidth - ShipTexture.Width)
            {
                Position.X = graphics.PreferredBackBufferWidth - ShipTexture.Width;
            }
            else if (Position.X < ShipTexture.Width / 2)
            {
                Position.X = ShipTexture.Width / 2;
            }
            else if (Position.Y > graphics.PreferredBackBufferHeight - ShipTexture.Height)
            {
                Position.Y = graphics.PreferredBackBufferHeight - ShipTexture.Height;
            }
            else if (Position.Y < ShipTexture.Height / 2)
            {
                Position.Y = ShipTexture.Height / 2;
            }

        }

        public void PlayerMovement()
        {
            //FEEDBACK PlayerMovement() functie
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
            {
                Position.Y -= 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
            {
                Position.Y += 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
            {
                Position.X -= 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
            {
                Position.X += 10;
            }
            //FEEDBACK end PlayerMovement() functie
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D pixel)
        {
            spriteBatch.Draw(ShipTexture, Position, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, HitBox, Color.White);
        }
    }
}
