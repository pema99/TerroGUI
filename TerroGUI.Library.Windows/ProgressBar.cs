using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerroGUI
{
    public class ProgressBar : Control
    {
        /// <summary>
        /// Internal use only.
        /// </summary>
        private int progress;

        /// <summary>
        /// Progress of this progress bar in procent.
        /// </summary>
        public int Progress 
        { 
            get { return progress; } 
            set 
            {
                if (value < 0)
                    progress = 0;
                else if (value > 100)
                    progress = 100;
                else
                    progress = value;
            } 
        }

        /// <summary>
        /// Texture of the background bar on this progress bar.
        /// </summary>
        public Texture2D BackgroundTexture { get; set; }

        /// <summary>
        /// Texture of the foreground bar on this progress bar.
        /// </summary>
        public Texture2D ForegroundTexture { get; set; }

        public ProgressBar(Container Parent, Color BackgroundColor, Color ForegroundColor, Rectangle Bounds) 
            : base(Parent)
        {
            Texture2D Background = new Texture2D(Parent.Main.GraphicsDevice, 1, 1);
            Background.SetData<Color>(new Color[] { BackgroundColor });
            this.BackgroundTexture = Background;

            Texture2D Foreground = new Texture2D(Parent.Main.GraphicsDevice, 1, 1);
            Foreground.SetData<Color>(new Color[] { ForegroundColor });
            this.ForegroundTexture = Foreground;

            this.X = Bounds.X;
            this.Y = Bounds.Y;
            this.Width = Bounds.Width;
            this.Height = Bounds.Height;
            this.Progress = 0;
        }

        public ProgressBar(Container Parent, Texture2D Background, Color ForegroundColor, Rectangle Bounds)
            : base(Parent)
        {
            this.BackgroundTexture = Background;

            Texture2D Blank = new Texture2D(Parent.Main.GraphicsDevice, 1, 1);
            Blank.SetData<Color>(new Color[] { ForegroundColor });
            this.ForegroundTexture = Blank;

            this.X = Bounds.X;
            this.Y = Bounds.Y;
            this.Width = Bounds.Width;
            this.Height = Bounds.Height;
            this.Progress = 0;
        }

        public ProgressBar(Container Parent, Color BackgroundColor, Texture2D Foreground, Rectangle Bounds)
            : base(Parent)
        {
            Texture2D Blank = new Texture2D(Parent.Main.GraphicsDevice, 1, 1);
            Blank.SetData<Color>(new Color[] { BackgroundColor });
            this.BackgroundTexture = Blank;

            this.ForegroundTexture = Foreground;

            this.X = Bounds.X;
            this.Y = Bounds.Y;
            this.Width = Bounds.Width;
            this.Height = Bounds.Height;
            this.Progress = 0;
        }

        public ProgressBar(Container Parent, Texture2D Background, Texture2D Foreground, Rectangle Bounds)
            : base(Parent)
        {
            this.BackgroundTexture = Background;
            this.ForegroundTexture = Foreground;

            this.X = Bounds.X;
            this.Y = Bounds.Y;
            this.Width = Bounds.Width;
            this.Height = Bounds.Height;
            this.Progress = 0;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackgroundTexture, new Rectangle(RealX, RealY, Width, Height), Color.White);
            spriteBatch.Draw(ForegroundTexture, new Rectangle(RealX, RealY, (int)((double)Width * (double)Progress/100.0), Height), Color.White);
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Sets the background of this progress bar to a solid color.
        /// </summary>
        public void SetBackgroundColor(Color BackgroundColor)
        {
            Texture2D Blank = new Texture2D(Parent.Main.GraphicsDevice, 1, 1);
            Blank.SetData<Color>(new Color[] { BackgroundColor });
            this.BackgroundTexture = Blank;
        }

        /// <summary>
        /// Sets the foreground of this progress bar to a solid color.
        /// </summary>
        public void SetForegroundColor(Color ForegroundColor)
        {
            Texture2D Blank = new Texture2D(Parent.Main.GraphicsDevice, 1, 1);
            Blank.SetData<Color>(new Color[] { ForegroundColor });
            this.ForegroundTexture = Blank;
        }
    }
}
