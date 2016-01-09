using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class HeroSprite
    {
        private Texture2D Hero_Stand_Right, Hero_Move_Right, Hero_Stand_Left, Hero_Move_Left;
        private Texture2D Hero_Stand_Up, Hero_Move_Up, Hero_Stand_Down, Hero_Move_Down, Hero_Current, Shield_Final;
        private Vector2 Hero_Position, Shield_Position, Hero_Speed;
        public Vector2 getHero_Position
        {
            get
            {
                return Hero_Position;
            }
        }
        private int Hero_Speed_Multiplier = 1;
        public int setHero_Speed
        {
            set
            {
                Hero_Speed_Multiplier = value;
            }
        }
        public bool isShieldOn;
        public bool isHeroActive;

        public HeroSprite()
        {
            isShieldOn = false;
            isHeroActive = false;
        }
        public HeroSprite(Texture2D inHero_Stand_Right, Texture2D inHero_Move_Right, Texture2D inHero_Stand_Left, Texture2D inHero_Move_Left, Texture2D inHero_Stand_Up, Texture2D inHero_Move_Up, Texture2D inHero_Stand_Down, Texture2D inHero_Move_Down, Texture2D inShield_Final, Vector2 inPosition)
        {
            isHeroActive = true;
            isShieldOn = false;
            Hero_Stand_Right = inHero_Stand_Right;
            Hero_Move_Right = inHero_Move_Right;
            Hero_Stand_Left = inHero_Stand_Left;
            Hero_Move_Left = inHero_Move_Left;
            Hero_Stand_Up = inHero_Stand_Up;
            Hero_Move_Up = inHero_Move_Up;
            Hero_Stand_Down = inHero_Stand_Down;
            Hero_Move_Down = inHero_Move_Down;
            Hero_Position = inPosition;
            Hero_Current = Hero_Stand_Right;
            Shield_Final = inShield_Final;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Hero_Current != null)
            {
                spriteBatch.Draw(Hero_Current, Hero_Position, Color.White);
            }
            if (isShieldOn == true)
            {
                Shield_Position = new Vector2(Hero_Position.X - 17, Hero_Position.Y - 27);
                spriteBatch.Draw(Shield_Final, Shield_Position, Color.White);
            }
        }
        public void MoveRight(Vector2 Crosshair_Position)
        {
            if (isShieldOn == false)
            {
                if (Crosshair_Position.X > Hero_Position.X && Crosshair_Position.Y > (2 * Hero_Position.X - Crosshair_Position.X) && Crosshair_Position.Y < (Hero_Position.Y + Crosshair_Position.X - Hero_Position.X))
                {
                    Hero_Current = Hero_Move_Right;
                }
                else if (Crosshair_Position.X < Hero_Position.X && Crosshair_Position.Y < (2 * Hero_Position.X - Crosshair_Position.X) && Crosshair_Position.Y > (Hero_Position.Y + Crosshair_Position.X - Hero_Position.X))
                {
                    Hero_Current = Hero_Move_Left;
                }
                else if (Crosshair_Position.Y < Hero_Position.Y && Crosshair_Position.X > (Hero_Position.X - Hero_Position.Y + Crosshair_Position.Y) && Crosshair_Position.X < (Hero_Position.X + Hero_Position.Y - Crosshair_Position.Y))
                {
                    Hero_Current = Hero_Move_Up;
                }
                else if (Crosshair_Position.Y > Hero_Position.Y && Crosshair_Position.X < (Hero_Position.X - Hero_Position.Y + Crosshair_Position.Y) && Crosshair_Position.X > (Hero_Position.X + Hero_Position.Y - Crosshair_Position.Y))
                {
                    Hero_Current = Hero_Move_Down;
                }
                Hero_Speed.X = 10 * Hero_Speed_Multiplier;
                Hero_Speed.Y = 0 * Hero_Speed_Multiplier;

                Hero_Position += Hero_Speed;
            }
        }
        public void MoveLeft(Vector2 Crosshair_Position)
        {
            if (isShieldOn == false)
            {
                if (Crosshair_Position.X > Hero_Position.X && Crosshair_Position.Y > (2 * Hero_Position.X - Crosshair_Position.X) && Crosshair_Position.Y < (Hero_Position.Y + Crosshair_Position.X - Hero_Position.X))
                {
                    Hero_Current = Hero_Move_Right;
                }
                else if (Crosshair_Position.X < Hero_Position.X && Crosshair_Position.Y < (2 * Hero_Position.X - Crosshair_Position.X) && Crosshair_Position.Y > (Hero_Position.Y + Crosshair_Position.X - Hero_Position.X))
                {
                    Hero_Current = Hero_Move_Left;
                }
                else if (Crosshair_Position.Y < Hero_Position.Y && Crosshair_Position.X > (Hero_Position.X - Hero_Position.Y + Crosshair_Position.Y) && Crosshair_Position.X < (Hero_Position.X + Hero_Position.Y - Crosshair_Position.Y))
                {
                    Hero_Current = Hero_Move_Up;
                }
                else if (Crosshair_Position.Y > Hero_Position.Y && Crosshair_Position.X < (Hero_Position.X - Hero_Position.Y + Crosshair_Position.Y) && Crosshair_Position.X > (Hero_Position.X + Hero_Position.Y - Crosshair_Position.Y))
                {
                    Hero_Current = Hero_Move_Down;
                }
                Hero_Speed.X = 10 * Hero_Speed_Multiplier;
                Hero_Speed.Y = 0 * Hero_Speed_Multiplier;

                Hero_Position -= Hero_Speed;
            }
        }
        public void MoveUp(Vector2 Crosshair_Position)
        {
            if (isShieldOn == false)
            {
                if (Crosshair_Position.X > Hero_Position.X && Crosshair_Position.Y > (2 * Hero_Position.X - Crosshair_Position.X) && Crosshair_Position.Y < (Hero_Position.Y + Crosshair_Position.X - Hero_Position.X))
                {
                    Hero_Current = Hero_Move_Right;
                }
                else if (Crosshair_Position.X < Hero_Position.X && Crosshair_Position.Y < (2 * Hero_Position.X - Crosshair_Position.X) && Crosshair_Position.Y > (Hero_Position.Y + Crosshair_Position.X - Hero_Position.X))
                {
                    Hero_Current = Hero_Move_Left;
                }
                else if (Crosshair_Position.Y < Hero_Position.Y && Crosshair_Position.X > (Hero_Position.X - Hero_Position.Y + Crosshair_Position.Y) && Crosshair_Position.X < (Hero_Position.X + Hero_Position.Y - Crosshair_Position.Y))
                {
                    Hero_Current = Hero_Move_Up;
                }
                else if (Crosshair_Position.Y > Hero_Position.Y && Crosshair_Position.X < (Hero_Position.X - Hero_Position.Y + Crosshair_Position.Y) && Crosshair_Position.X > (Hero_Position.X + Hero_Position.Y - Crosshair_Position.Y))
                {
                    Hero_Current = Hero_Move_Down;
                }
                Hero_Speed.X = 0 * Hero_Speed_Multiplier;
                Hero_Speed.Y = 10 * Hero_Speed_Multiplier;

                Hero_Position -= Hero_Speed;
            }
        }
        public void MoveDown(Vector2 Crosshair_Position)
        {
            if (isShieldOn == false)
            {
                if (Crosshair_Position.X > Hero_Position.X && Crosshair_Position.Y > (2 * Hero_Position.X - Crosshair_Position.X) && Crosshair_Position.Y < (Hero_Position.Y + Crosshair_Position.X - Hero_Position.X))
                {
                    Hero_Current = Hero_Move_Right;
                }
                else if (Crosshair_Position.X < Hero_Position.X && Crosshair_Position.Y < (2 * Hero_Position.X - Crosshair_Position.X) && Crosshair_Position.Y > (Hero_Position.Y + Crosshair_Position.X - Hero_Position.X))
                {
                    Hero_Current = Hero_Move_Left;
                }
                else if (Crosshair_Position.Y < Hero_Position.Y && Crosshair_Position.X > (Hero_Position.X - Hero_Position.Y + Crosshair_Position.Y) && Crosshair_Position.X < (Hero_Position.X + Hero_Position.Y - Crosshair_Position.Y))
                {
                    Hero_Current = Hero_Move_Up;
                }
                else if (Crosshair_Position.Y > Hero_Position.Y && Crosshair_Position.X < (Hero_Position.X - Hero_Position.Y + Crosshair_Position.Y) && Crosshair_Position.X > (Hero_Position.X + Hero_Position.Y - Crosshair_Position.Y))
                {
                    Hero_Current = Hero_Move_Down;
                }
                Hero_Speed.X = 0 * Hero_Speed_Multiplier;
                Hero_Speed.Y = 10 * Hero_Speed_Multiplier;

                Hero_Position += Hero_Speed;
            }
        }
        public void Shield()
        {
            isShieldOn = true;
        }
        public void Revert(Vector2 Crosshair_Position)
        {
            if (Crosshair_Position.X > Hero_Position.X && Crosshair_Position.Y > (2 * Hero_Position.X - Crosshair_Position.X) && Crosshair_Position.Y < (Hero_Position.Y + Crosshair_Position.X - Hero_Position.X))
            {
                Hero_Current = Hero_Move_Right;
            }
            else if (Crosshair_Position.X < Hero_Position.X && Crosshair_Position.Y < (2 * Hero_Position.X - Crosshair_Position.X) && Crosshair_Position.Y > (Hero_Position.Y + Crosshair_Position.X - Hero_Position.X))
            {
                Hero_Current = Hero_Move_Left;
            }
            else if (Crosshair_Position.Y < Hero_Position.Y && Crosshair_Position.X > (Hero_Position.X - Hero_Position.Y + Crosshair_Position.Y) && Crosshair_Position.X < (Hero_Position.X + Hero_Position.Y - Crosshair_Position.Y))
            {
                Hero_Current = Hero_Move_Up;
            }
            else if (Crosshair_Position.Y > Hero_Position.Y && Crosshair_Position.X < (Hero_Position.X - Hero_Position.Y + Crosshair_Position.Y) && Crosshair_Position.X > (Hero_Position.X + Hero_Position.Y - Crosshair_Position.Y))
            {
                Hero_Current = Hero_Move_Down;
            }
            if (Hero_Current == Hero_Move_Right)
            {
                Hero_Current = Hero_Stand_Right;
            }
            else if (Hero_Current == Hero_Move_Left)
            {
                Hero_Current = Hero_Stand_Left;
            }
            else if (Hero_Current == Hero_Move_Down)
            {
                Hero_Current = Hero_Stand_Down;
            }
            else if (Hero_Current == Hero_Move_Up)
            {
                Hero_Current = Hero_Stand_Up;
            }
            isShieldOn = false;
        }
        public void DeactivateHero()
        {
            isHeroActive = false;
        }
        public void Respawn(int Screen_Width, int Screen_Height)
        {
            Hero_Position.X = Screen_Width / 2;
            Hero_Position.Y = Screen_Height / 2;
            isHeroActive = true;
        }
    }
}


