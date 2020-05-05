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
        float
            bullets,
            meters;


        public Score(string assetname= "GameFont") : base(assetname)
        {
            position = new Vector2(750, 20);
            text = "";
            color = Color.Black;
            Reset();
        }

        public override void Reset()
        {
            base.Reset();
            bullets = 0;
            meters = 0;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            text = "Meters: " + (int)meters +"\nBullets Dodged: "+bullets;
        }

        public void AddMeters(float meters)
        {
            this.meters += meters;
        }

        public void AddBullets(float bullets)
        {
            this.bullets += bullets;
        }
    }
}
