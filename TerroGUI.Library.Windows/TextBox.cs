using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerroGUI
{
    public class TextBox : Control
    {
        /// <summary>
        /// Text displayed in this text box.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Font used in this text box.
        /// </summary>
        public SpriteFont Font { get; set; }

        /// <summary>
        /// Color of text in this text box.
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// Texture of this text box.
        /// </summary>
        public Texture2D BoxTexture { get; set; }

        /// <summary>
        /// Boolean determining whether or not user can write in this text box at this moment.
        /// </summary>
        public bool HasFocus { get; set; }

        /// <summary>
        /// Internal use only.
        /// </summary>
        private KeyboardState PreviousState { get; set; }

        public TextBox(Container Parent, SpriteFont Font, Texture2D BoxTexture, Color TextColor, Rectangle Bounds, string Text)
            : base(Parent)
        {
            this.Font = Font;
            this.BoxTexture = BoxTexture;
            this.TextColor = TextColor;
            this.HasFocus = false;

            this.X = Bounds.X;
            this.Y = Bounds.Y;
            this.Width = Bounds.Width;
            this.Height = Bounds.Height;

            this.Text = Text;
            this.PreviousState = Keyboard.GetState();

            this.MouseClicked += (object Source, MouseClickedEventArgs Args) => { if (Args.Button == MouseButton.Left) HasFocus = true; };
        }

        public TextBox(Container Parent, SpriteFont Font, Color BoxColor, Color TextColor, Rectangle Bounds, string Text)
            : base(Parent)
        {
            this.Font = Font;

            Texture2D Blank = new Texture2D(Parent.Main, 1, 1);
            Blank.SetData<Color>(new Color[] { BoxColor });
            this.BoxTexture = Blank;

            this.TextColor = TextColor;
            this.HasFocus = false;

            this.X = Bounds.X;
            this.Y = Bounds.Y;
            this.Width = Bounds.Width;
            this.Height = Bounds.Height;

            this.Text = Text;
            this.PreviousState = Keyboard.GetState();

            this.MouseClicked += (object Source, MouseClickedEventArgs Args) => { if (Args.Button == MouseButton.Left) HasFocus = true; };
        }

        public override void Update(GameTime gameTime)
        {
            if (HasFocus)
            {
                Keys[] Pressed = Keyboard.GetState().GetPressedKeys();

                foreach (Keys key in Pressed)
                {
                    if (PreviousState.IsKeyUp(key))
                    {
                        if (key == Keys.Back)
                        {
                            if (Text.Length >= 1)
                                Text = Text.Remove(Text.Length - 1);
                        }
                        else if (key == Keys.Space)
                        {
                            Text += " ";
                        }
                        //Numbers
                        else if (key.ToString().Length == 2 && key.ToString().Contains("D"))
                        {
                            Text += key.ToString().Replace("D","");
                        }
                        else
                        {
                            //Letters
                            if (key != Keys.LeftShift && key != Keys.RightShift && key.ToString().Length == 1)
                            {
                                if (Pressed.Contains(Keys.RightShift) || Pressed.Contains(Keys.LeftShift))
                                    Text += key.ToString();
                                else
                                    Text += key.ToString().ToLower();
                            }
                        }
                    }
                }
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !Mouse.GetState().Intersects(new Rectangle(RealX, RealY, Width, Height)))
                HasFocus = false;

            //Trim text
            if (Font.MeasureString(Text).X > Width)
            {
                string Trimmed = "";
                foreach (char c in Text.ToCharArray())
                {
                    if (Font.MeasureString(Trimmed + c.ToString()).X <= Width)
                    {
                        Trimmed += c.ToString();
                    }
                    else break;
                }
                Text = Trimmed;
            }
            if (Font.MeasureString(Text).Y > Height)
                Height = (int)Font.MeasureString(Text).Y;

            PreviousState = Keyboard.GetState();

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BoxTexture, new Rectangle(RealX, RealY, Width, Height), Color.White);
            spriteBatch.DrawString(Font, Text, new Vector2((RealX + Width / 2) - Font.MeasureString(Text).X / 2, (RealY + Height / 2) - Font.MeasureString(Text).Y / 2), TextColor);
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Sets the background of this text box texture to a solid color.
        /// </summary>
        public void SetBackgroundColor(Color BackgroundColor)
        {
            Texture2D Blank = new Texture2D(Parent.Main, 1, 1);
            Blank.SetData<Color>(new Color[] { BackgroundColor });
            this.BoxTexture = Blank;
        }
    }
}
