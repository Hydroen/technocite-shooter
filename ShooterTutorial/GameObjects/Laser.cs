﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterTutorial.Utilities;
using ShooterTutorial;



namespace ShooterTutorial.GameObjects
{
    public class Laser : IUpdateable2, IDrawable2, ICollidable
    {

        // animation the represents the laser animation.
        public Animation LaserAnimation;

        // postion of the laser
        public Vector2 Position;
      
        // Movement algorithm
        IMovement Movement;

        // The damage the laser deals.
        int Damage = 10;

        public int Layer
        {
            get { return 1; }
        }

        // set the laser to active
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private bool _Active;
        private Game1 _game;

        // Range of the laser.
        int Range;

        // the width of the player image.
        public int Width
        {
            get { return LaserAnimation.FrameWidth; }
        }

        // the height of the player image.
        public int Height
        {
            get { return LaserAnimation.FrameHeight; }

        }

        public CollisionLayer CollisionGroup
        {
            get
            {
                return CollisionLayer.Laser;
            }
        }

        CollisionLayer _collisionLayers;

        public CollisionLayer CollisionLayers
        {
            get
            {
                return _collisionLayers;
            }
        }

        public Rectangle BoundingRectangle
        {
            get
            {
                return new Rectangle(
                        (int)Position.X,
                        (int)Position.Y,
                        Width,
                        Height);
            }
        }

        public void Initialize(Game1 game, Animation animation, IMovement movement, CollisionLayer collision_layers)
        {
            LaserAnimation = animation;
            Movement = movement;
            Position = movement.getPosition();
            _game = game;
            _collisionLayers = collision_layers;
            Active = true;
        }

        public void Update( Game game, GameTime gameTime)
        {
            Movement.update(gameTime);

            Position = Movement.getPosition();

            LaserAnimation.Position = Position;
            LaserAnimation.Update(gameTime);

            _Active = _Active && Position.X >= 0 && Position.X < game.GraphicsDevice.Viewport.Width;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            LaserAnimation.Draw(spriteBatch, Movement.getRotation());
        }

        public void OnCollision(ICollidable other)
        {
            if (other.CollisionGroup == CollisionLayer.PowerUp)
            {
                _game._weapon = ((Powerup)other).Weapon;
            }

            Active = false;
        }
    }
}
