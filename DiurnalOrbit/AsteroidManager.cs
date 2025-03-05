using Microsoft.Xna.Framework.Graphics;
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
        private Texture2D texture;

        private float speed;
        //private Vector2 velocity;

        //private float[] sizes;

        private Random rng;

        public AsteroidManager(Texture2D texture)
        {
            this.texture = texture;

            asteroids = new List<Asteroid>();
            speed = 5;

            rng = new Random();
        }

        // Methods

        public void Update()
        {
            GenerateAsteroids();

            foreach (Asteroid a in asteroids)
            {
                a.Update();
            }
        }

        public void GenerateAsteroids()
        {
            asteroids.Add(new Asteroid(texture, new Vector2(0, rng.Next(1000)), 1, new Vector2(speed, 0)));
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Asteroid a in asteroids)
            {
                a.Draw(sb);
            }
        }
    }
}
