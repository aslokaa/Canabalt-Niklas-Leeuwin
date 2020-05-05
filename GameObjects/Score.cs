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

        public float Meters { get => meters; set => meters = value; }
        public float Bullets { get => bullets; set => bullets = value; }

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
            Bullets = 0;
            Meters = 0;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            text = "Meters: " + (int)Meters +"\nBullets Dodged: "+Bullets;
        }

        public void AddMeters(float meters)
        {
            this.Meters += meters;
        }

        public void AddBullets(float bullets)
        {
            this.Bullets += bullets;
        }
    }
}
