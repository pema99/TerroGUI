using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerroGUI
{
    public class Label : Control
    {
        /// <summary>
        /// Font used in this label.
        /// </summary>
        public SpriteFont Font { get; set; }

        /// <summary>
        /// Color of text in this label.
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// Internal use only.
        /// </summary>
        private string text;

        /// <summary>
        /// Text displayed on this label.
        /// </summary>
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                this.Width = (int)Font.MeasureString(value).X;
                this.Height = (int)Font.MeasureString(value).Y;
            }
        }

        public Label(Container Parent, Point Position, SpriteFont Font, Color TextColor, string Text)
            : base(Parent)
        {
            this.Font = Font;
            this.TextColor = TextColor;
            this.Text = Text;

            this.X = Position.X;
            this.Y = Position.Y;
            this.Width = (int)Font.MeasureString(Text).X;
            this.Height = (int)Font.MeasureString(Text).Y;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, Text, new Vector2(RealX, RealY), TextColor);
            base.Draw(spriteBatch);
        }
    }
}
