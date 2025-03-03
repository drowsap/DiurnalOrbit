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
    internal class Ship : GameObject
    {
        // fields

        private float radius;
        private float orbit;
        private float radianOrbit;

        private float minRadius;
        private float maxRadius;

        private float orbitSpeed;
        private float radiusSpeed;

        // Properties

        public float Radius => radius;

        public float Orbit => orbit;

        // Constructor

        public Ship(Texture2D texture, float size, float radius, float orbit) :
            this(texture, size, radius, 50, 500, orbit)
        { }

        public Ship(Texture2D texture, float size, float radius, float orbit, float orbitSpeed, float radiusSpeed) :
           this(texture, size, radius, 50, 500, orbit, orbitSpeed, radiusSpeed)
        { }

        public Ship(Texture2D texture, float size, float radius, float minRadius, float maxRadius, float orbit, float orbitSpeed, float radiusSpeed) :
            base(texture, new Vector2(), size)
        {
            this.minRadius = minRadius;
            this.maxRadius = maxRadius;

            if (radius < minRadius)
            {
                this.radius = minRadius;
            }
            else if (radius > maxRadius)
            {
                this.radius = maxRadius;
            }
            else
            {
                this.radius = radius;
            }

            this.orbit = orbit;

            radianOrbit = ((orbit * (float)Math.PI) / 180f);

            rotation = -radianOrbit;

            position.X = this.radius * (float)Math.Cos(radianOrbit);
            position.Y = -this.radius * (float)Math.Sin(radianOrbit);

            this.orbitSpeed = orbitSpeed;
            this.radiusSpeed = radiusSpeed;
        }

        // Methods

        public override void Update()
        {
            UserInput();

            radianOrbit = ((orbit * (float)Math.PI) / 180f);

            rotation = -radianOrbit;

            position.X = this.radius * (float)Math.Cos(radianOrbit);
            position.Y = -this.radius * (float)Math.Sin(radianOrbit);
        }

        public void UserInput()
        {
            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.Space))
            {
                orbit += orbitSpeed;
                
                if (orbit >= 360)
                {
                    orbit = orbit - 360;
                }
            }

            if (kb.IsKeyDown(Keys.Up))
            {
                if (radius < maxRadius)
                {
                    radius += radiusSpeed;
                }
            }

            if (kb.IsKeyDown(Keys.Down))
            {
                if (radius > minRadius)
                {
                    radius -= radiusSpeed;
                }
            }
        }

        public void Draw(SpriteBatch sb, GraphicsDeviceManager gm)
        {
            float x = gm.PreferredBackBufferWidth/2 + position.X;
            float y = gm.PreferredBackBufferHeight/2 + position.Y;

            sb.Draw(texture, new Vector2(x, y), null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), size, SpriteEffects.None, 1);
        }


    }
}
