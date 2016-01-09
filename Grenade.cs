using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Grenade
    {
        private Texture2D Grenade_Texture;
        public Texture2D setGrenade_Texture
        {
            set
            {
                Grenade_Texture = value;
            }
        }
        private Vector2 Grenade_Target, Grenade_Position, Grenade_Direction;
        public Vector2 getGrenade_Position
        {
            get
            {
                return Grenade_Position;
            }
        }
        public Vector2 getGrenade_Target
        {
            get
            {
                return Grenade_Target;
            }
        }
        public bool isGrenadeActive;
        private int Grenade_Speed;

        public Grenade()
        {
            isGrenadeActive = false;
        }
        public void ActivateGrenade(Vector2 inTarget, Vector2 inPosition, Texture2D inTexture, int inSpeed)
        {
            Grenade_Target = inTarget;
            Grenade_Position = inPosition;
            Grenade_Texture = inTexture;
            Grenade_Speed = inSpeed;
            isGrenadeActive = true;
            Grenade_Direction = -(Grenade_Position - Grenade_Target);
            Grenade_Direction.Normalize();
        }
        public void Update(GameTime gameTime, int inMaxWidth, int inMaxHeight)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Grenade_Position.Y < 0 || Grenade_Position.Y > inMaxHeight || Grenade_Position.X < 0 || Grenade_Position.X > inMaxWidth)
            {
                isGrenadeActive = false;
            }
            Grenade_Position += (Grenade_Direction * Grenade_Speed * elapsedTime);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Grenade_Texture, Grenade_Position, Color.White);
        }
        public void DeactivateGrenade()
        {
            isGrenadeActive = false;
        }
    }
}
