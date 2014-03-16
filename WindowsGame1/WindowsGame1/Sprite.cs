using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Sprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int _height;
        public int Height { get { return _height; } }
        private int _width;
        public int Width { get { return _width; } }
        private int currentFrame;
        private int totalFrames;
        public bool FacingRight { get; set; }

        public Sprite(Texture2D texture)
            : this(texture, 1, 1)
        {}

        public Sprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            FacingRight = true;
        }

        public void Update()
        {
            if (System.DateTime.UtcNow.Ticks % 5 == 0)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            _width = Texture.Width / Columns;
            _height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns; 

            Rectangle sourceRectangle = new Rectangle(Width * column, Height * row, Width, Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);

            SpriteEffects facing;
            Vector2 origin = new Vector2(0, 0);

            if (FacingRight) facing = SpriteEffects.None;
            else facing = SpriteEffects.FlipHorizontally;

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, 0f, origin , facing, 1);
            spriteBatch.End();
        }
    }
}
