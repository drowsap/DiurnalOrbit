using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DiurnalOrbit
{
    internal class AsteroidManager
    {
        private List<Asteroid> asteroids;
        private Vector2 spawnBounds;

        private float speed;
        private Vector2 velocity;

        private float minScale;
        private float maxScale;

        public AsteroidManager(float speed, float minScale, float maxScale)
        {
            this.speed = speed;


            this.maxScale = maxScale;
        }
    }
}
