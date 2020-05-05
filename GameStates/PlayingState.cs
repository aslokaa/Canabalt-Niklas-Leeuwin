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
        Hero player = new Hero();
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
        int
            platformTimer,
            bulletTimer;
        const int
            BULLET_COOLDOWN = 180, //3 seconds
            PLATFORM_COOLDOWN = 120; //2 seconds




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
            spawnPlatforms();
            score.addMeters(player.getSpeedModifier());
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

        private void spawnPlatforms()
        {
            if (platformTimer++ > PLATFORM_COOLDOWN)
            {
                platformTimer = 0;
                int platformsX = (int)(platforms.Position.X);
                Platform platform = new Platform(

                    new Vector2(
                        random.Next(platformSpawnZoneLeft.X + platformsX, platformSpawnZoneRight.X + platformsX),
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
                SpriteGameObject bullet = new SpriteGameObject("bullet");
                bullet.Position = new Vector2(
                    random.Next(platformSpawnZoneLeft.X, platformSpawnZoneRight.X),
                    random.Next(0, Canabalt.Screen.Y));
                
            }
        }
        private void MoveBackground()
        {
            float speedModifier = player.getSpeedModifier();
            if (background.Position.X < backgroundReset.X)
            {
                background.Position = Vector2.Zero;
            }
            background.Position += worldVelocity * player.getSpeedModifier();
            foreach (Platform platform in GetPlatforms())
            {
                platform.Position += worldVelocity * player.getSpeedModifier();
            }
        }

        public static List<GameObject> GetPlatforms()
        {
            return platforms.Children;
        }
    }
}
