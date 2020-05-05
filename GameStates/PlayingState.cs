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
        static GameObjectList platforms = new GameObjectList();
        Vector2
            backgroundReset = new Vector2(-1280, 0),
            worldVelocity = new Vector2(-1, 0);
        Point
            platformSpawnZoneLeft = new Point(1290, 400),
            platformSpawnZoneRight = new Point(1500, 600);




        public PlayingState()
        {
            Reset();
            Init();
        }

        public override void Reset()
        {
            base.Reset();
        }

        public void Init()
        {
            background.Velocity = worldVelocity;
            platforms.Add(new Platform(new Vector2(player.Position.X, 450), worldVelocity));
            this.Add(background, score, player, platforms);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MoveBackground();
            spawnPlatforms();
        }

        private void spawnPlatforms()
        {
            Random random = new Random();
            Platform platform = new Platform(
                new Vector2(
                    random.Next(platformSpawnZoneLeft.X, platformSpawnZoneRight.X),
                    random.Next(platformSpawnZoneLeft.Y, platformSpawnZoneRight.Y)),
                    worldVelocity);
            if (!platform.CollidesWithOtherPlatform())
            {
                platforms.Add(platform);
            }
        }

        private void MoveBackground()
        {
            if (background.Position.X < backgroundReset.X)
            {
                background.Position = Vector2.Zero;
            }
            background.Position += background.Velocity;
        }

        public static List<GameObject> GetPlatforms()
        {
            return platforms.Children;
        }
    }
}
