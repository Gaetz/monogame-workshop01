using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workshop01
{
    class Player
    {
        // Animation representing the player
        public Texture2D PlayerTexture;

        // Position of the Player relative to the upper left side of the screen
        public Vector2 Position = Vector2.Zero;

        public Vector2 Direction; // travel direction of sprite
        public float Angle;       // rotation of sprite

        public Vector2 Velocity;
        public Vector2 Acceleration;
        public float AccelerationDelta = 100f;
        public float Decelleration = 5f;
        public float RotationAcceleration;
        public float RotationDecceleration = 0.01f;

        public float TopSpeed;

        float thrusterPower;

        // State of the player
        public bool Active;

        // Amount of hit points that player has
        public int Health;

        // Get the width of the player ship
        public int Width
        {
            get { return PlayerTexture.Width; }
        }

        // Get the height of the player ship
        public int Height
        {
            get { return PlayerTexture.Height; }
        }

        public void Initialize(Texture2D texture, Vector2 position)
        {
            PlayerTexture = texture;
            // Set the starting position of the player around the middle of the screen and to the back
            Position = position;
            // Set the player to be active
            Active = true;
            // Set the player health
            Health = 100; 
            // Speed
            TopSpeed = 100;

            thrusterPower = 0;
        }

        Vector2 up = new Vector2(1f, 0f);

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            HandleInput(Keyboard.GetState(), gameTime);

            Angle += RotationAcceleration * 0.1f;
            Matrix rotMatrix = Matrix.CreateRotationZ(Angle);
            Vector2 thrusterForce = Vector2.Transform(up, rotMatrix) * thrusterPower;

            Acceleration = thrusterForce;
            Velocity += Acceleration * deltaTime * deltaTime; 
            Position += Velocity * deltaTime;
        }

        private void HandleInput(KeyboardState KeyState, GameTime gameTime)
        {
            if (KeyState.IsKeyDown(Keys.Z))
            {
                thrusterPower += AccelerationDelta;
            }
            else if (KeyState.IsKeyDown(Keys.S))
            {
                thrusterPower -= AccelerationDelta;
            }
            else
            {
                thrusterPower = 0f;
                Mitigate(ref Velocity.X, Decelleration, Decelleration);
                Mitigate(ref Velocity.Y, Decelleration, Decelleration);
            }

            if (KeyState.IsKeyDown(Keys.Q))
            {
                RotationAcceleration -= 0.01f;
            }
            else if (KeyState.IsKeyDown(Keys.D))
            {
                RotationAcceleration += 0.01f; 
            }
            else
            {
                Mitigate(ref RotationAcceleration, 0f, RotationDecceleration);
                //if (RotationAcceleration < 0)
                //    RotationAcceleration += RotationDecceleration;
                //else if (RotationAcceleration > 0)
                //    RotationAcceleration -= RotationDecceleration;
            }
        }

        private void Mitigate(ref float data, float comparer, float mitiger)
        {
            if (data < -comparer)
                data += mitiger;
            else if (data > comparer)
                data -= mitiger;
            else if (data >= -comparer && data <= comparer)
                data = 0f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin = new Vector2(PlayerTexture.Width / 2, PlayerTexture.Height / 2);
            spriteBatch.Draw(PlayerTexture, Position, null, Color.White, Angle, origin, 1f, SpriteEffects.None, 0f); 
        } 
    }
}
