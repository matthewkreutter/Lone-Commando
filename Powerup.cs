using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Shooter
{
    class Powerup
    {
        private Texture2D Powerup_Texture;
        private String Powerup_Type;
        public String getPowerup_Type
        {
            get
            {
                return Powerup_Type;
            }
        }
        private Vector2 Powerup_Position;
        public Vector2 getPowerup_Position
        {
            get
            {
                return Powerup_Position;
            }
        }
        public bool isPowerupActive;
        public Powerup()
        {
            isPowerupActive = false;
        }
        public void ActivatePowerup(Texture2D inPowerup_Texture, Vector2 inPowerup_Position, String inPowerup_Type)
        {
            isPowerupActive = true;
            Powerup_Texture = inPowerup_Texture;
            Powerup_Position = inPowerup_Position;
            Powerup_Type = inPowerup_Type;
        }
        public void Update(GameTime gameTime, HeroSprite Hero)
        {

        }
        public String Powerup_Effect()
        {
            if (this.getPowerup_Type == "Godmode")
            {
                return "Godmode";
            }
            else if (this.getPowerup_Type == "SuperGun")
            {
                return "SuperGun";
            }
            else if (this.getPowerup_Type == "Heart")
            {
                return "Heart";
            }
            else if (this.getPowerup_Type == "SuperSpeed")
            {
                return "SuperSpeed";
            }
            return "";
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Powerup_Texture, Powerup_Position, Color.White);
        }
        public void DeactivatePowerup()
        {
            isPowerupActive = false;
        }

    }
}
