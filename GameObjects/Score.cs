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

        private float redTimer;
        private const float RED_TIME = 15; //0.25 seconds

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
            if (redTimer++ < RED_TIME)
            {
                color = Color.Red;
            }
            else
                color = Color.Black;
            
        }

        public void AddMeters(float meters)
        {
            this.Meters += meters;
        }

        public void AddBullets(float bullets)
        {
            redTimer = 0;
            this.Bullets += bullets;
        }
    }
}
