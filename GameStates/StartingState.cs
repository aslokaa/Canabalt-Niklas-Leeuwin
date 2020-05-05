using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Centipede.GameObjects;
using Microsoft.Xna.Framework;

namespace Centipede.GameStates
{
    class TitleScreen : UnplayableState
    {
        Hero hero = new Hero();

        public TitleScreen()
        {
            Init();
        }

        public override void Init()
        {
            base.Init();
            Reset();
            this.Add(hero);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            hero.Reset();
        }
    }
}
