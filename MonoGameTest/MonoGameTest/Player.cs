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
        float scale;
        int playerSpeed;
        Rectangle? hitBox;
        public Rectangle HitBox
        {
            get
            {
                hitBox ??= new(0, 0, (int)(ShipTexture.Width * scale), (int)(ShipTexture.Height * scale));

                Rectangle rect = hitBox.Value;

                rect.X = (int)Position.X;
                rect.Y = (int)Position.Y;

                return rect;
            }
        }
        public bool PlayerDeath;
        public Player(Vector2 pos, float scale, Texture2D shipTexture)
        {
            Position = pos;
            this.scale = scale;
            this.ShipTexture = shipTexture;
            playerSpeed = 13;
        }
        public void Update(GraphicsDeviceManager graphics)
        {
            KeepPlayerOnScreen(graphics);
            PlayerMovement();
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
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
            {
                Position.Y -= playerSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
            {
                Position.Y += playerSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
            {
                Position.X -= playerSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
            {
                Position.X += playerSpeed;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ShipTexture, Position, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}
