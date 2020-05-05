﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Centipede.GameStates
{
    class TitleScreen : UnplayableState
    {
        public TitleScreen()
        {
            Init();
        }

        protected override void SwitchState()
        {
            Canabalt.GameStateManager.SwitchTo("PlayingState");
        }
    }
}
