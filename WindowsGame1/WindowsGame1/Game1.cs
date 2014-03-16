using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //private Texture2D background;

        private Sprite player;

        private Vector2 _pVector;
        public Vector2 PVector
        {
            get { return _pVector; }
            set
            {
                Vector2 temp = value;

                if (value.X < 0) temp.X = 0;
                else if (value.X >= graphics.GraphicsDevice.Viewport.Width - player.Width) 
                    temp.X = graphics.GraphicsDevice.Viewport.Width - player.Width;

                if (value.Y < 0) temp.Y = 0;
                else if (value.Y >= graphics.GraphicsDevice.Viewport.Height - player.Height) 
                    temp.Y = graphics.GraphicsDevice.Viewport.Height - player.Height;

                _pVector = temp;
            }
        }

        // Set the coordinates to draw the sprite at.
        //Vector2 spritePosition = Vector2.Zero;

        // Store some information about the sprite's motion.
        //Vector2 spriteSpeed = new Vector2(50.0f, 50.0f);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //background = Content.Load<Texture2D>("MegaMan2Sheet1");
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            // This is a texture we can render.

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D texture = Content.Load<Texture2D>("Megaman-Run");
            player = new Sprite(texture, 1, 4);
            PVector = new Vector2(400, 200);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)| 
                (Keyboard.GetState().IsKeyDown(Keys.Escape)))
                this.Exit();

            // Controls the player character's speed. Holding B or Left Shift makes the player run.
            byte PSpeed;
            if ((GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed) |
               (Keyboard.GetState().IsKeyDown(Keys.LeftShift))) PSpeed = 4;
            else PSpeed = 2;
            
            // Controls the player character's right and left movement.
            // D-Pad, Left Stick or Arrow Keys move left or right.
            if ((GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed) |
                (Keyboard.GetState().IsKeyDown(Keys.Right)) |
                (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0))
            {
                PVector = new Vector2(PVector.X + PSpeed, PVector.Y);
                player.FacingRight = true;
            }
            else if ((GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed) |
                (Keyboard.GetState().IsKeyDown(Keys.Left)) |
                (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0))
            {
                PVector = new Vector2(PVector.X - PSpeed, PVector.Y);
                player.FacingRight = false;
            }

            if ((GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed) |
                (Keyboard.GetState().IsKeyDown(Keys.Up)) | 
                (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0))
                PVector = new Vector2(PVector.X, PVector.Y - PSpeed);
            else if ((GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed) |
                (Keyboard.GetState().IsKeyDown(Keys.Down)) | 
                (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0))
                PVector = new Vector2(PVector.X, PVector.Y + PSpeed);

            player.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            //spriteBatch.Begin();
            //spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            player.Draw(spriteBatch, PVector);

            //spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            //spriteBatch.Draw(myTexture, spritePosition, Color.White);
            base.Draw(gameTime);

            //spriteBatch.End();
        }
    }
}
