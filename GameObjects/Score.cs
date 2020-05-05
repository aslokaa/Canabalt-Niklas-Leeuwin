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
        private float meters = 0;


        public Score(string assetname= "GameFont") : base(assetname)
        {
            position = new Vector2(900, 20);
            text = "";
            color = Color.Black;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            text = "Meters: " + meters;
        }

        public void addMeters(float meters)
        {
            //this.meters += meters;
            this.meters = meters;
        }
    }
}
