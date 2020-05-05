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

        const float
            DECELERATION = 0.85f,
            SPEED_MODIFIER_LOW = 0.8f,
            SPEED_MODIFIER_HIGH = 5;
        private Vector2
            jumpVelocity = new Vector2(0, -50),
            gravity = new Vector2(0, 2),
            farInScreen = new Vector2(-3, 0),
            acceleration = new Vector2(4, 0);




        public Hero() : base("waluigi")
        {
            Reset();
        }

        public override void Reset()
        {
            base.Reset();
            Position = new Vector2(200, 100);
            velocity = new Vector2(0, 1);
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
            if (inputHelper.IsKeyDown(Keys.A))
            {
                Velocity -= acceleration;
            }
            if (inputHelper.IsKeyDown(Keys.D))
            {
                Velocity += acceleration;
            }
        }

        private void ApplyGravity()
        {
            if (velocity.Y != 0)
            {
                velocity += gravity;
            }
        }

        private void Move()
        {
            ApplyGravity();
            velocity *= DECELERATION;
            position += velocity;
            if (CollidesWithPlatform(out float collidedY))
            {
                position.Y = collidedY - Sprite.Height;
                velocity.Y *= -DECELERATION;
            }
            if (getSpeedModifier() > (SPEED_MODIFIER_HIGH / 2))
            {
                velocity += farInScreen;
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

        //converts the location of the player to a modifier of the world speed.
        public float getSpeedModifier()
        {


            float speedModifier = position.X / Canabalt.Screen.X;
            speedModifier = (SPEED_MODIFIER_HIGH - SPEED_MODIFIER_LOW) * speedModifier + SPEED_MODIFIER_LOW;

            return speedModifier;


        }
    }
}
