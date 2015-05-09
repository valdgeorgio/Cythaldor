﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Cythaldor.Manager;
using Cythaldor.Screens;
using Cythaldor.Content;

namespace Cythaldor
{
    public class GameMain : Game
    {
        static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ScreenManager screenManager;

        static GuiManager guiManager;

        private SpriteFont font;

        public static TextureManager textureManager;

        private bool DEBUG = false;

        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            textureManager = new TextureManager(Content);
            screenManager = new ScreenManager(new MainMenu(this));
        }

        protected override void Initialize()
        {
            screenManager.Init();
            guiManager.Init();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screenManager.LoadContent(Content);
            guiManager.LoadContent();
            font = Content.Load<SpriteFont>("font_base");
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            screenManager.Update(gameTime);
            guiManager.Update(gameTime);
            base.Update(gameTime);
        }

        float frameRate;

        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            screenManager.Draw(spriteBatch);
            guiManager.Draw(spriteBatch);
            if (DEBUG)
            {
                frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
                spriteBatch.DrawString(font, frameRate.ToString(), new Vector2(0, 0), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public static GuiManager GetGuiManager()
        {
            return guiManager;
        }
        public static GraphicsDeviceManager GetGraphics()
        {
            return graphics;
        }

        public static void SetGuiManager(GuiManager guiM)
        {
            guiManager = guiM;
        }
    }
}
