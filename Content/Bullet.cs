using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Bullet
    {
        private Texture2D Bullet_Texture;
        private Vector2 Bullet_Target, Bullet_Position, Bullet_Direction;
        public Vector2 getBullet_Position
        {
            get
            {
                return Bullet_Position;
            }
        }
        public bool isBulletActive;
        private int Bullet_Speed;

        public Bullet()
        {
            isBulletActive = false;
        }
        public void ActivateBullet(Vector2 inTarget, Vector2 inPosition, Texture2D inTexture, int inSpeed)
        {
            Bullet_Target = inTarget;
            Bullet_Position = inPosition;
            Bullet_Texture = inTexture;
            Bullet_Speed = inSpeed;
            isBulletActive = true;
            Bullet_Direction = -(Bullet_Position - Bullet_Target);
            Bullet_Direction.Normalize();
        }
        public void Update(GameTime gameTime, int inMaxWidth, int inMaxHeight)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Bullet_Position.Y < 0 || Bullet_Position.Y > inMaxHeight || Bullet_Position.X < 0 || Bullet_Position.X > inMaxWidth)
            {
                isBulletActive = false;
            }
            Bullet_Position += (Bullet_Direction * Bullet_Speed * elapsedTime);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Bullet_Texture, Bullet_Position, Color.White);
        }
        public void DeactivateBullet()
        {
            isBulletActive = false;
        }
    }
}
