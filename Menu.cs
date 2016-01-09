using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Menu
    {
        private SpriteFont Font;
        private Color StartGame_Color, Help_Color, Quit_Color, Return_Color;
        private Vector2 StartGame_Button, Help_Button, Quit_Button, Return_Button, Mouse_Position;
        private int GameWindow_Width, GameWindow_Height;
        private String GameState = "Menu", MenuState = "Main";
        private Texture2D Mouse_Cursor, Menu_Help;

        public Menu(SpriteFont inFont, int inWidth, int inHeight, Texture2D inMouse_Cursor, Texture2D inMenu_Help)
        {
            Font = inFont;
            Mouse_Cursor = inMouse_Cursor;
            Menu_Help = inMenu_Help;
            StartGame_Button = new Vector2(inWidth/2, inHeight/2);
            Help_Button = new Vector2(inWidth / 2, inHeight / 2 + 40);
            Quit_Button = new Vector2(inWidth / 2, inHeight / 2 + 80);
            Return_Button = new Vector2(inWidth / 2 + 200, inHeight / 2 - 300);
            StartGame_Color = Color.White;
            Help_Color = Color.White;
            Quit_Color = Color.White;
            Return_Color = Color.White;
            GameWindow_Width = inWidth;
            GameWindow_Height = inHeight;
        }
        public void Menu_Update(Vector2 inMouse_Position, bool ButtonPressed)
        {
            Mouse_Position = inMouse_Position;
            if (MenuState == "Main")
            {
                if (inMouse_Position.X >= StartGame_Button.X - 20 && inMouse_Position.X <= StartGame_Button.X + 150 && inMouse_Position.Y >= StartGame_Button.Y - 10 && inMouse_Position.Y <= StartGame_Button.Y + 10)
                {
                    Highlight_StartGame();
                    if (ButtonPressed == true)
                    {
                        GameState = "Game";
                    }
                }
                else if (inMouse_Position.X >= Help_Button.X - 20 && inMouse_Position.X <= Help_Button.X + 50 && inMouse_Position.Y >= Help_Button.Y - 10 && inMouse_Position.Y <= Help_Button.Y + 10)
                {
                    Highlight_Help();
                    if (ButtonPressed == true)
                    {
                        MenuState = "Help";
                    }
                }
                else if (inMouse_Position.X >= Quit_Button.X - 20 && inMouse_Position.X <= Quit_Button.X + 50 && inMouse_Position.Y >= Quit_Button.Y - 10 && inMouse_Position.Y <= Quit_Button.Y + 10)
                {
                    Highlight_Quit();
                    if (ButtonPressed == true)
                    {
                        GameState = "Quit";
                    }
                }
            }
            else if (MenuState == "Help")
            {
                if (inMouse_Position.X >= Return_Button.X - 20 && inMouse_Position.X <= Return_Button.X + 50 && inMouse_Position.Y >= Return_Button.Y - 10 && inMouse_Position.Y <= Return_Button.Y + 10)
                {
                    Highlight_Return();
                    if (ButtonPressed == true)
                    {
                        MenuState = "Main";
                    }
                }
            }
        }
        private void Highlight_StartGame()
        {
            StartGame_Color = Color.Yellow;
        }
        private void Highlight_Help()
        {
            Help_Color = Color.Yellow;
        }
        private void Highlight_Quit()
        {
            Quit_Color = Color.Yellow;
        }
        private void Highlight_Return()
        {
            Return_Color = Color.Yellow;
        }
        public String getGameState()
        {
            String temp = GameState;
            GameState = "Menu";
            return (temp);
        }
        private void Revert()
        {
            StartGame_Color = Color.White;
            Help_Color = Color.White;
            Quit_Color = Color.White;
            Return_Color = Color.White;
        }
        public void Draw(SpriteBatch spriteBatch, String OldGameState)
        {
            if (MenuState == "Main")
            {
                if (OldGameState == "Game")
                {
                    spriteBatch.DrawString(Font, "Resume", StartGame_Button, StartGame_Color);
                }
                else
                {
                    spriteBatch.DrawString(Font, "Start Game", StartGame_Button, StartGame_Color);
                }
                spriteBatch.DrawString(Font, "Help", Help_Button, Help_Color);
                spriteBatch.DrawString(Font, "Quit", Quit_Button, Quit_Color);
                spriteBatch.Draw(Mouse_Cursor, Mouse_Position, Color.White);
                Revert();
            }
            else if (MenuState == "Help")
            {
                spriteBatch.Draw(Menu_Help, Vector2.Zero, Color.White);
                spriteBatch.DrawString(Font, "Return", Return_Button, Return_Color);
                spriteBatch.Draw(Mouse_Cursor, Mouse_Position, Color.White);
                Revert();
            }
        }
    }
}
