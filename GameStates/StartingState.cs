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
        Hero hero = new Hero("waluigi");

        public TitleScreen()
        {
            Init();
        }

        public override void Init()
        {
            base.Init();
            Reset();
            TextGameObject title = new TextGameObject("GameFont");
            title.Text = "WaluBalt";
            title.Color = Color.Purple;
            title.Position = new Vector2(Canabalt.Screen.X / 2, Canabalt.Screen.Y / 2);
            this.Add(hero, title);
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            hero.Reset();
        }
    }
}
