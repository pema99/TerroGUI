using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerroGUI
{
    public enum MouseButton
    {
        Left, 
        Right
    }

    public class MouseClickedEventArgs
    {
        public MouseButton Button { get; set; }
    }

    public class Control
    {
        /// <summary>
        /// X coordinate of this control. (Relative)
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate of this control. (Relative)
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Non-relative X coordinate of this control.
        /// </summary>
        public int RealX { get { return Parent.X + X; } }

        /// <summary>
        /// Non-relative Y coordinate of this control.
        /// </summary>
        public int RealY { get { return Parent.Y + Y; } }

        /// <summary>
        /// Width of this control.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of this control.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Boolean determining if this control is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Parent container of this control.
        /// </summary>
        public Container Parent { get; protected set; }

        /// <summary>
        /// Previous mouse state, used for checking clicks, internal use only.
        /// </summary>
        private MouseState PreviousMouseState { get; set; }

        /// <summary>
        /// Event handler for when the mouse is clicked.
        /// </summary>
        public delegate void MouseClickedEventHandler(object Source, MouseClickedEventArgs Args);

        /// <summary>
        /// Called when mouse is clicked, and is overlapping this control.
        /// </summary>
        public event MouseClickedEventHandler MouseClicked;

        public Control(Container Parent)
        {
            this.Parent = Parent;
            this.Active = true;
            PreviousMouseState = Mouse.GetState();
        }

        /// <summary>
        /// Updates this control.
        /// </summary>
        public virtual void Update(GameTime gameTime)
        {
            if (PreviousMouseState.LeftButton == ButtonState.Released && Mouse.GetState().LeftButton == ButtonState.Pressed)
                if (Mouse.GetState().Intersects(new Rectangle(RealX, RealY, Width, Height)))
                    if (MouseClicked != null)
                        MouseClicked(this, new MouseClickedEventArgs { Button = MouseButton.Left });

            if (PreviousMouseState.RightButton == ButtonState.Released && Mouse.GetState().RightButton == ButtonState.Pressed)
                if (Mouse.GetState().Intersects(new Rectangle(RealX, RealY, Width, Height)))
                    if (MouseClicked != null)
                        MouseClicked(this, new MouseClickedEventArgs { Button = MouseButton.Right });

            PreviousMouseState = Mouse.GetState();
        }

        /// <summary>
        /// Draws this control.
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
