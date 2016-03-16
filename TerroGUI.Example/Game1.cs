using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TerroGUI
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Container Form; 

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteFont Font = Content.Load<SpriteFont>("Courier New");
            
            Form = new Container(GraphicsDevice, new Rectangle(50, 50, 300, 200), Color.Black);
            
            Label TestLabel = new Label(Form, new Point(10, 20), Font, Color.Red, "Label");
            
            Button TestButton = new Button(Form, new Rectangle(10, 50, 100, 50), Font, Color.Green, "Button", Color.Red);
            TestButton.MouseClicked += (object Source, MouseClickedEventArgs Args) => { Console.WriteLine("Button clicked (Mouse: {0})", Args.Button.ToString()); };

            CheckBox TestBox = new CheckBox(Form, false, Color.White, Color.Red, Color.Green, new Point(50, 120));
            TestBox.ValueChanged += (object Source, CheckBoxEventArgs Args) => { Console.WriteLine("Checkbox value: "+Args.Value); };

            TitleBar TestBar = new TitleBar(Form, "TitleBar", Font, Color.Green, Color.Red);

            ProgressBar TestProgress = new ProgressBar(Form, Color.Red, Color.Green, new Rectangle(150,100,100,20));
            TestProgress.MouseClicked += delegate { TestProgress.Progress = Mouse.GetState().X - TestProgress.RealX; Console.WriteLine("ProgressBar: " + TestProgress.Progress); };

            TextBox TestText = new TextBox(Form, Font, Color.White, Color.Red, new Rectangle(150, 130, 100, 20), "Hey");

            Form.Controls.Add(TestLabel);
            Form.Controls.Add(TestButton);
            Form.Controls.Add(TestBox);
            Form.Controls.Add(TestBar);
            Form.Controls.Add(TestProgress);
            Form.Controls.Add(TestText);

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Form.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            Form.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
