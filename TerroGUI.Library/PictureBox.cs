using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerroGUI
{
    public class PictureBox : Control
    {
        /// <summary>
        /// Picture to be displayed on this PictureBox.
        /// </summary>
        public Texture2D Picture { get; set; }

        public PictureBox(Container Parent, Rectangle Bounds, Texture2D Picture)
            : base(Parent)
        {
            this.X = Bounds.X;
            this.Y = Bounds.Y;
            this.Picture = Picture;
            this.Width = Bounds.Width;
            this.Height = Bounds.Height;
        }

        public PictureBox(Container Parent, Point Position, Texture2D Picture)
            : base(Parent)
        {
            this.X = Position.X;
            this.Y = Position.Y;
            this.Picture = Picture;
            this.Width = Picture.Width;
            this.Height = Picture.Height;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Picture, new Rectangle(RealX, RealY, Width, Height), Color.White);
            base.Draw(spriteBatch);
        }
    }
}
