using Centipede.GameStates;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede.GameObjects
{
    class Platform : SpriteGameObject
    {
        public Platform(Vector2 position,Vector2 velocity,string assetName = "platform") : base(assetName)
        {
            this.position = position;
            this.velocity = velocity;
        }

        public override void Update(GameTime gameTime)
        {
            position += velocity ;
        }

        public bool CollidesWithOtherPlatform()
        {
            bool collided = false;
            foreach (Platform platform in PlayingState.GetPlatforms())
            {
                if (CollidesWith(platform))
                {
                    collided = true;
                }

            }
            return collided;
        }
    }
}
