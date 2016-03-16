using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerroGUI
{
    public class Button : Control
    {
        /// <summary>
        /// Font used in this button.
        /// </summary>
        public SpriteFont Font { get; set; }

        /// <summary>
        /// Color of text in this button.
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// Internal use only.
        /// </summary>
        private string text;

        /// <summary>
        /// Text displayed on this button.
        /// </summary>
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
            }
        }

        /// <summary>
        /// Texture of this button
        /// </summary>
        public Texture2D ButtonTexture { get; set; }

        public Button(Container Parent, Rectangle Bounds, SpriteFont Font, Color TextColor, string Text, Color ButtonColor)
            : base(Parent)
        {
            this.Font = Font;
            this.TextColor = TextColor;
            this.Text = Text;

            this.X = Bounds.X;
            this.Y = Bounds.Y;
            this.Width = Bounds.Width;
            this.Height = Bounds.Height;

            Texture2D Blank = new Texture2D(Parent.Main, 1, 1);
            Blank.SetData<Color>(new Color[] { ButtonColor });
            this.ButtonTexture = Blank;
        }

        public Button(Container Parent, Rectangle Bounds, SpriteFont Font, Color TextColor, string Text, Texture2D ButtonTexture)
            : base(Parent)
        {
            this.Font = Font;
            this.TextColor = TextColor;
            this.Text = Text;

            this.X = Bounds.X;
            this.Y = Bounds.Y;
            this.Width = Bounds.Width;
            this.Height = Bounds.Height;

            this.ButtonTexture = ButtonTexture;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ButtonTexture, new Rectangle(RealX, RealY, Width, Height), Color.White);
            spriteBatch.DrawString(Font, Text, new Vector2((RealX + Width / 2) - Font.MeasureString(Text).X / 2, (RealY + Height / 2) - Font.MeasureString(Text).Y / 2), TextColor);
            base.Draw(spriteBatch);
        }
    }
}
