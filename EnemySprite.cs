using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class EnemySprite
    {
        int Old_Wall;
        int Enemy_Rof_Cooldown = 0;
        Vector2 Enemy_Middle, Hero_Middle;
        private String Enemy_Current_Type;
        public String getEnemy_Current_Type
        {
            get
            {
                return Enemy_Current_Type;
            }
        }
        private Texture2D Enemy_Current_Bullet;
        public Texture2D getEnemy_Current_Bullet
        {
            get
            {
                return Enemy_Current_Bullet;
            }
        }
        private Texture2D Enemy_Current_StandRight;
        public Texture2D getEnemy_Current_StandRight
        {
            get
            {
                return Enemy_Current_StandRight;
            }
        }
        private Texture2D Enemy_Current_ShootRight;
        public Texture2D getEnemy_Current_ShootRight
        {
            get
            {
                return Enemy_Current_ShootRight;
            }
        }
        private Texture2D Enemy_Current_StandLeft;
        public Texture2D getEnemy_Current_StandLeft
        {
            get
            {
                return Enemy_Current_StandLeft;
            }
        }
        private Texture2D Enemy_Current_ShootLeft;
        public Texture2D getEnemy_Current_ShootLeft
        {
            get
            {
                return Enemy_Current_ShootLeft;
            }
        }
        private Texture2D Enemy_Current_Picture;
        public Texture2D getEnemy_Current_Picture
        {
            get
            {
                return Enemy_Current_Picture;
            }
        }
        public Texture2D setEnemy_Current_Picture
        {
            set
            {
                Enemy_Current_Picture = value;
            }
        }
        private int Enemy_Current_Rof;
        public int getEnemy_Current_Rof
        {
            get
            {
                return Enemy_Current_Rof;
            }
        }
        private Vector2 Enemy_Current_Position;
        public Vector2 getEnemy_Current_Position
        {
            get
            {
                return Enemy_Current_Position;
            }
        }
        public Vector2 setEnemy_Current_Position
        {
            set
            {
                Enemy_Current_Position = value;
            }
        }
        private int Enemy_Current_Width;
        public int getEnemy_Current_Width
        {
            get
            {
                return Enemy_Current_Width;
            }
        }
        private int Enemy_Current_Height;
        public int getEnemy_Current_Height
        {
            get
            {
                return Enemy_Current_Height;
            }
        }
        private int Enemy_Current_MoveSpeed;
        public int getEnemy_Current_MoveSpeed
        {
            get
            {
                return Enemy_Current_MoveSpeed;
            }
        }
        private int Enemy_Current_Bullet_Speed;
        public int getEnemy_Current_Bullet_Speed
        {
            get
            {
                return Enemy_Current_Bullet_Speed;
            }
        }
        private int Enemy_Current_Lives;
        public int getEnemy_Current_Lives
        {
            get
            {
                return Enemy_Current_Lives;
            }
        }
        public int setEnemy_Current_Lives
        {
            set
            {
                Enemy_Current_Lives = value;
            }
        }
        private bool Update_Enemy = true;
        public bool isEnemyActive = false;

        public EnemySprite()
        {
            isEnemyActive = false;
        }
        public void ActivateEnemy(String inEnemy_Type, Texture2D inEnemy_Bullet, Texture2D inEnemy_Picture, Texture2D inEnemy_StandRight, Texture2D inEnemy_ShootRight, Texture2D inEnemy_StandLeft, Texture2D inEnemy_ShootLeft, int inEnemy_Lives, int inEnemy_MoveSpeed, int inEnemy_Current_Bullet_Speed, int inEnemy_Rof, int inMaxWidth, int inMaxHeight, int inEnemy_Width, int inEnemy_Height, HeroSprite Hero)
        {
            isEnemyActive = true;
            Enemy_Current_Type = inEnemy_Type;
            Enemy_Current_Bullet = inEnemy_Bullet;
            Enemy_Current_Picture = inEnemy_Picture;
            Enemy_Current_StandRight = inEnemy_StandRight;
            Enemy_Current_ShootRight = inEnemy_ShootRight;
            Enemy_Current_StandLeft = inEnemy_StandLeft;
            Enemy_Current_ShootLeft = inEnemy_ShootLeft;
            Enemy_Current_Lives = inEnemy_Lives;
            Enemy_Current_Rof = inEnemy_Rof;
            Enemy_Current_MoveSpeed = inEnemy_MoveSpeed;
            Enemy_Current_Bullet_Speed = inEnemy_Current_Bullet_Speed;
            Enemy_Current_Width = inEnemy_Width;
            Enemy_Current_Height = inEnemy_Height;
            inMaxHeight = inMaxHeight - inEnemy_Height;
            inMaxWidth = inMaxWidth - inEnemy_Width;
            
            //if (Hero.getHero_Position.X > Enemy_Tanks[i].getEnemy_Current_Position.X - 45 && Hero.getHero_Position.X < Enemy_Tanks[i].getEnemy_Current_Position.X + 185)
            //        {
            //            if (Hero.getHero_Position.Y > Enemy_Tanks[i].getEnemy_Current_Position.Y - 85 && Hero.getHero_Position.Y < Enemy_Tanks[i].getEnemy_Current_Position.Y + 225)
                        
            Random Generate_Position = new Random();
            int Which_Wall = Generate_Position.Next(4);
            if (Which_Wall == Old_Wall)
            {
                Which_Wall = Generate_Position.Next(4);
            }
            Old_Wall = Which_Wall;
            if (Which_Wall == 0) //Left wall
            {
                Enemy_Current_Position.X = 0;
                Enemy_Current_Position.Y = Generate_Position.Next(0, inMaxHeight - 50);
                while (Hero.getHero_Position.X > Enemy_Current_Position.X - 45 && Hero.getHero_Position.X < Enemy_Current_Position.X + 185 && Hero.getHero_Position.Y > Enemy_Current_Position.Y - 85 && Hero.getHero_Position.Y < Enemy_Current_Position.Y + 225)
                {
                    Enemy_Current_Position.X = inMaxWidth - 50;
                    Enemy_Current_Position.Y = Generate_Position.Next(inMaxHeight - 50);
                }
                Enemy_Current_Picture = Enemy_Current_StandRight;
            }
            else if (Which_Wall == 1) //Right wall
            {
                Enemy_Current_Position.X = inMaxWidth - 50;
                Enemy_Current_Position.Y = Generate_Position.Next(0, inMaxHeight - 50);
                while (Hero.getHero_Position.X > Enemy_Current_Position.X - 45 && Hero.getHero_Position.X < Enemy_Current_Position.X + 185 && Hero.getHero_Position.Y > Enemy_Current_Position.Y - 85 && Hero.getHero_Position.Y < Enemy_Current_Position.Y + 225)
                {
                    Enemy_Current_Position.X = 0;
                    Enemy_Current_Position.Y = Generate_Position.Next(inMaxHeight - 50);
                }
                Enemy_Current_Picture = Enemy_Current_StandLeft;
            }
            else if (Which_Wall == 2) //Top wall
            {
                Enemy_Current_Position.Y = 0;
                Enemy_Current_Position.X = Generate_Position.Next(0, inMaxWidth - 50);
                while (Hero.getHero_Position.X > Enemy_Current_Position.X - 45 && Hero.getHero_Position.X < Enemy_Current_Position.X + 185 && Hero.getHero_Position.Y > Enemy_Current_Position.Y - 85 && Hero.getHero_Position.Y < Enemy_Current_Position.Y + 225)
                {
                    Enemy_Current_Position.Y = inMaxHeight - 50;
                    Enemy_Current_Position.X = Generate_Position.Next(inMaxWidth - 50);
                }
                Enemy_Current_Picture = Enemy_Current_StandRight;
            }
            else if (Which_Wall == 3) //Bottom wall
            {
                Enemy_Current_Position.Y = inMaxHeight - 50;
                Enemy_Current_Position.X = Generate_Position.Next(0, inMaxWidth - 50);
                while (Hero.getHero_Position.X > Enemy_Current_Position.X - 45 && Hero.getHero_Position.X < Enemy_Current_Position.X + 185 && Hero.getHero_Position.Y > Enemy_Current_Position.Y - 85 && Hero.getHero_Position.Y < Enemy_Current_Position.Y + 225)
                {
                    Enemy_Current_Position.Y = 0;
                    Enemy_Current_Position.X = Generate_Position.Next(inMaxHeight - 50);
                }
                Enemy_Current_Picture = Enemy_Current_StandLeft;
            }
        }
        public void Update(GameTime gameTime, HeroSprite Hero, int inMaxWidth, int inMaxHeight)
        {
            if (Update_Enemy == true)
            {
                float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                Vector2 Move_Towards = -(this.getEnemy_Current_Position - Hero.getHero_Position);
                Move_Towards.Normalize();
                this.setEnemy_Current_Position = this.getEnemy_Current_Position + (Move_Towards * this.getEnemy_Current_MoveSpeed * elapsedTime);
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (this != null)
            {
                spriteBatch.Draw(this.getEnemy_Current_Picture, Enemy_Current_Position, Color.White);
            }
        }
        public void Revert()
        {
            if (this.getEnemy_Current_Picture == this.getEnemy_Current_ShootRight)
            {
                this.setEnemy_Current_Picture = this.getEnemy_Current_StandRight;
            }
            else if (this.getEnemy_Current_Picture == this.getEnemy_Current_ShootLeft)
            {
                this.setEnemy_Current_Picture = this.getEnemy_Current_StandLeft;
            }
            Update_Enemy = true;
        }
        public void DeactivateEnemy()
        {
            isEnemyActive = false;
        }
        public bool Enemy_Attack(HeroSprite Hero, int Hero_Width, int Hero_Height, int Enemy_Charger_Width, int Enemy_Charger_Height)
        {
            if (Enemy_Rof_Cooldown <= this.getEnemy_Current_Rof)
            {
                Enemy_Rof_Cooldown++;
            }
            if (this.getEnemy_Current_Position.X > Hero.getHero_Position.X - Enemy_Charger_Width && this.getEnemy_Current_Position.X < Hero.getHero_Position.X + Hero_Width + Enemy_Charger_Width - 20)
            {
                if (this.getEnemy_Current_Position.Y > Hero.getHero_Position.Y - Enemy_Charger_Height && this.getEnemy_Current_Position.Y < Hero.getHero_Position.Y + Hero_Height + Enemy_Charger_Height)
                {
                    if (Enemy_Rof_Cooldown >= this.getEnemy_Current_Rof)
                    {
                        Update_Enemy = false;
                        if (this.getEnemy_Current_Picture == this.getEnemy_Current_StandRight)
                        {
                            this.setEnemy_Current_Picture = this.getEnemy_Current_ShootRight;
                        }
                        else if (this.getEnemy_Current_Picture == this.getEnemy_Current_StandLeft)
                        {
                            this.setEnemy_Current_Picture = this.getEnemy_Current_ShootLeft;
                        }
                        Enemy_Rof_Cooldown = 0;
                        return true;
                    }
                }
            }
            if (Enemy_Rof_Cooldown == 30)
            {
                this.Revert();
            }
            return false;
        }
        public void Enemy_Aim(HeroSprite Hero)
        {
            if (Update_Enemy == true)
            {
                if (Hero.getHero_Position.X > this.getEnemy_Current_Position.X)
                {
                    if (this.getEnemy_Current_Picture == this.getEnemy_Current_ShootRight || this.getEnemy_Current_Picture == this.getEnemy_Current_ShootLeft)
                    {
                        this.setEnemy_Current_Picture = this.getEnemy_Current_ShootRight;
                    }
                    else if (this.getEnemy_Current_Picture == this.getEnemy_Current_StandRight || this.getEnemy_Current_Picture == this.getEnemy_Current_StandLeft)
                    {
                        this.setEnemy_Current_Picture = this.getEnemy_Current_StandRight;
                    }
                }
                else if (Hero.getHero_Position.X < this.getEnemy_Current_Position.X)
                {
                    if (this.getEnemy_Current_Picture == this.getEnemy_Current_ShootRight || this.getEnemy_Current_Picture == this.getEnemy_Current_ShootLeft)
                    {
                        this.setEnemy_Current_Picture = this.getEnemy_Current_ShootLeft;
                    }
                    else if (this.getEnemy_Current_Picture == this.getEnemy_Current_StandRight || this.getEnemy_Current_Picture == this.getEnemy_Current_StandLeft)
                    {
                        this.setEnemy_Current_Picture = this.getEnemy_Current_StandLeft;
                    }
                }
            }
        }
        public void Enemy_Shoot(HeroSprite Hero, List<Bullet> Enemy_Bullets)
        {
            if (this.isEnemyActive == true)
            {
                //isAttacking = true;
                Enemy_Rof_Cooldown++;
                this.Enemy_Aim(Hero);
                if (Enemy_Rof_Cooldown >= this.getEnemy_Current_Rof)
                {
                    Update_Enemy = false;
                    if (this.getEnemy_Current_Picture == this.getEnemy_Current_StandRight)
                    {
                        this.setEnemy_Current_Picture = this.getEnemy_Current_ShootRight;
                    }
                    else if (this.getEnemy_Current_Picture == this.getEnemy_Current_StandLeft)
                    {
                        this.setEnemy_Current_Picture = this.getEnemy_Current_ShootLeft;
                    }
                    for (int i = 0; i < Enemy_Bullets.Count; i++)
                    {
                        if (Enemy_Bullets[i].isBulletActive == false)
                        {
                            Enemy_Middle = new Vector2(this.getEnemy_Current_Position.X + this.getEnemy_Current_Width / 2, this.getEnemy_Current_Position.Y + this.getEnemy_Current_Height / 2);
                            Hero_Middle = new Vector2(Hero.getHero_Position.X + 20, Hero.getHero_Position.Y + 30);
                            Enemy_Bullets[i].ActivateBullet(Hero_Middle, Enemy_Middle, Enemy_Current_Bullet, Enemy_Current_Bullet_Speed);
                            Enemy_Rof_Cooldown = 0;
                            break;
                        }
                    }
                    Enemy_Rof_Cooldown = 0;
                }
                if (Enemy_Rof_Cooldown == 10)
                {
                    this.Revert();
                }
            }
        }
    }
}


