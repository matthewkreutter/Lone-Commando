using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private KeyboardState oldKeyboardState;
        private MouseState oldMouseState;
        private int Screen_Width, Screen_Height;

        private bool Draw_Background = true;
        private Texture2D Background_Texture, GameOver_Background;
        private Rectangle Screen_Rectangle;

        private bool Dev_Mode = false;

        private Texture2D Tree1;
        private Vector2 Tree_Position1, Tree_Position2, Tree_Position3, Tree_Position4;
        //private Vector2 Tree_Position5, Tree_Position6;

        private Texture2D Powerup_Godmode, Powerup_Gun, Powerup_Heart, Powerup_Speed;
        private bool Godmode = false, SuperGun = false, SuperSpeed = false, Powerup_isActive = false;
        private int Powerup_Spawn_Counter = 0, Powerup_Duration = 0, Powerup_OldChoice = 0, Powerup_OldOldChoice = 0, Powerup_Spawn_Rate;
        private Vector2 Powerup_Active_Position;
        private List<Powerup> Powerups = new List<Powerup>();
        private String Effect_ToBeActive, Effect_Current;

        private List<Bullet> Hero_Bullets = new List<Bullet>();
        private List<Grenade> Hero_Grenades = new List<Grenade>();
        private int Hero_Rof_Cooldown = 0, Hero_Rof_Limit = 15, Hero_Bullet_Speed = 2000, Hero_Grenade_Cooldown = 0, Hero_Grenade_Limit = 60, Hero_Grenade_Speed = 500, Hero_Width = 50, Hero_Height = 90;
        private bool isShieldOn = false;
        private Texture2D Explosion, Hero_Stand_Right, Hero_Move_Right, Hero_Stand_Left, Hero_Move_Left, Hero_Stand_Up, Hero_Move_Up, Hero_Stand_Down, Hero_Move_Down, Shield_Final, Hero_Bullet, Hero_Grenade, Hero_Heart, Crosshair_Final;
        private Vector2 Crosshair_Position, Hero_Start_Position, Hero_Middle;
        private HeroSprite Hero;

        private int Enemy_Tank_Spawn_Counter = 0, Enemy_Tank_Spawn_Rate = 400, Enemy_Grunt_Spawn_Counter = 0, Enemy_Grunt_Spawn_Rate = 200, Enemy_Charger_Spawn_Counter = 0, Enemy_Charger_Spawn_Rate = 150;

        private List<EnemySprite> Enemy_Tanks = new List<EnemySprite>();
        private List<Bullet> Enemy_Tank_Bullets = new List<Bullet>();
        private Texture2D Enemy_Tank_ShootRight, Enemy_Tank_StandRight, Enemy_Tank_ShootLeft, Enemy_Tank_StandLeft, Enemy_Tank_Bullet;
        private int Enemy_Tank_Rof = 80, Enemy_Tank_Lives = 4, Enemy_Tank_Width = 140, Enemy_Tank_Height = 140, Enemy_Tank_MoveSpeed = 5, Enemy_Tank_Bullet_Speed = 300;

        private List<EnemySprite> Enemy_Grunts = new List<EnemySprite>();
        private List<Bullet> Enemy_Grunt_Bullets = new List<Bullet>();
        private Texture2D Enemy_Grunt_ShootRight, Enemy_Grunt_StandRight, Enemy_Grunt_ShootLeft, Enemy_Grunt_StandLeft, Enemy_Grunt_Bullet;
        private int Enemy_Grunt_Rof = 40, Enemy_Grunt_Lives = 2, Enemy_Grunt_Width = 80, Enemy_Grunt_Height = 80, Enemy_Grunt_MoveSpeed = 10, Enemy_Grunt_Bullet_Speed = 500;

        private List<EnemySprite> Enemy_Chargers = new List<EnemySprite>();
        private Texture2D Enemy_Charger_AttackRight, Enemy_Charger_RunRight, Enemy_Charger_AttackLeft, Enemy_Charger_RunLeft;
        private int Enemy_Charger_Rof = 50, Enemy_Charger_Lives = 1, Enemy_Charger_Width = 100, Enemy_Charger_Height = 40, Enemy_Charger_MoveSpeed = 200;

        private HUD Hud;

        private Menu Menu;
        private String GameState = "Menu", OldGameState = "";
        private Texture2D Menu_Background;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2;
            this.graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2;
            //this.graphics.IsFullScreen = true;
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Screen_Width = graphics.GraphicsDevice.Viewport.Width / 2;
            Screen_Height = graphics.GraphicsDevice.Viewport.Height / 2;
            if (Draw_Background == true)
            {
                Background_Texture = Content.Load<Texture2D>("Grass_Background2");
            }
            Screen_Rectangle = new Rectangle(0, 0, Screen_Width, Screen_Height);

            Hud = new HUD();
            Hud.Font = Content.Load<SpriteFont>("Arial");
            Hud.Lives = 3;
            Hud.Score = 0;
            Hud.Wave = 0;

            Tree1 = Content.Load<Texture2D>("Tree1");
            Random Generate_Tree_Position = new Random();
            int Tree_Position1_X = Generate_Tree_Position.Next(100, Screen_Width / 2 - 80), Tree_Position1_Y = Generate_Tree_Position.Next(100, Screen_Height / 2 - 105);
            int Tree_Position2_X = Generate_Tree_Position.Next(100, Screen_Width / 2 - 80), Tree_Position2_Y = Generate_Tree_Position.Next(Screen_Height / 2 + 105, Screen_Height - 215);
            int Tree_Position3_X = Generate_Tree_Position.Next(Screen_Width / 2 + 80, Screen_Width - 165), Tree_Position3_Y = Generate_Tree_Position.Next(100, Screen_Height / 2 - 105);
            int Tree_Position4_X = Generate_Tree_Position.Next(Screen_Width / 2 + 80, Screen_Width - 165), Tree_Position4_Y = Generate_Tree_Position.Next(Screen_Height / 2 + 105, Screen_Height - 215);
            //int Tree_Position5_X = Generate_Tree_Position.Next(800, 1100), Tree_Position5_Y = Generate_Tree_Position.Next(50, 400);
            //int Tree_Position6_X = Generate_Tree_Position.Next(800, 1100), Tree_Position6_Y = Generate_Tree_Position.Next(500, 800);
            Tree_Position1 = new Vector2(Tree_Position1_X, Tree_Position1_Y);
            Tree_Position2 = new Vector2(Tree_Position2_X, Tree_Position2_Y);
            Tree_Position3 = new Vector2(Tree_Position3_X, Tree_Position3_Y);
            Tree_Position4 = new Vector2(Tree_Position4_X, Tree_Position4_Y);
            //Tree_Position5 = new Vector2(Tree_Position5_X, Tree_Position5_Y);
            //Tree_Position6 = new Vector2(Tree_Position6_X, Tree_Position6_Y);

            Hero_Bullet = Content.Load<Texture2D>("Hero_Bullet");
            for (int i = 0; i < 10; i++)
            {
                Hero_Bullets.Add(new Bullet());
            }
            Hero_Grenade = Content.Load<Texture2D>("Hero_Grenade");
            for (int i = 0; i < 4; i++)
            {
                Hero_Grenades.Add(new Grenade());
            }
            Explosion = Content.Load<Texture2D>("Explosion");
            Hero_Stand_Right = Content.Load<Texture2D>("Hero_Stand_Right");
            Hero_Move_Right = Content.Load<Texture2D>("Hero_Move_Right");
            Hero_Stand_Left = Content.Load<Texture2D>("Hero_Stand_Left");
            Hero_Move_Left = Content.Load<Texture2D>("Hero_Move_Left");
            Hero_Stand_Up = Content.Load<Texture2D>("Hero_Stand_Up");
            Hero_Move_Up = Content.Load<Texture2D>("Hero_Move_Up");
            Hero_Stand_Down = Content.Load<Texture2D>("Hero_Stand_Down");
            Hero_Move_Down = Content.Load<Texture2D>("Hero_Move_Down");
            Hero_Heart = Content.Load<Texture2D>("Hero_Heart");
            Crosshair_Final = Content.Load<Texture2D>("Crosshair_Final");
            Shield_Final = Content.Load<Texture2D>("Shield_Final");
            Hero_Start_Position = new Vector2(Screen_Width / 2, Screen_Height / 2);
            Hero = new HeroSprite(Hero_Stand_Right, Hero_Move_Right, Hero_Stand_Left, Hero_Move_Left, Hero_Stand_Up, Hero_Move_Up, Hero_Stand_Down, Hero_Move_Down, Shield_Final, Hero_Start_Position);

            Powerup_Godmode = Content.Load<Texture2D>("Powerup_Godmode");
            Powerup_Gun = Content.Load<Texture2D>("Powerup_Gun");
            Powerup_Speed = Content.Load<Texture2D>("Powerup_Speed");
            Powerup_Heart = Content.Load<Texture2D>("Powerup_Heart");
            Powerup_Spawn_Rate = 400;
            for (int i = 0; i < 4; i++)
            {
                Powerups.Add(new Powerup());
            }

            Enemy_Tank_ShootRight = Content.Load<Texture2D>("Enemy_Tank_ShootRight");
            Enemy_Tank_StandRight = Content.Load<Texture2D>("Enemy_Tank_StandRight");
            Enemy_Tank_ShootLeft = Content.Load<Texture2D>("Enemy_Tank_ShootLeft");
            Enemy_Tank_StandLeft = Content.Load<Texture2D>("Enemy_Tank_StandLeft");
            Enemy_Tank_Bullet = Content.Load<Texture2D>("Enemy_Tank_Bullet");
            for (int i = 0; i < 4; i++)
            {
                Enemy_Tanks.Add(new EnemySprite());
            }
            for (int i = 0; i < 20; i++)
            {
                Enemy_Tank_Bullets.Add(new Bullet());
            }

            Enemy_Grunt_ShootRight = Content.Load<Texture2D>("Enemy_Grunt_ShootRight");
            Enemy_Grunt_StandRight = Content.Load<Texture2D>("Enemy_Grunt_StandRight");
            Enemy_Grunt_ShootLeft = Content.Load<Texture2D>("Enemy_Grunt_ShootLeft");
            Enemy_Grunt_StandLeft = Content.Load<Texture2D>("Enemy_Grunt_StandLeft");
            Enemy_Grunt_Bullet = Content.Load<Texture2D>("Hero_Bullet");
            for (int i = 0; i < 4; i++)
            {
                Enemy_Grunts.Add(new EnemySprite());
            }
            for (int i = 0; i < 20; i++)
            {
                Enemy_Grunt_Bullets.Add(new Bullet());
            }

            Enemy_Charger_AttackRight = Content.Load<Texture2D>("Enemy_Charger_AttackRight");
            Enemy_Charger_RunRight = Content.Load<Texture2D>("Enemy_Charger_RunRight");
            Enemy_Charger_AttackLeft = Content.Load<Texture2D>("Enemy_Charger_AttackLeft");
            Enemy_Charger_RunLeft = Content.Load<Texture2D>("Enemy_Charger_RunLeft");
            for (int i = 0; i < 4; i++)
            {
                Enemy_Chargers.Add(new EnemySprite());
            }

            //Menu_Background = Content.Load<Texture2D>("Menu_Background"); 
            Menu_Background = Content.Load<Texture2D>("Grass_Background2");
            Texture2D Help = Content.Load<Texture2D>("Help");
            Menu = new Menu(Content.Load<SpriteFont>("Arial"), graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, Crosshair_Final, Help);

            GameOver_Background = Content.Load<Texture2D>("Game_Over_Screen");

        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            if (GameState == "Quit")
            {
                this.Exit();
            }
            UpdateInput();
            if (GameState == "Game")
            {
                Hero_Rof_Cooldown++;
                Hero_Grenade_Cooldown++;
                Powerup_Active_Position = new Vector2(Hero.getHero_Position.X + 5, Hero.getHero_Position.Y - 30);
                if (Powerup_isActive == true)
                {
                    Powerup_Duration--;
                }
                if (Powerup_Duration == 0)
                {
                    Powerup_isActive = false;
                    Godmode = false;
                    SuperGun = false;
                    SuperSpeed = false;
                    Hero_Rof_Limit = 15;
                    Hero_Grenade_Limit = 60;
                    Hero.setHero_Speed = 1;
                }

                Powerup_Spawn_Counter++;
                if (Powerup_Spawn_Counter % Powerup_Spawn_Rate == 0)
                {
                    Random Generate_Powerup = new Random();
                    int Powerup_X = Generate_Powerup.Next(100, Screen_Width - 100);
                    int Powerup_Y = Generate_Powerup.Next(100, Screen_Height - 100);
                    Vector2 Powerup_Spawn_Position = new Vector2(Powerup_X, Powerup_Y);
                    int Powerup_Choice = Generate_Powerup.Next(4);
                    while (Powerup_Choice == Powerup_OldChoice || Powerup_Choice == Powerup_OldOldChoice)
                    {
                        Powerup_Choice = Generate_Powerup.Next(4);
                    }
                    if (Powerup_Choice == 0)
                    {
                        for (int i = 0; i < Powerups.Count; i++)
                        {
                            if (Powerups[i].isPowerupActive == true)
                            {
                                Powerups[i].DeactivatePowerup();
                            }
                            else if (Powerups[i].isPowerupActive == false)
                            {
                                Powerups[i].ActivatePowerup(Powerup_Godmode, Powerup_Spawn_Position, "Godmode");
                                Powerup_OldOldChoice = Powerup_OldChoice;
                                Powerup_OldChoice = Powerup_Choice;
                                break;
                            }
                        }
                    }
                    else if (Powerup_Choice == 1)
                    {
                        for (int i = 0; i < Powerups.Count; i++)
                        {
                            if (Powerups[i].isPowerupActive == true)
                            {
                                Powerups[i].DeactivatePowerup();
                            }
                            else if (Powerups[i].isPowerupActive == false)
                            {
                                Powerups[i].ActivatePowerup(Powerup_Speed, Powerup_Spawn_Position, "SuperSpeed");
                                Powerup_OldOldChoice = Powerup_OldChoice;
                                Powerup_OldChoice = Powerup_Choice;
                                break;
                            }
                        }
                    }
                    else if (Powerup_Choice == 2)
                    {
                        for (int i = 0; i < Powerups.Count; i++)
                        {
                            if (Powerups[i].isPowerupActive == true)
                            {
                                Powerups[i].DeactivatePowerup();
                            }
                            else if (Powerups[i].isPowerupActive == false)
                            {
                                Powerups[i].ActivatePowerup(Powerup_Heart, Powerup_Spawn_Position, "Heart");
                                Powerup_OldOldChoice = Powerup_OldChoice;
                                Powerup_OldChoice = Powerup_Choice;
                                break;
                            }
                        }
                    }
                    else if (Powerup_Choice == 3)
                    {
                        for (int i = 0; i < Powerups.Count; i++)
                        {
                            if (Powerups[i].isPowerupActive == true)
                            {
                                Powerups[i].DeactivatePowerup();
                            }
                            else if (Powerups[i].isPowerupActive == false)
                            {
                                Powerups[i].ActivatePowerup(Powerup_Gun, Powerup_Spawn_Position, "SuperGun");
                                Powerup_OldOldChoice = Powerup_OldChoice;
                                Powerup_OldChoice = Powerup_Choice;
                                break;
                            }
                        }
                    }
                }

                for (int i = 0; i < Powerups.Count; i++)
                {
                    if (Powerups[i].isPowerupActive)
                    {
                        if (Hero.getHero_Position.X > Powerups[i].getPowerup_Position.X - 45 && Hero.getHero_Position.X < Powerups[i].getPowerup_Position.X + 40)
                        {
                            if (Hero.getHero_Position.Y > Powerups[i].getPowerup_Position.Y - 80 && Hero.getHero_Position.Y < Powerups[i].getPowerup_Position.Y + 80)
                            {
                                Powerups[i].isPowerupActive = false;
                                Effect_ToBeActive = Powerups[i].Powerup_Effect();
                                if (Effect_ToBeActive == "Godmode")
                                {
                                    Godmode = true;
                                    Powerup_isActive = true;
                                    Effect_Current = Effect_ToBeActive;
                                    Effect_ToBeActive = "";
                                    Powerup_Duration = 150;
                                }
                                else if (Effect_ToBeActive == "SuperGun")
                                {
                                    SuperGun = true;
                                    Powerup_isActive = true;
                                    Hero_Rof_Cooldown = 0;
                                    Hero_Rof_Limit = 7;
                                    Hero_Grenade_Cooldown = 0;
                                    Hero_Grenade_Limit = 30;
                                    Effect_Current = Effect_ToBeActive;
                                    Effect_ToBeActive = "";
                                    Powerup_Duration = 250;
                                }
                                else if (Effect_ToBeActive == "Heart")
                                {
                                    Hud.Lives++;
                                    Powerup_isActive = true;
                                    Effect_Current = Effect_ToBeActive;
                                    Effect_ToBeActive = "";
                                    Powerup_Duration = 100;
                                }
                                else if (Effect_ToBeActive == "SuperSpeed")
                                {
                                    SuperSpeed = true;
                                    Powerup_isActive = true;
                                    Hero.setHero_Speed = 2;
                                    Effect_Current = Effect_ToBeActive;
                                    Effect_ToBeActive = "";
                                    Powerup_Duration = 250;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < Hero_Bullets.Count; i++)
                {
                    if (Hero_Bullets[i].isBulletActive)
                    {
                        Hero_Bullets[i].Update(gameTime, Screen_Width, Screen_Height);
                    }
                }
                for (int i = 0; i < Hero_Grenades.Count; i++)
                {
                    if (Hero_Grenades[i].isGrenadeActive)
                    {
                        Hero_Grenades[i].Update(gameTime, Screen_Width, Screen_Height);
                    }
                }

                Hud.Wave = (int)(1 + (Hud.Score / 50));

                Enemy_Grunt_Spawn_Counter++;
                if (Enemy_Grunt_Spawn_Counter % Enemy_Grunt_Spawn_Rate == 0)
                {
                    for (int i = 0; i < Enemy_Grunts.Count; i++)
                    {
                        if (Enemy_Grunts[i].isEnemyActive == false)
                        {
                            Enemy_Grunts[i].ActivateEnemy("Grunt", Enemy_Grunt_Bullet, Enemy_Grunt_StandRight, Enemy_Grunt_StandRight, Enemy_Grunt_ShootRight, Enemy_Grunt_StandLeft, Enemy_Grunt_ShootLeft, Enemy_Grunt_Lives, Enemy_Grunt_MoveSpeed, Enemy_Grunt_Bullet_Speed, Enemy_Grunt_Rof, Screen_Width, Screen_Height, Enemy_Grunt_Width, Enemy_Grunt_Height, Hero);
                            break;
                        }
                    }
                }
                for (int i = 0; i < Enemy_Grunts.Count; i++)
                {
                    if (Enemy_Grunts[i].isEnemyActive)
                    {
                        Enemy_Grunts[i].Update(gameTime, Hero, Screen_Width, Screen_Height);
                    }
                }
                for (int i = 0; i < Enemy_Grunts.Count; i++)
                {
                    if (Enemy_Grunts[i].isEnemyActive)
                    {
                        Enemy_Grunts[i].Enemy_Shoot(Hero, Enemy_Grunt_Bullets);
                    }
                }
                for (int i = 0; i < Enemy_Grunts.Count; i++) //Hero bullet to enemy Grunt collision
                {
                    if (Enemy_Grunts[i].isEnemyActive)
                    {
                        for (int j = 0; j < Hero_Bullets.Count; j++)
                        {
                            if (Hero_Bullets[j].isBulletActive)
                            {
                                if (Hero_Bullets[j].getBullet_Position.X > Enemy_Grunts[i].getEnemy_Current_Position.X && Hero_Bullets[j].getBullet_Position.X < Enemy_Grunts[i].getEnemy_Current_Position.X + Enemy_Grunt_Width)
                                {
                                    if (Hero_Bullets[j].getBullet_Position.Y > Enemy_Grunts[i].getEnemy_Current_Position.Y && Hero_Bullets[j].getBullet_Position.Y < Enemy_Grunts[i].getEnemy_Current_Position.Y + Enemy_Grunt_Height)
                                    {
                                        Enemy_Grunts[i].setEnemy_Current_Lives = Enemy_Grunts[i].getEnemy_Current_Lives - 1;
                                        if (Enemy_Grunts[i].getEnemy_Current_Lives == 0)
                                        {
                                            Enemy_Grunts[i].DeactivateEnemy();
                                            Hud.Score += 10;
                                        }
                                        Hero_Bullets[j].DeactivateBullet();
                                    }
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i < Enemy_Grunts.Count; i++) //Hero grenade to enemy Grunt collision
                {
                    if (Enemy_Grunts[i].isEnemyActive)
                    {
                        for (int j = 0; j < Hero_Grenades.Count; j++)
                        {
                            if (Hero_Grenades[j].isGrenadeActive)
                            {
                                if (Hero_Grenades[j].getGrenade_Position.X > Enemy_Grunts[i].getEnemy_Current_Position.X && Hero_Grenades[j].getGrenade_Position.X < Enemy_Grunts[i].getEnemy_Current_Position.X + Enemy_Grunt_Width)
                                {
                                    if (Hero_Grenades[j].getGrenade_Position.Y > Enemy_Grunts[i].getEnemy_Current_Position.Y && Hero_Grenades[j].getGrenade_Position.Y < Enemy_Grunts[i].getEnemy_Current_Position.Y + Enemy_Grunt_Height)
                                    {
                                        //AoE explosion
                                        Enemy_Grunts[i].DeactivateEnemy();
                                        Hud.Score += 10;
                                        Grenade_Explode(Hero_Grenades[j]);
                                    }
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i < Enemy_Grunts.Count; i++) //Hero to enemy Grunt collision
                {
                    if (Enemy_Grunts[i].getEnemy_Current_Position.X > Hero.getHero_Position.X - Enemy_Grunt_Width && Enemy_Grunts[i].getEnemy_Current_Position.X < Hero.getHero_Position.X + Hero_Width + Enemy_Grunt_Width)
                    {
                        if (Enemy_Grunts[i].getEnemy_Current_Position.Y > Hero.getHero_Position.Y - Enemy_Grunt_Height && Enemy_Grunts[i].getEnemy_Current_Position.Y < Hero.getHero_Position.Y + Hero_Height + Enemy_Grunt_Height)
                        {
                            if (isShieldOn == false)
                            {
                                if (Dev_Mode == false && Godmode == false)
                                {
                                    Hero.DeactivateHero();
                                    GameState = "GameOver";
                                }
                                Enemy_Grunts[i].DeactivateEnemy();
                                //Hud.Score += 10;
                            }
                            else
                            {
                                Enemy_Grunts[i].DeactivateEnemy();
                            }
                        }
                    }
                }
                for (int i = 0; i < Enemy_Grunt_Bullets.Count; i++) //Enemy Grunt bullet to hero collision
                {
                    if (Enemy_Grunt_Bullets[i].isBulletActive)
                    {
                        Enemy_Grunt_Bullets[i].Update(gameTime, Screen_Width, Screen_Height);
                        if (Enemy_Grunt_Bullets[i].getBullet_Position.X > Hero.getHero_Position.X && Enemy_Grunt_Bullets[i].getBullet_Position.X < Hero.getHero_Position.X + Hero_Width)
                        {
                            if (Enemy_Grunt_Bullets[i].getBullet_Position.Y > Hero.getHero_Position.Y && Enemy_Grunt_Bullets[i].getBullet_Position.Y < Hero.getHero_Position.Y + Hero_Height)
                            {
                                Enemy_Grunt_Bullets[i].DeactivateBullet();
                                if (isShieldOn == false)
                                {
                                    if (Dev_Mode == false && Godmode == false)
                                    {
                                        Hud.Lives--;
                                        if (Hud.Lives == 0)
                                        {
                                            Hero.DeactivateHero();
                                            GameState = "GameOver";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i < Hero_Grenades.Count; i++)
                {
                    if (Hero_Grenades[i].getGrenade_Position.X >= Hero_Grenades[i].getGrenade_Target.X - 20 && Hero_Grenades[i].getGrenade_Position.X <= Hero_Grenades[i].getGrenade_Target.X + 20)
                    {
                        if (Hero_Grenades[i].getGrenade_Position.Y >= Hero_Grenades[i].getGrenade_Target.Y - 20 && Hero_Grenades[i].getGrenade_Position.Y <= Hero_Grenades[i].getGrenade_Target.Y + 20)
                        {
                            //AoE explosion
                            Grenade_Explode(Hero_Grenades[i]);
                        }
                    }
                }
                if (Hud.Score >= 50)
                {
                    Enemy_Tank_Spawn_Counter++;
                    if (Enemy_Tank_Spawn_Counter % Enemy_Tank_Spawn_Rate == 0)
                    {
                        for (int i = 0; i < Enemy_Tanks.Count; i++)
                        {
                            if (Enemy_Tanks[i].isEnemyActive == false)
                            {
                                Enemy_Tanks[i].ActivateEnemy("Tank", Enemy_Tank_Bullet, Enemy_Tank_StandRight, Enemy_Tank_StandRight, Enemy_Tank_ShootRight, Enemy_Tank_StandLeft, Enemy_Tank_ShootLeft, Enemy_Tank_Lives, Enemy_Tank_MoveSpeed, Enemy_Tank_Bullet_Speed, Enemy_Tank_Rof, Screen_Width, Screen_Height, Enemy_Tank_Width, Enemy_Tank_Height, Hero);
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < Enemy_Tanks.Count; i++)
                    {
                        if (Enemy_Tanks[i].isEnemyActive)
                        {
                            Enemy_Tanks[i].Update(gameTime, Hero, Screen_Width, Screen_Height);
                        }
                    }
                    for (int i = 0; i < Enemy_Tanks.Count; i++)
                    {
                        if (Enemy_Tanks[i].isEnemyActive)
                        {
                            Enemy_Tanks[i].Enemy_Shoot(Hero, Enemy_Tank_Bullets);
                        }
                    }
                    for (int i = 0; i < Enemy_Tanks.Count; i++) //Hero bullet to enemy tank collision
                    {
                        if (Enemy_Tanks[i].isEnemyActive)
                        {
                            for (int j = 0; j < Hero_Bullets.Count; j++)
                            {
                                if (Hero_Bullets[j].isBulletActive)
                                {
                                    if (Hero_Bullets[j].getBullet_Position.X > Enemy_Tanks[i].getEnemy_Current_Position.X && Hero_Bullets[j].getBullet_Position.X < Enemy_Tanks[i].getEnemy_Current_Position.X + Enemy_Tank_Width)
                                    {
                                        if (Hero_Bullets[j].getBullet_Position.Y > Enemy_Tanks[i].getEnemy_Current_Position.Y && Hero_Bullets[j].getBullet_Position.Y < Enemy_Tanks[i].getEnemy_Current_Position.Y + Enemy_Tank_Height)
                                        {
                                            Enemy_Tanks[i].setEnemy_Current_Lives = Enemy_Tanks[i].getEnemy_Current_Lives - 1;
                                            if (Enemy_Tanks[i].getEnemy_Current_Lives == 0)
                                            {
                                                Enemy_Tanks[i].DeactivateEnemy();
                                                Hud.Score += 10;
                                            }
                                            Hero_Bullets[j].DeactivateBullet();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    for (int i = 0; i < Enemy_Tanks.Count; i++) //Hero grenade to enemy tank collision
                    {
                        if (Enemy_Tanks[i].isEnemyActive)
                        {
                            for (int j = 0; j < Hero_Grenades.Count; j++)
                            {
                                if (Hero_Grenades[j].isGrenadeActive)
                                {
                                    if (Hero_Grenades[j].getGrenade_Position.X > Enemy_Tanks[i].getEnemy_Current_Position.X && Hero_Grenades[j].getGrenade_Position.X < Enemy_Tanks[i].getEnemy_Current_Position.X + Enemy_Tank_Width)
                                    {
                                        if (Hero_Grenades[j].getGrenade_Position.Y > Enemy_Tanks[i].getEnemy_Current_Position.Y && Hero_Grenades[j].getGrenade_Position.Y < Enemy_Tanks[i].getEnemy_Current_Position.Y + Enemy_Tank_Height)
                                        {
                                            //AoE explosion
                                            Enemy_Tanks[i].DeactivateEnemy();
                                            Hud.Score += 20;
                                            Grenade_Explode(Hero_Grenades[j]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    for (int i = 0; i < Enemy_Tanks.Count; i++) //Hero to enemy tank collision
                    {
                        if (Enemy_Tanks[i].getEnemy_Current_Position.X > Hero.getHero_Position.X - Enemy_Tank_Width && Enemy_Tanks[i].getEnemy_Current_Position.X < Hero.getHero_Position.X + Hero_Width + Enemy_Tank_Width)
                        {
                            if (Enemy_Tanks[i].getEnemy_Current_Position.Y > Hero.getHero_Position.Y - Enemy_Tank_Height && Enemy_Tanks[i].getEnemy_Current_Position.Y < Hero.getHero_Position.Y + Hero_Height + Enemy_Tank_Height)
                            {
                                if (isShieldOn == false)
                                {
                                    if (Dev_Mode == false && Godmode == false)
                                    {
                                        Hero.DeactivateHero();
                                        GameState = "GameOver";
                                    }
                                    Enemy_Tanks[i].DeactivateEnemy();
                                    //Hud.Score += 20;
                                }
                                else
                                {
                                    Enemy_Tanks[i].DeactivateEnemy();
                                }
                            }
                        }
                    }
                    for (int i = 0; i < Enemy_Tank_Bullets.Count; i++) //Enemy tank bullet to hero collision
                    {
                        if (Enemy_Tank_Bullets[i].isBulletActive)
                        {
                            Enemy_Tank_Bullets[i].Update(gameTime, Screen_Width, Screen_Height);
                            if (Enemy_Tank_Bullets[i].getBullet_Position.X > Hero.getHero_Position.X && Enemy_Tank_Bullets[i].getBullet_Position.X < Hero.getHero_Position.X + Hero_Width)
                            {
                                if (Enemy_Tank_Bullets[i].getBullet_Position.Y > Hero.getHero_Position.Y && Enemy_Tank_Bullets[i].getBullet_Position.Y < Hero.getHero_Position.Y + Hero_Height)
                                {
                                    Enemy_Tank_Bullets[i].DeactivateBullet();
                                    if (isShieldOn == false)
                                    {
                                        if (Dev_Mode == false && Godmode == false)
                                        {
                                            Hud.Lives--;
                                            if (Hud.Lives == 0)
                                            {
                                                Hero.DeactivateHero();
                                                GameState = "GameOver";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //if (Hud.Score >= 150)
                if (Hud.Score >= 0)
                {
                    Enemy_Charger_Spawn_Counter++;
                    if (Enemy_Charger_Spawn_Counter % Enemy_Charger_Spawn_Rate == 0)
                    {
                        for (int i = 0; i < Enemy_Chargers.Count; i++)
                        {
                            if (Enemy_Chargers[i].isEnemyActive == false)
                            {
                                Enemy_Chargers[i].ActivateEnemy("Charger", Enemy_Charger_RunRight, Enemy_Charger_RunRight, Enemy_Charger_RunRight, Enemy_Charger_AttackRight, Enemy_Charger_RunLeft, Enemy_Charger_AttackLeft, Enemy_Charger_Lives, Enemy_Charger_MoveSpeed, 0, Enemy_Charger_Rof, Screen_Width, Screen_Height, Enemy_Charger_Width, Enemy_Charger_Height, Hero);
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < Enemy_Chargers.Count; i++)
                    {
                        if (Enemy_Chargers[i].isEnemyActive)
                        {
                            Enemy_Chargers[i].Update(gameTime, Hero, Screen_Width, Screen_Height);
                            Enemy_Chargers[i].Enemy_Aim(Hero);
                        }
                    }
                    for (int i = 0; i < Enemy_Chargers.Count; i++) //Hero grenade to enemy Charger collision
                    {
                        if (Enemy_Chargers[i].isEnemyActive)
                        {
                            for (int j = 0; j < Hero_Grenades.Count; j++)
                            {
                                if (Hero_Grenades[j].isGrenadeActive)
                                {
                                    if (Hero_Grenades[j].getGrenade_Position.X > Enemy_Chargers[i].getEnemy_Current_Position.X && Hero_Grenades[j].getGrenade_Position.X < Enemy_Chargers[i].getEnemy_Current_Position.X + Enemy_Charger_Width)
                                    {
                                        if (Hero_Grenades[j].getGrenade_Position.Y > Enemy_Chargers[i].getEnemy_Current_Position.Y && Hero_Grenades[j].getGrenade_Position.Y < Enemy_Chargers[i].getEnemy_Current_Position.Y + Enemy_Charger_Height)
                                        {
                                            //AoE explosion
                                            Enemy_Chargers[i].DeactivateEnemy();
                                            Hud.Score += 20;
                                            Grenade_Explode(Hero_Grenades[j]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    for (int i = 0; i < Enemy_Chargers.Count; i++) //Hero bullet to enemy Charger collision
                    {
                        if (Enemy_Chargers[i].isEnemyActive)
                        {
                            for (int j = 0; j < Hero_Bullets.Count; j++)
                            {
                                if (Hero_Bullets[j].isBulletActive)
                                {
                                    if (Hero_Bullets[j].getBullet_Position.X > Enemy_Chargers[i].getEnemy_Current_Position.X && Hero_Bullets[j].getBullet_Position.X < Enemy_Chargers[i].getEnemy_Current_Position.X + Enemy_Charger_Width)
                                    {
                                        if (Hero_Bullets[j].getBullet_Position.Y > Enemy_Chargers[i].getEnemy_Current_Position.Y && Hero_Bullets[j].getBullet_Position.Y < Enemy_Chargers[i].getEnemy_Current_Position.Y + Enemy_Charger_Height)
                                        {
                                            Enemy_Chargers[i].setEnemy_Current_Lives = Enemy_Chargers[i].getEnemy_Current_Lives - 1;
                                            if (Enemy_Chargers[i].getEnemy_Current_Lives == 0)
                                            {
                                                Enemy_Chargers[i].DeactivateEnemy();
                                                Hud.Score += 10;
                                            }
                                            Hero_Bullets[j].DeactivateBullet();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    for (int i = 0; i < Enemy_Chargers.Count; i++) //Hero to enemy Charger collision
                    {
                        if (Enemy_Chargers[i].Enemy_Attack(Hero, Hero_Width, Hero_Height, Enemy_Charger_Width, Enemy_Charger_Height) == true)
                        {
                            if (isShieldOn == false)
                            {
                                if (Dev_Mode == false && Godmode == false)
                                {
                                    Hud.Lives--;
                                    if (Hud.Lives == 0)
                                    {
                                        Hero.DeactivateHero();
                                        GameState = "GameOver";
                                    }
                                }
                                //Enemy_Chargers[i].DeactivateEnemy();
                                //Hud.Score += 20;
                            }
                        }
                        else
                        {
                            Enemy_Chargers[i].DeactivateEnemy();
                        }
                    }
                }
                base.Update(gameTime);
            }
        }
        public void UpdateInput()
        {
            KeyboardState newState = Keyboard.GetState();
            MouseState mState = Mouse.GetState();
            Crosshair_Position = new Vector2(mState.X - 17, mState.Y - 17);
            if (GameState == "Menu")
            {
                if (mState.LeftButton == ButtonState.Pressed) Menu.Menu_Update(Crosshair_Position, true);
                else Menu.Menu_Update(Crosshair_Position, false);
                GameState = Menu.getGameState();
            }
            if (GameState == "Game")
            {
                if (newState.IsKeyDown(Keys.Escape) || newState.IsKeyDown(Keys.Q))
                {
                    //Open menu with "resume" option
                    OldGameState = GameState;
                    GameState = "Menu";
                }
                else if (newState.IsKeyDown(Keys.D))
                {
                    if (Hero.getHero_Position.X <= (Screen_Width - 50))
                    {
                        Hero.MoveRight(Crosshair_Position);
                    }
                }
                else if (newState.IsKeyDown(Keys.A))
                {
                    if (Hero.getHero_Position.X >= 0)
                    {
                        Hero.MoveLeft(Crosshair_Position);
                    }
                }
                else if (newState.IsKeyDown(Keys.W))
                {
                    if (Hero.getHero_Position.Y >= 0)
                    {
                        Hero.MoveUp(Crosshair_Position);
                    }
                }
                else if (newState.IsKeyDown(Keys.S))
                {
                    if (Hero.getHero_Position.Y <= (Screen_Height - 100))
                    {
                        Hero.MoveDown(Crosshair_Position);
                    }
                }
                else if (newState.IsKeyDown(Keys.Space))
                {
                    Hero.Shield();
                    isShieldOn = true;
                }
                else if (newState.IsKeyUp(Keys.Space) && oldKeyboardState.IsKeyDown(Keys.Space))
                {
                    isShieldOn = false;
                }
                else
                {
                    Hero.Revert(Crosshair_Position);
                    isShieldOn = false;
                }
                if (mState.LeftButton == ButtonState.Pressed)
                {
                    if (isShieldOn == false)
                    {
                        Hero_Middle = new Vector2(Hero.getHero_Position.X + 20, Hero.getHero_Position.Y + 30);
                        Hero_Shoot(Crosshair_Position, Hero_Middle);
                    }
                }
                if (mState.RightButton == ButtonState.Pressed)
                {
                    if (isShieldOn == false)
                    {
                        Hero_Middle = new Vector2(Hero.getHero_Position.X + 20, Hero.getHero_Position.Y + 30);
                        Hero_Throw_Grenade(Crosshair_Position, Hero_Middle);
                    }
                }
            }
            if (GameState == "GameOver")
            {
                if (newState.IsKeyDown(Keys.Space) || newState.IsKeyDown(Keys.Escape))
                {
                    Hero.Respawn(Screen_Width, Screen_Height);
                    for (int i = 0; i < Enemy_Tank_Bullets.Count; i++)
                    {
                        Enemy_Tank_Bullets[i].DeactivateBullet();
                    }
                    for (int i = 0; i < Enemy_Grunt_Bullets.Count; i++)
                    {
                        Enemy_Grunt_Bullets[i].DeactivateBullet();
                    }
                    for (int i = 0; i < Enemy_Tanks.Count; i++)
                    {
                        Enemy_Tanks[i].DeactivateEnemy();
                    }
                    for (int i = 0; i < Enemy_Grunts.Count; i++)
                    {
                        Enemy_Grunts[i].DeactivateEnemy();
                    }
                    for (int i = 0; i < Enemy_Chargers.Count; i++)
                    {
                        Enemy_Chargers[i].DeactivateEnemy();
                    }
                    Hud.Lives = 3;
                    Hud.Score = 0;
                    Hud.Wave = 0;
                    Powerup_isActive = false;
                    Godmode = false;
                    SuperGun = false;
                    SuperSpeed = false;
                    Hero_Rof_Limit = 15;
                    Hero_Grenade_Limit = 60;
                    Hero.setHero_Speed = 1;
                    OldGameState = GameState;
                    GameState = "Menu";
                }
            }
            oldMouseState = mState;
            oldKeyboardState = newState;
        }
        protected override void Draw(GameTime gameTime)
        {
            if (Draw_Background == false)
            {
                GraphicsDevice.Clear(Color.Green);
            }
            else
            {
                GraphicsDevice.Clear(Color.White);
            }
            //spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Begin();
            if (GameState == "Menu")
            {
                spriteBatch.Draw(Menu_Background, Screen_Rectangle, Color.White);
                Menu.Draw(spriteBatch, OldGameState);
                spriteBatch.Draw(Tree1, Tree_Position1, Color.White);
                spriteBatch.Draw(Tree1, Tree_Position2, Color.White);
                spriteBatch.Draw(Tree1, Tree_Position3, Color.White);
                spriteBatch.Draw(Tree1, Tree_Position4, Color.White);
                if (OldGameState == "Game")
                {
                    Hud.Draw(spriteBatch, Powerup_isActive, Powerup_Duration, Effect_Current);
                    for (int i = 0; i < Hud.Lives; i++)
                    {
                        Vector2 Heart_Position = new Vector2(Hud.getLives_Position.X + 80 + (40 * i), Hud.getLives_Position.Y + 5);
                        spriteBatch.Draw(Hero_Heart, Heart_Position, Color.White);
                        if (Godmode == true)
                        {
                            spriteBatch.Draw(Powerup_Godmode, Powerup_Active_Position, Color.White);
                        }
                        else if (SuperGun == true)
                        {
                            spriteBatch.Draw(Powerup_Gun, Powerup_Active_Position, Color.White);
                        }
                        else if (SuperSpeed == true)
                        {
                            spriteBatch.Draw(Powerup_Speed, Powerup_Active_Position, Color.White);
                        }

                        if (Hero.isHeroActive == true)
                        {
                            Hero.Draw(spriteBatch);
                        }
                        foreach (EnemySprite enemy in Enemy_Tanks)
                        {
                            if (enemy.isEnemyActive)
                            {
                                enemy.Draw(gameTime, spriteBatch);
                            }
                        }

                        foreach (EnemySprite enemy in Enemy_Grunts)
                        {
                            if (enemy.isEnemyActive)
                            {
                                enemy.Draw(gameTime, spriteBatch);
                            }
                        }

                        foreach (EnemySprite enemy in Enemy_Chargers)
                        {
                            if (enemy.isEnemyActive)
                            {
                                enemy.Draw(gameTime, spriteBatch);
                            }
                        }

                        foreach (Bullet bullet in Hero_Bullets)
                        {
                            if (bullet.isBulletActive)
                            {
                                bullet.Draw(gameTime, spriteBatch);
                            }
                        }

                        foreach (Grenade grenade in Hero_Grenades)
                        {
                            if (grenade.isGrenadeActive)
                            {
                                grenade.Draw(gameTime, spriteBatch);
                            }
                        }

                        foreach (Bullet bullet in Enemy_Tank_Bullets)
                        {
                            if (bullet.isBulletActive)
                            {
                                bullet.Draw(gameTime, spriteBatch);
                            }
                        }

                        foreach (Bullet bullet in Enemy_Grunt_Bullets)
                        {
                            if (bullet.isBulletActive)
                            {
                                bullet.Draw(gameTime, spriteBatch);
                            }
                        }

                        foreach (Powerup powerup in Powerups)
                        {
                            if (powerup.isPowerupActive)
                            {
                                powerup.Draw(gameTime, spriteBatch);
                            }
                        }
                    }
                }
            }
            if (GameState == "GameOver")
            {
                spriteBatch.Draw(GameOver_Background, Vector2.Zero, Color.White);
            }
            else if (GameState == "Game")
            {
                if (Draw_Background == true)
                {
                    spriteBatch.Draw(Background_Texture, Screen_Rectangle, Color.White);
                }
                Hud.Draw(spriteBatch, Powerup_isActive, Powerup_Duration, Effect_Current);
                for (int i = 0; i < Hud.Lives; i++)
                {
                    Vector2 Heart_Position = new Vector2(Hud.getLives_Position.X + 80 + (40 * i), Hud.getLives_Position.Y + 5);
                    spriteBatch.Draw(Hero_Heart, Heart_Position, Color.White);
                }

                spriteBatch.Draw(Tree1, Tree_Position1, Color.White);
                spriteBatch.Draw(Tree1, Tree_Position2, Color.White);
                spriteBatch.Draw(Tree1, Tree_Position3, Color.White);
                spriteBatch.Draw(Tree1, Tree_Position4, Color.White);
                //spriteBatch.Draw(Tree1, Tree_Position5, Color.White);
                //spriteBatch.Draw(Tree1, Tree_Position6, Color.White);

                if (Godmode == true)
                {
                    spriteBatch.Draw(Powerup_Godmode, Powerup_Active_Position, Color.White);
                }
                else if (SuperGun == true)
                {
                    spriteBatch.Draw(Powerup_Gun, Powerup_Active_Position, Color.White);
                }
                else if (SuperSpeed == true)
                {
                    spriteBatch.Draw(Powerup_Speed, Powerup_Active_Position, Color.White);
                }

                if (Hero.isHeroActive == true)
                {
                    Hero.Draw(spriteBatch);
                }

                spriteBatch.Draw(Crosshair_Final, Crosshair_Position, Color.White);

                foreach (EnemySprite enemy in Enemy_Tanks)
                {
                    if (enemy.isEnemyActive)
                    {
                        enemy.Draw(gameTime, spriteBatch);
                    }
                }

                foreach (EnemySprite enemy in Enemy_Grunts)
                {
                    if (enemy.isEnemyActive)
                    {
                        enemy.Draw(gameTime, spriteBatch);
                    }
                }

                foreach (EnemySprite enemy in Enemy_Chargers)
                {
                    if (enemy.isEnemyActive)
                    {
                        enemy.Draw(gameTime, spriteBatch);
                    }
                }

                foreach (Bullet bullet in Hero_Bullets)
                {
                    if (bullet.isBulletActive)
                    {
                        bullet.Draw(gameTime, spriteBatch);
                    }
                }

                foreach (Grenade grenade in Hero_Grenades)
                {
                    if (grenade.isGrenadeActive)
                    {
                        grenade.Draw(gameTime, spriteBatch);
                    }
                }

                foreach (Bullet bullet in Enemy_Tank_Bullets)
                {
                    if (bullet.isBulletActive)
                    {
                        bullet.Draw(gameTime, spriteBatch);
                    }
                }

                foreach (Bullet bullet in Enemy_Grunt_Bullets)
                {
                    if (bullet.isBulletActive)
                    {
                        bullet.Draw(gameTime, spriteBatch);
                    }
                }

                foreach (Powerup powerup in Powerups)
                {
                    if (powerup.isPowerupActive)
                    {
                        powerup.Draw(gameTime, spriteBatch);
                    }
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        private void Hero_Shoot(Vector2 target, Vector2 position)
        {
            if (GameState == "Game")
            {
                if (Hero_Rof_Cooldown >= Hero_Rof_Limit)
                {
                    Hero_Rof_Cooldown = 0;
                }
                if (Hero_Rof_Cooldown == 0)
                {
                    for (int i = 0; i < Hero_Bullets.Count; i++)
                    {
                        if (Hero_Bullets[i].isBulletActive == false)
                        {
                            Hero_Bullets[i].ActivateBullet(target, position, Hero_Bullet, Hero_Bullet_Speed);
                            break;
                        }
                    }
                }
            }
        }
        private void Hero_Throw_Grenade(Vector2 target, Vector2 position)
        {
            if (GameState == "Game")
            {
                if (Hero_Grenade_Cooldown >= Hero_Grenade_Limit)
                {
                    Hero_Grenade_Cooldown = 0;
                }
                if (Hero_Grenade_Cooldown == 0)
                {
                    for (int i = 0; i < Hero_Grenades.Count; i++)
                    {
                        if (Hero_Grenades[i].isGrenadeActive == false)
                        {
                            Hero_Grenades[i].ActivateGrenade(target, position, Hero_Grenade, Hero_Grenade_Speed);
                            break;
                        }
                    }
                }
            }
        }
        private void Grenade_Explode(Grenade grenade)
        {
            grenade.DeactivateGrenade();
        }
    }
}