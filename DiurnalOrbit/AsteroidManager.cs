using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Input;

namespace DiurnalOrbit
{
    internal class AsteroidManager
    {
        private List<Asteroid> asteroids;
        private Texture2D texture;

        private float angle;
        private float angleRad;

        private float speed;
        private Vector2 velocity;

        private int spawnBound;

        //private float[] sizes;

        private double rate;
        private double time;

        private Random rng;

        public AsteroidManager(Texture2D texture)
        {
            this.texture = texture;

            asteroids = new List<Asteroid>();

            angle = 0;
            angleRad = angle * (float) Math.PI / 180;

            speed = 5;
            velocity = new Vector2(speed * (float) Math.Cos(angleRad), -speed * (float) Math.Sin(angleRad));

            spawnBound = 1000;

            rate = 0.5;
            time = 0;

            rng = new Random();
        }

        // Methods

        public void Update(GameTime gt)
        {
            time += gt.ElapsedGameTime.TotalSeconds;
            
            if (time >= rate)
            {
                GenerateAsteroids();

                angle += 0.3f;

                if (angle >= 360)
                {
                    angle -= 360;
                }

                time = 0;
            }

            foreach (Asteroid a in asteroids)
            {
                a.Update(gt);
            }

            angleRad = angle * (float)Math.PI / 180;
            velocity.X = speed * (float)Math.Cos(angleRad);
            velocity.Y = -speed * (float)Math.Sin(angleRad);
        }

        public void GenerateAsteroids()
        {
            float spawn = rng.Next(0, (int) spawnBound * 2);
            Vector2 spawnPos = new Vector2(0, 0);

            if (angle == 0)
            {
                if (spawn > spawnBound)
                {
                    spawn -= spawnBound;
                }
                spawnPos = new Vector2(0, spawn);
            }
            else if (angle > 0 && angle < 90)
            {
                if (spawn > spawnBound)
                {
                    spawn -= spawnBound;
                    spawnPos = new Vector2(0, spawn);
                }
                else
                {
                    spawnPos = new Vector2(spawn, spawnBound);
                }
            }
            else if (angle == 90)
            {
                if (spawn > spawnBound)
                {
                    spawn -= spawnBound;
                }
                spawnPos = new Vector2(spawn, spawnBound);
            }
            else if (angle > 90 && angle < 180)
            {
                if (spawn > spawnBound)
                {
                    spawn -= spawnBound;
                    spawnPos = new Vector2(spawnBound, spawn);
                }
                else
                {
                    spawnPos = new Vector2(spawn, spawnBound);
                }
            }
            else if (angle == 180)
            {
                if (spawn > spawnBound)
                {
                    spawn -= spawnBound;
                }
                spawnPos = new Vector2(spawnBound, spawn);
            }
            else if (angle > 180 && angle < 270)
            {
                if (spawn > spawnBound)
                {
                    spawn -= spawnBound;
                    spawnPos = new Vector2(spawnBound, spawn);
                }
                else
                {
                    spawnPos = new Vector2(spawn, 0);
                }
            }
            else if (angle == 270)
            {
                if (spawn > spawnBound)
                {
                    spawn -= spawnBound;
                }
                spawnPos = new Vector2(spawn, 0);
            }
            else if (angle > 270 && angle < 360)
            {
                if (spawn > spawnBound)
                {
                    spawn -= spawnBound;
                    spawnPos = new Vector2(0, spawn);
                }
                else
                {
                    spawnPos = new Vector2(spawn, 0);
                }
            }

            asteroids.Add(new Asteroid(texture, spawnPos, 3, velocity, true));
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
