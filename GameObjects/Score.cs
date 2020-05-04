using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Centipede.GameObjects
{
    class Score : TextGameObject
    {
        public Score(string assetname= "GameFont") : base(assetname)
        {
            position = new Vector2(1000, 20);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
