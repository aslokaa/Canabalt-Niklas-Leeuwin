using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede.GameStates
{
    class GameOver : UnplayableState
    {
        GameOver(GameObject gameObject)
        {
            Add(gameObject);
        }

        protected override void SwitchState()
        {
            Canabalt.GameStateManager.SwitchTo("TitleScreen");
        }
    }
}
