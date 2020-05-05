using Centipede.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede.GameStates
{
    class PlayingState : GameObjectList
    {
        SpriteGameObject background = new SpriteGameObject("background");
        Hero player = new Hero("fat waluigi");
        Score score = new Score();
        static GameObjectList
            bullets = new GameObjectList(),
            platforms = new GameObjectList();
        Random random = new Random();

        Vector2
            backgroundReset = new Vector2(-1280, 0),
            worldVelocity = new Vector2(-1, 0);
        Point
            platformSpawnZoneLeft = new Point(1290, 400),
            platformSpawnZoneRight = new Point(1500, 600);
        float
            platformTimer,
            bulletTimer;
        const float
            BACKGROUND_SPEED_MODIFIER = 0.9f,
            BULLET_SPEED_MODIFIER = 3f,
            METERS_PER_SECOND = 0.05f,
            PLATFORM_TIMER_MODIFIER = 3,// platform timer -= the speed modifier that is at most 2.5
            BULLET_COOLDOWN = 45, //0.75 seconds
            PLATFORM_COOLDOWN = 150; //2.5 seconds




        public PlayingState()
        {
            Reset();
            Init();
        }

        public override void Reset()
        {
            base.Reset();
            platformTimer = 60;
            platforms.Add(new Platform(new Vector2(player.Position.X, 450)));
            platforms.Add(new Platform(new Vector2(player.Position.X + 500, 250)));
        }

        public void Init()
        {
            Reset();
            background.Velocity = worldVelocity;
            this.Add(background, score, player, platforms, bullets);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MoveBackground();
            DestroyPlatforms();
            DestroyBullets();
            spawnPlatforms();
            spawnBullets();
            score.AddMeters(METERS_PER_SECOND * player.getSpeedModifier());
            if (checkDeath())
            {
                GameOver.Score = score;
                Canabalt.GameStateManager.SwitchTo("GameOver");
            }
        }



        private void DestroyPlatforms()
        {
            List<Platform> doomedPlatforms = new List<Platform>();
            foreach (Platform platform in GetPlatforms())
            {
                if (platform.OutOfMap())
                {
                    doomedPlatforms.Add(platform);
                }
            }
            foreach (Platform platform in doomedPlatforms)
            {
                platforms.Remove(platform);
            }
        }
        private void DestroyBullets()
        {
            List<WorldObject> doomedBullets = new List<WorldObject>();
            foreach (WorldObject bullet in bullets.Children)
            {
                if (bullet.OutOfMap())
                {
                    doomedBullets.Add(bullet);
                    score.AddBullets(1);
                }
            }
            foreach (WorldObject bullet in doomedBullets)
            {
                bullets.Remove(bullet);
                
            }
        }

        private void spawnPlatforms()
        {
            platformTimer += PLATFORM_TIMER_MODIFIER - player.getSpeedModifier() / 2;
            if (platformTimer > PLATFORM_COOLDOWN)
            {
                platformTimer = 0;
                Platform platform = new Platform(

                    new Vector2(
                        random.Next(platformSpawnZoneLeft.X, platformSpawnZoneRight.X),
                        random.Next(platformSpawnZoneLeft.Y, platformSpawnZoneRight.Y)));
                if (!platform.CollidesWithOtherPlatform())
                {
                    platforms.Add(platform);
                }
            }
        }

        private void spawnBullets()
        {
            if (bulletTimer++ > BULLET_COOLDOWN)
            {
                bulletTimer = 0;
                WorldObject bullet = new WorldObject("bullet");
                bullet.Position = new Vector2(
                    random.Next(platformSpawnZoneLeft.X, platformSpawnZoneRight.X),
                    random.Next(0, Canabalt.Screen.Y));
                bullets.Add(bullet);
            }
        }
        private void MoveBackground()
        {
            float speedModifier = player.getSpeedModifier();
            if (background.Position.X < backgroundReset.X)
            {
                background.Position = Vector2.Zero;
            }

            background.Position += worldVelocity * player.getSpeedModifier() * BACKGROUND_SPEED_MODIFIER;

            foreach (Platform platform in GetPlatforms())
            {
                platform.Position += worldVelocity * player.getSpeedModifier();
            }

            foreach (SpriteGameObject bullet in bullets.Children)
            {
                bullet.Position += worldVelocity * player.getSpeedModifier() * BULLET_SPEED_MODIFIER;
            }
        }

        private bool checkDeath()
        {
            foreach (WorldObject bullet in bullets.Children)
            {
                if (player.CollidesWith(bullet))
                {
                    return true;
                }
            }
            if (player.Position.Y > Canabalt.Screen.Y)
            {
                return true;
            }
            return false;
        }

        public static List<GameObject> GetPlatforms()
        {
            return platforms.Children;
        }
    }
}
