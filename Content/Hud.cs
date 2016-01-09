using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class HUD
    {
        private Vector2 Score_Position = new Vector2(20, 10), Lives_Position = new Vector2(20, 40), Wave_Position = new Vector2(20, 70), Powerup_Position = new Vector2(600, 10);
        public Vector2 getLives_Position
        {
            get
            {
                return Lives_Position;
            }
        }
        public SpriteFont Font;
        public int Score, Lives, Wave;


        public HUD()
        {
        }
        public void Draw(SpriteBatch spriteBatch, bool isActive, int Powerup_Duration, String Effect_Current)
        {
            if (isActive == true)
            {
                int temp = (int)Powerup_Duration / 10;
                if (Effect_Current != "Heart")
                {
                    spriteBatch.DrawString(Font, Effect_Current + " Time Left: " + temp.ToString(), Powerup_Position, Color.White);
                    spriteBatch.DrawString(Font, "Score: " + Score.ToString(), Score_Position, Color.White);
                    spriteBatch.DrawString(Font, "Lives: ", Lives_Position, Color.White);
                    spriteBatch.DrawString(Font, "Wave: " + Wave.ToString(), Wave_Position, Color.White);
                }
                else
                {
                    spriteBatch.DrawString(Font, "Lives +1", Powerup_Position, Color.White);
                    spriteBatch.DrawString(Font, "Score: " + Score.ToString(), Score_Position, Color.White);
                    spriteBatch.DrawString(Font, "Lives: ", Lives_Position, Color.White);
                    spriteBatch.DrawString(Font, "Wave: " + Wave.ToString(), Wave_Position, Color.White);
                }
            }
            else
            {
                spriteBatch.DrawString(Font, "Score: " + Score.ToString(), Score_Position, Color.White);
                spriteBatch.DrawString(Font, "Lives: ", Lives_Position, Color.White);
                spriteBatch.DrawString(Font, "Wave: " + Wave.ToString(), Wave_Position, Color.White);
            }
        }
    }
}

