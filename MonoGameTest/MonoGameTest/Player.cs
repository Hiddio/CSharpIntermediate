using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MonoGameTest
{
    internal class Player
    {
        public Vector2 Position;
        public Texture2D ShipTexture;

        public Player()
        {

            Position = new Microsoft.Xna.Framework.Vector2(0, 0);
            

            
        }
        
        public void Update(GraphicsDeviceManager graphics)
        {
            KeepPlayerOnScreen(graphics);
            PlayerMovement();
            
            //FEEDBACK KeepPlayerOnScreen() functie

            //FEEDBACK 780 en 980 zijn hardcoded, probeer de _graphics variabel van Game1 te gebruiken, dan kun je precies de grootte van het scherm aflezen
            

            //FEEDBACK end KeepPlayerOnScreen() functie
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
