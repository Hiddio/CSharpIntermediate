using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameTest
{
    internal class Player
    {
        public Vector2 _position;
        public Texture2D _shipTexture;

        public Player()
        {

            _position = new Vector2(0, 0);
            

            
        }
        
        public void UpdatePlayer()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _position.Y -= 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _position.Y += 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _position.X -= 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _position.X += 10;
            }
            if (_position.Y <= -10)
            {
                _position.Y = 780;
            }
            if (_position.X <= -10)
            {
                _position.X = 980;
            }
            if (_position.X >= 1000)
            {
                _position.X = 0;
            }
            if (_position.Y >= 870)
            {
                _position.Y = 0;
            }
        }
    }
}
