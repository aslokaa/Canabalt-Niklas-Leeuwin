using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede.GameStates
{
    class UnplayableState : GameObjectList
    {
        public UnplayableState()
        {
            Init();
        }

        public virtual void Init()
        {
            TextGameObject text = new TextGameObject("GameFont");
            text.Text = "Press any key to continue.";
            text.Color = Color.Black;
            this.Add(new SpriteGameObject("background"), text);

        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.AnyKeyPressed)
            {
                Canabalt.Reset();
                Canabalt.GameStateManager.SwitchTo("PlayingState");
            }
        }


    }
}
