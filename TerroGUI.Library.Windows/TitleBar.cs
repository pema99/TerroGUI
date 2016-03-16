using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerroGUI
{
    public class TitleBar : Control
    {
        /// <summary>
        /// Internal use only.
        /// </summary>
        private string title;

        /// <summary>
        /// Title to display in this title bar.
        /// </summary>
        public string Title 
        { 
            get { return title; } 
            set 
            { 
                title = value; 
                Height = (int)Font.MeasureString(value).Y; 
            } 
        }

        /// <summary>
        /// Font to be used in this title bar.
        /// </summary>
        public SpriteFont Font { get; set; }

        /// <summary>
        /// Boolean determining whether or not this title bar is moving it's parent.
        /// </summary>
        public bool Moving { get; set; }

        /// <summary>
        /// Texture of this title bar.
        /// </summary>
        public Texture2D Texture { get; set; }

        /// <summary>
        /// Color of this title bar's text.
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// Offset from title bar used for dragging, internal use only.
        /// </summary>
        private Point DragOffset { get; set; }

        public TitleBar(Container Parent, string Title, SpriteFont Font, Color BarColor, Color TextColor, bool InsideContainer = false)
            : base(Parent)
        {
            this.Font = Font;
            this.Title = Title;
            this.X = 0;
            this.Width = Parent.Width;
            this.Height = (int)Font.MeasureString(Title).Y;
            this.TextColor = TextColor;

            if (InsideContainer)
                this.Y = 0;
            else
                this.Y = -Height;

            Texture2D Blank = new Texture2D(Parent.Main, 1, 1);
            Blank.SetData<Color>(new Color[] { BarColor });
            Texture = Blank;

            this.MouseClicked += (object Source, MouseClickedEventArgs Args) => { if (Args.Button == MouseButton.Left) { Moving = true; DragOffset = new Point(Mouse.GetState().X - Parent.X, Mouse.GetState().Y - Parent.Y); } };
        }

        public TitleBar(Container Parent, int Height, SpriteFont Font, Color BarColor, Color TextColor, bool InsideContainer = false)
            : base(Parent)
        {
            this.Font = Font;
            this.Title = Title;
            this.X = 0;
            this.Width = Parent.Width;
            this.Height = Height;
            this.TextColor = TextColor;

            if (InsideContainer)
                this.Y = 0;
            else
                this.Y = -Height;

            Texture2D Blank = new Texture2D(Parent.Main, 1, 1);
            Blank.SetData<Color>(new Color[] { BarColor });
            Texture = Blank;

            this.MouseClicked += (object Source, MouseClickedEventArgs Args) => { if (Args.Button == MouseButton.Left) { Moving = true; DragOffset = new Point(Mouse.GetState().X - Parent.X, Mouse.GetState().Y - Parent.Y); } };
        }

        public TitleBar(Container Parent, string Title, SpriteFont Font, Texture2D Texture, Color TextColor, bool InsideContainer = false)
            : base(Parent)
        {
            this.Font = Font;
            this.Title = Title;
            this.X = 0;
            this.Width = Parent.Width;
            this.Height = (int)Font.MeasureString(Title).Y;
            this.Texture = Texture;
            this.TextColor = TextColor;

            if (InsideContainer)
                this.Y = 0;
            else
                this.Y = -Height;

            this.MouseClicked += (object Source, MouseClickedEventArgs Args) => { if (Args.Button == MouseButton.Left) { Moving = true; DragOffset = new Point(Mouse.GetState().X - Parent.X, Mouse.GetState().Y - Parent.Y); } };
        }

        public TitleBar(Container Parent, int Height, SpriteFont Font, Texture2D Texture, Color TextColor, bool InsideContainer = false)
            : base(Parent)
        {
            this.Font = Font;
            this.Title = Title;
            this.X = 0;
            this.Width = Parent.Width;
            this.Height = Height;
            this.Texture = Texture;
            this.TextColor = TextColor;

            if (InsideContainer)
                this.Y = 0;
            else
                this.Y = -Height;

            this.MouseClicked += (object Source, MouseClickedEventArgs Args) => { if (Args.Button == MouseButton.Left) { Moving = true; DragOffset = new Point(Mouse.GetState().X - Parent.X, Mouse.GetState().Y - Parent.Y); } };
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (Moving)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Released)
                    Moving = false;

                Parent.X = Mouse.GetState().X - DragOffset.X;
                Parent.Y = Mouse.GetState().Y - DragOffset.Y;
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle(RealX, RealY, Width, Height), Color.White);
            spriteBatch.DrawString(Font, Title, new Vector2((RealX + Width / 2) - Font.MeasureString(Title).X / 2, RealY), TextColor);
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Sets the texture of this title bar to a solid color.
        /// </summary>
        public void SetTitleBarColor(Color TitleBarColor)
        {
            Texture2D Blank = new Texture2D(Parent.Main, 1, 1);
            Blank.SetData<Color>(new Color[] { TitleBarColor });
            this.Texture = Blank;
        }
    }
}
