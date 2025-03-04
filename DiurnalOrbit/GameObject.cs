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
    internal class GameObject
    {
        // Fields

        protected Texture2D texture;
        protected Vector2 position;
        protected float size;

        protected float rotation;

        // Properties

        public float X { get => position.X; }

        public float Y { get => position.Y; }

        public float Width { get => texture.Width * size; }

        public float Height { get => texture.Height * size; }

        // Constructors

        public GameObject(Texture2D texture, Vector2 position, float size)
        {
            this.texture = texture;
            this.position = position;
            this.size = size;

            rotation = 0;
        }

        // Methods

        public virtual void Update() { }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, null, Color.White, rotation, new Vector2(texture.Width/2, texture.Height/2), size, SpriteEffects.None, 1);
        }
    }
}
