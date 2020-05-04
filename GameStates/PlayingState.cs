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
        Hero player = new Hero("");

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
            this.Add();
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            
        }
    }
}
