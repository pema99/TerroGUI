## Important note ##
TerroGUI.Library.Windows is Windows specific, and requires .NET Framework 4.5 or higher. Note that the default target for MonoGame projects is 4.0, although this can be changed in Properties -> Application -> Target Framework.

TerroGUI.Library.Portable supports multiple platforms, such as OSX, iOS and Android. This version of the library only requires .NET Framework 4.0, the default.

# About #
TerroGUI is a GUI library for XNA and MonoGame, written by Pema99 ([Pema99.net](http://pema99.net)). It is free to use in any way, although it would be nice if you informed me before using it. Most of the code is documented and easy to follow.
The library is currently a work in progress, and is not yet finished. I plan to add many more features. If you find any bugs, report them on this page or send me a mail at me@pema99.net with info.
### Current features: ###

* Draggable windows

* Button

* CheckBox

* Label

* PictureBox

* ProgressBar

* TextBox

* TitleBar


# License #
TerroGUI is licensed under the zlib/libpng license:

    TerroGUI - Copyright (c) 2015 Pema Malling

    This software is provided 'as-is', without any express or implied warranty.
    In no event will the authors be held liable for any damages arising from the use of this software.

    Permission is granted to anyone to use this software for any purpose,
    including commercial applications, and to alter it and redistribute it 
    freely, subject to the following restrictions:

    1. The origin of this software must not be misrepresented; you must not
    claim that you wrote the original software. If you use this software in a 
    product, an acknowledgment in the product documentation would be appreciated 
    but is not required.

    2. Altered source versions must be plainly marked as such, and must not be 
    misrepresented as being the original software.

    3. This notice may not be removed or altered from any source distribution.


# Example #
Below is an example of a window/form created using the library. It results in this: 

![FwY4Guk.png](https://bitbucket-assetroot.s3.amazonaws.com/repository/dpM9GL/3668746138-FwY4Guk.png?Signature=At40e3bMzK3SbrHuBT1vkUip%2FiU%3D&Expires=1438448043&AWSAccessKeyId=0EMWEFSGA12Z1HF1TZ82) 

Although (almost) everything is skinnable, for the sake of simplicity, I just used solid colors in this example. The font used in this example is "Open Sans", size 10. (Disregard the misleading "Courier New")    

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
				
				Form = new Container(this, new Rectangle(50, 50, 300, 200), Color.Black);
				
				Label TestLabel = new Label(Form, new Point(10, 20), Font, Color.Red, "Label");
				
				Button TestButton = new Button(Form, new Rectangle(10, 50, 100, 50), Font, Color.Green, "Button", Color.Red);
				TestButton.MouseClicked += 
				(object Source, MouseClickedEventArgs Args) => 
				{ 
					Console.WriteLine("Button clicked (Mouse: {0})", Args.Button.ToString()); 
				};

				CheckBox TestBox = new CheckBox(Form, false, Color.White, Color.Red, Color.Green, new Point(50, 120));
				TestBox.ValueChanged += 
				(object Source, CheckBoxEventArgs Args) => 
				{ 
					Console.WriteLine("Checkbox value: "+Args.Value); 
				};

				TitleBar TestBar = new TitleBar(Form, "TitleBar", Font, Color.Green, Color.Red);

				ProgressBar TestProgress = new ProgressBar(Form, Color.Red, Color.Green, new Rectangle(150,100,100,20));
				TestProgress.MouseClicked += 
                delegate 
				{ 
					TestProgress.Progress = Mouse.GetState().X - TestProgress.RealX; 
					Console.WriteLine("ProgressBar: " + TestProgress.Progress); 
				};

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
