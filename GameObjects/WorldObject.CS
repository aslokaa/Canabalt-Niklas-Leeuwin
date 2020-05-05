using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede.GameObjects
{
    class WorldObject : SpriteGameObject
    {
        public WorldObject(string assetName) : base(assetName)
        {
        }


        public bool OutOfMap()
        {
            return position.X + Sprite.Width < 0;
        }
    }
}
