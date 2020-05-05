using Centipede.GameStates;
using FlappyBird;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede.GameObjects
{
    class Hero : SpriteGameObject
    {

        private float
            scoreModifier = 0,
            deceleration = 0.85f;
        private Vector2
            jumpVelocity = new Vector2(0, -20),
            gravity = new Vector2(0, 3),
            acceleration = new Vector2(8, 0);



        public Hero() : base("waluigi")
        {
            Position = new Vector2(200, 100);
        }

        public override void Update(GameTime gameTime)
        { 
            Move();
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                Velocity += jumpVelocity;
            }
            if (inputHelper.KeyPressed(Keys.A))
            {
                Velocity -= acceleration;
            }
            if (inputHelper.KeyPressed(Keys.D))
            {
                Velocity += acceleration;
            }
        }

        private void ApplyGravity()
        {
            position += gravity;
        }

        private void Move()
        {
            ApplyGravity();
            velocity *= deceleration;
            position += velocity;
            if (CollidesWithPlatform(out float collidedY))
            {
                position.Y = collidedY - Sprite.Height;
                velocity.Y = 0;
            }
        }

        private bool CollidesWithPlatform(out float collidedY)
        {
            bool collided = false;
            collidedY = 0;
            foreach (Platform platform in PlayingState.GetPlatforms())
            {
                if (CollidesWith(platform))
                {
                    collided = true;
                    collidedY = platform.Position.Y;
                }

            }
            return collided;
        }
    }
}
