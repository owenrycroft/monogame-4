using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_4
{
    public class Game1 : Game
    {//done at the adding sound step
        MouseState mouseState;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        SpriteFont timeFont;
        Texture2D bombtext;
        Rectangle bombRect;
        float seconds;
        SoundEffect explode;
        Texture2D bombexplotext;
        float startTime;
        int textgone=200;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges(); 


            base.Initialize();
        }

        protected override void LoadContent()
        {
            bombRect = new Rectangle(50, 50, 700, 400);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            timeFont = Content.Load<SpriteFont>("Bombtext");
            bombtext = Content.Load<Texture2D>("bomb");
            explode = Content.Load<SoundEffect>("explosion");
            bombexplotext = Content.Load<Texture2D>("bomb explo");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            seconds = (float)gameTime.TotalGameTime.TotalSeconds;
           
            if (seconds >= 30)
            {
                 Exit();
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
            }
           if(seconds>= 15)
            {
                explode.Play();
               // timeFont
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(bombtext,bombRect,Color.White);
            if (seconds >= 15)
            {
                _spriteBatch.Draw(bombexplotext,bombRect,Color.White);
                textgone = 6000;
            }
            _spriteBatch.DrawString(timeFont, seconds.ToString("0.00"), new Vector2(270, textgone), Color.Black);
            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;
            if (seconds > 30) 
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}