﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MonoGameTest
{
    internal class Bullet
    {
        //FEEDBACK public Fields schrijf je met PascalCasing en ZONDER een underscore prefix "_"! 
        public Vector2 Position;
        public Texture2D Texture;
        public float Scale;
        public Rectangle HitBox;
        public List<Enemy> currentEnemies;
        public int Index;
        public float timer;
        public bool remove;
        public Bullet(Vector2 pos, float scale, Texture2D texture, int index)
        {

            Position = pos;

            Scale = scale;

            Texture = texture;

            Index = index;

            currentEnemies = new List<Enemy>();

            Index = index;

            HitBox = new Rectangle((int)Position.X + Texture.Width / 2, (int)Position.Y + Texture.Height / 2, Texture.Width, Texture.Height);
        }

        public void SetHitbox()
        {
            HitBox.X = (int)Position.X + Texture.Width / 2;
            HitBox.Y = (int)Position.Y + Texture.Height / 2;
        }
       
        

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(timer > 1)
            {
                remove = true;
            }

            Position.Y -= 10;

            SetHitbox();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D pixel)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, HitBox, Color.White);
        }
    }
}
