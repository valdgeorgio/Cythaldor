﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cythaldor.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Cythaldor.GuiElements;

namespace Cythaldor.Guis
{
    public class MainMenuGui : Gui
    {
        List<GuiElement> guiList;

        Button buttonPlay, buttonExit;
        Button buttonTest;
        Cursor cursor;


        private Game game;

        public MainMenuGui(Game game)
        {
            this.game = game;
        }

        public void Init()
        {
            guiList = new List<GuiElement>();
        }

        public void LoadContent()
        {
            buttonPlay = new Button(GameMain.resManager.GetAsset<Texture2D>("button_play"), new Rectangle(0, 50, 190, 49),
                GameMain.resManager.GetAsset<Texture2D>("button_play_over"));
            buttonPlay.CenterX(GameMain.GetGraphics().PreferredBackBufferWidth, GameMain.GetGraphics().PreferredBackBufferHeight);
            buttonPlay.onMouseDown += buttonPlay_onMouseDown;
            buttonPlay.onMouseClick += buttonPlay_onMouseClick;

            buttonExit = new Button(GameMain.resManager.GetAsset<Texture2D>("button_exit"), new Rectangle(0, 100, 190, 49),
                GameMain.resManager.GetAsset<Texture2D>("button_exit_over"));
            buttonExit.CenterX(GameMain.GetGraphics().PreferredBackBufferWidth, GameMain.GetGraphics().PreferredBackBufferHeight);
            buttonExit.onMouseClick += buttonExit_onMouseClick;

            cursor = new Cursor(GameMain.resManager.GetAsset<Texture2D>("cursor_menu"), new Point(0, 0));

            buttonTest = new Button(GameMain.resManager.GetAsset<Texture2D>("button_blue"), new Rectangle(0, 300, 190, 49), null, "Hello",
                GameMain.resManager.GetAsset<SpriteFont>("font_base"), Color.Orange);

            guiList.Add(buttonPlay);
            guiList.Add(buttonExit);

            guiList.Add(buttonTest);

            guiList.Add(cursor);

        }

        void buttonExit_onMouseClick(object sender, EventArgs e)
        {
            game.Exit();
        }

        void buttonPlay_onMouseClick(object sender, EventArgs e)
        {
            Console.WriteLine("Button Play Mouse Click");
        }

        void buttonPlay_onMouseDown(object sender, EventArgs e)
        {
            Console.WriteLine("Button Play Mouse down");
        }


        public void Update(GameTime gameTime)
        {
            foreach (GuiElement guiElem in guiList)
            {
                guiElem.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(GuiElement guiElem in guiList)
            {
                guiElem.Draw(spriteBatch);
            }
        }
    }
}
