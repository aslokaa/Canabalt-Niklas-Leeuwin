using Centipede.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede.GameStates
{
    class GameOver : UnplayableState
    {
        static Score score = new Score() ;

        public static Score Score
        {
            get => Score;
            set
            {
                score.Meters=value.Meters;
                score.Bullets=value.Bullets;
            }
        }

        public GameOver()
        {
            this.Add(score);
        }
    }
}
