﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NLua;

namespace Cythaldor
{
    public abstract class Sprite
    {
        protected Texture2D texture;
        protected Vector2 position, direction;

        public Sprite(Texture2D texture, Vector2 position, Vector2 direction)
        {
            this.texture = texture;
            this.position = position;
        }

        public virtual void Initialize()
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }

        

        #region SET/GET

        //Position
        public void setPos(int x, int y)
        {
            this.position = new Vector2(x, y);
        }
        public Vector2 getPos()
        {
            return this.position;
        }
        public void setMove(Vector2 dir, int speed, int egtm)
        {
            this.position += (dir * speed * egtm);
        }

        //Direction
        public void setDir(int x, int y)
        {
            this.direction = new Vector2(x, y);
        }
        public Vector2 getDir()
        {
            return this.direction;
        }

        //Texture
        public void setTexture(Texture2D texture)
        {
            this.texture = texture;
        }
        public Texture2D getTexture()
        {
            return this.texture;
        }



        #endregion

    }
}