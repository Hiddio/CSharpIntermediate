using Microsoft.Xna.Framework;
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

            SetHitbox();
        }

        public void SetHitbox()
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, ShipTexture.Width, ShipTexture.Height);
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
    }
}
