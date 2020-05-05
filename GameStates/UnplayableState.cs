using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
            text.Text = "Press space to continue.";
            text.Color = Color.Black;
            this.Add(new SpriteGameObject("background"), text);

        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.IsKeyDown(Keys.Space))
            {
                Canabalt.Reset();
                Canabalt.GameStateManager.SwitchTo("PlayingState");
            }
        }


    }
}
