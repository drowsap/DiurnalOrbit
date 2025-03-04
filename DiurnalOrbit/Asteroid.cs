using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DiurnalOrbit
{
    internal class Asteroid : GameObject
    {
        // Fields

        private Vector2 velocity;

        // Constructor 

        public Asteroid(Texture2D texture, Vector2 position, float size, Vector2 velocity)
            : base(texture, position, size)
        {
            this.velocity = velocity;
        }

        // Methods

        public override void Update()
        {
            position += velocity;
        }

        public bool CheckCollision(GameObject target)
        {
            float distance = (float) Math.Sqrt(Math.Pow(position.X - target.X, 2) + Math.Pow(position.Y - target.Y, 2));
            float radii = Math.Max(Width, Height) + Math.Max(target.Width, target.Height);

            return radii >= distance;
        }
    }
}
