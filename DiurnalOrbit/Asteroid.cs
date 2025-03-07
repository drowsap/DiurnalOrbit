using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DiurnalOrbit
{
    internal class Asteroid : GameObject
    {
        // Fields

        private Vector2 velocity;
        private bool rotates;

        // Constructor 

        public Asteroid(Texture2D texture, Vector2 position, float size, Vector2 velocity, bool rotates)
            : base(texture, position, size)
        {
            this.velocity = velocity;
            this.rotates = rotates;
        }

        // Methods

        public override void Update(GameTime gt)
        {
            position += velocity;

            if (rotates)
                rotation += .05f;
        }

        public bool CheckCollision(GameObject target)
        {
            float distance = (float) Math.Sqrt(Math.Pow(position.X - target.X, 2) + Math.Pow(position.Y - target.Y, 2));
            float radii = Math.Max(Width, Height) + Math.Max(target.Width, target.Height);

            return radii >= distance;
        }
    }
}
