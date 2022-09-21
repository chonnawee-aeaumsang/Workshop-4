using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lab03
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public  SpriteBatch spriteBatch;
        Texture2D myTexture;
        Texture2D cloudTexture;
        Vector2 spriteposition = Vector2.Zero;
        Vector2[] scaleCloud;
        int frame = 3;
        Random r = new Random();
        Vector2[] cloudpos ;
        int[] speed;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            myTexture = Content.Load <Texture2D>("NatureSprite");
            cloudTexture = Content.Load<Texture2D>("Cloud_sprite");

            cloudpos = new Vector2[4];
            scaleCloud = new Vector2[4];
            speed = new int[4];


            for (int i = 0; i < 4; i++)
            {
                cloudpos[i].Y = r.Next(0, graphics.GraphicsDevice.Viewport.Height - cloudTexture.Height);
                scaleCloud[i].X = r.Next(1, 3);
                scaleCloud[i].Y = scaleCloud[i].X;
                speed[i] = r.Next(3,7);
            }
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            for (int i = 0; i < 4; i++)
            {
                cloudpos[i].X = cloudpos[i].X + speed[i];
                if (cloudpos[i].X > graphics.GraphicsDevice.Viewport.Width)
                {
                    cloudpos[i].X = 0;
                    cloudpos[i].Y = r.Next(0, graphics.GraphicsDevice.Viewport.Height - cloudTexture.Height);
                    scaleCloud[i].X = r.Next(1, 3);
                    scaleCloud[i].Y = scaleCloud[i].X;
                }
                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(new Color(85, 133, 50));
            spriteBatch.Begin();
            spriteBatch.Draw(myTexture, new Vector2(300,50), new Rectangle(128, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(400, 50), new Rectangle(128, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(500, 50), new Rectangle(128, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(600, 50), new Rectangle(128, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(100, 350), new Rectangle(0, 64, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(50, 50), new Rectangle(256, 128, 256, 256), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(300, 250), new Rectangle(128, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(400, 250), new Rectangle(128, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(500, 250), new Rectangle(128, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(600, 250), new Rectangle(128, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(420, 150), new Rectangle(192, 128, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(300, 150), new Rectangle(192, 128, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(350, 150), new Rectangle(192, 128, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(470, 150), new Rectangle(192, 128, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(520, 150), new Rectangle(192, 128, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(600,100 ), new Rectangle(128, 256, 128, 128), Color.White);
            for (int i = 0; i < 4; i++)
            {
                spriteBatch.Draw(cloudTexture, cloudpos[i], null, Color.White, 0, Vector2.Zero, scaleCloud[i], 0, 0);
            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
