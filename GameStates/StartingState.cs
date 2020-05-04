using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Centipede.GameStates
{
    class StartingState : GameObjectList
    {
        public StartingState()
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
            TextGameObject font = new TextGameObject("GameFont");
            font.Text = "Press any key to continue.";
            font.Color = Color.Black;
            this.Add(new SpriteGameObject("background"), font);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.AnyKeyPressed)
            {
                Canabalt.GameStateManager.SwitchTo("PlayingState");
            }
        }
    }
}
