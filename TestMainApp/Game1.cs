using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestMainApp
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        MonogameLibrary.UI.Elements.Slider Slider;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
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
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            MonogameLibrary.UI.Base.MonoClassManagerUI.InitManager(GraphicsDevice,
                Content, "");
            Slider = new MonogameLibrary.UI.Elements.Slider() { MinValue = 0, MaxValue = 100 };
            Slider.rectangle = (new Rectangle(0, 0, 400, 30));
            Slider.SliderChanged += (a) =>
            {
                if (a == 100)
                {
                    Exit();
                }
            };
            Slider.LoadTexture();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MonogameLibrary.UI.Base.MonoClassManagerUI.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            MonogameLibrary.UI.Base.MonoClassManagerUI.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
