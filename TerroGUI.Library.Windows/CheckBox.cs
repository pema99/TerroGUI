using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerroGUI
{
    public class CheckBoxEventArgs : EventArgs
    {
        public bool Value { get; set; }
    }

    public class CheckBox : Control
    {
        /// <summary>
        /// Indicates whether or not this CheckBox is checked.
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// The color of the box.
        /// </summary>
        public Color BoxColor { get; set; }

        /// <summary>
        /// The color of the check indicator.
        /// </summary>
        public Color IndicatorColor { get; set; }

        /// <summary>
        /// The color of the CheckBox's border.
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// Event handler for when the value of this checkbox is changed.
        /// </summary>
        public delegate void ValueChangedEventHandler(object Source, CheckBoxEventArgs Args);

        /// <summary>
        /// Called when the value of this checkbox is changed.
        /// </summary>
        public event ValueChangedEventHandler ValueChanged;

        /// <summary>
        /// Blank texture, internal use only
        /// </summary>
        private Texture2D Blank { get; set; }

        /// <summary>
        /// Internal use only.
        /// </summary>
        private bool PreviousState { get; set; }

        public CheckBox(Container Parent, bool InitialValue, Color BoxColor, Color IndicatorColor, Color BorderColor, Rectangle Bounds)
            : base(Parent)
        {
            this.Checked = InitialValue;
            this.BoxColor = BoxColor;
            this.IndicatorColor = IndicatorColor;
            this.BorderColor = BorderColor;

            this.X = Bounds.X;
            this.Y = Bounds.Y;
            this.Width = Bounds.Width;
            this.Height = Bounds.Height;

            Texture2D Blank = new Texture2D(Parent.Main,1,1);
            Blank.SetData<Color>(new Color[] { Color.White });
            this.Blank = Blank;
            
            this.MouseClicked += (object Source, MouseClickedEventArgs Args) => { if (Args.Button == MouseButton.Left) Checked = !Checked; };

            this.PreviousState = Checked;
        }

        public CheckBox(Container Parent, bool InitialValue, Color BoxColor, Color IndicatorColor, Color BorderColor, Point Position)
            : base(Parent)
        {
            this.Checked = InitialValue;
            this.BoxColor = BoxColor;
            this.IndicatorColor = IndicatorColor;
            this.BorderColor = BorderColor;

            this.X = Position.X;
            this.Y = Position.Y;
            this.Width = 10;
            this.Height = 10;

            Texture2D Blank = new Texture2D(Parent.Main, 1, 1);
            Blank.SetData<Color>(new Color[] { Color.White });
            this.Blank = Blank;

            this.MouseClicked += (object Source, MouseClickedEventArgs Args) => { if (Args.Button == MouseButton.Left) Checked = !Checked; };

            this.PreviousState = Checked;
        }

        public override void Update(GameTime gameTime)
        {
            if (Checked != PreviousState)
                ValueChanged(this, new CheckBoxEventArgs { Value = Checked });

            PreviousState = Checked;

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Blank, new Rectangle(RealX, RealY, Width, Height), BorderColor);
            spriteBatch.Draw(Blank, new Rectangle(RealX + 1, RealY + 1, Width - 2, Height - 2), BoxColor);
            if (Checked)
                spriteBatch.Draw(Blank, new Rectangle(RealX + 2, RealY + 2, Width - 4, Height - 4), IndicatorColor);

            base.Draw(spriteBatch);
        }
    }
}
