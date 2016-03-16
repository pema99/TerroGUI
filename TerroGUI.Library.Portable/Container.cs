using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerroGUI
{
    public class Container
    {
        /// <summary>
        /// A list of control components attached to this container.
        /// </summary>
        public List<Control> Controls { get; set; }

        /// <summary>
        /// X coordinate of this container.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate of this container.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Width of this container.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of this container.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Boolean determining whether or not this container is visible/interactable.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// The background texture of this form.
        /// </summary>
        public Texture2D Background { get; set; }

        /// <summary>
        /// Reference to a needed GraphicsDevice, internal use only.
        /// </summary>
	public GraphicsDevice Main { get; set; }

	public Container(GraphicsDevice Main, Rectangle Bounds, Color ContainerColor, bool Visible = true)
        {
            this.Main = Main;
            this.Controls = new List<Control>();
            this.X = Bounds.X;
            this.Y = Bounds.Y;
            this.Width = Bounds.Width;
            this.Height = Bounds.Height;
            this.Visible = Visible;

            Texture2D Blank = new Texture2D(Main, 1, 1);
            Blank.SetData<Color>(new Color[] { ContainerColor });
            this.Background = Blank;
        }

	public Container(GraphicsDevice Main, Rectangle Bounds, Texture2D Background, bool Visible = true)
        {
            this.Main = Main;
            this.Controls = new List<Control>();
            this.X = Bounds.X;
            this.Y = Bounds.Y;
            this.Width = Bounds.Width;
            this.Height = Bounds.Height;
            this.Visible = Visible;
            this.Background = Background;
        }

        /// <summary>
        /// Updates this container and all controls attached to it.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            if (Visible)
            {
                foreach (Control c in Controls)
                {
                    if (c.Active)
                    {
                        c.Update(gameTime);
                    }
                }
            }
        }

        /// <summary>
        /// Draws this container and all controls attached to it.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(Background, new Rectangle(X, Y, Width, Height), Color.White);

                foreach (Control c in Controls)
                {
                    if (c.Active)
                    {
                        c.Draw(spriteBatch);
                    }
                }
            }
        }

        /// <summary>
        /// Allows user to set background to a solid color.
        /// </summary>
        public void SetBackgroundColor(Color ContainerColor)
        {
            Texture2D Blank = new Texture2D(Main, 1, 1);
            Blank.SetData<Color>(new Color[] { ContainerColor });
            this.Background = Blank;
        }
    }
}
