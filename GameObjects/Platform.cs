using Centipede.GameStates;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede.GameObjects
{
    class Platform : WorldObject
    {
        public Platform(Vector2 position,string assetName = "platform") : base(assetName)
        {
            this.position = position;
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
