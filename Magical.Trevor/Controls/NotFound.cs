using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Magical.Trevor.Controls
{
    partial class NotFound : Control
    {
        public NotFound()
        {
        }

        public NotFound(IContainer container)
        {
            container.Add(this);
        }

        public string ExpectedViewType { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Pen pen = new Pen(this.ForeColor))
            using (Brush brush = new SolidBrush(this.ForeColor))
            {
                Rectangle clientRectangle = base.ClientRectangle;
                clientRectangle.Height -= 9;
                clientRectangle.Width -= 9;
                clientRectangle.X += 4;
                clientRectangle.Y += 4;

                pen.DashStyle = DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, clientRectangle);
                var message = String.Format("No view found for `{0}`.", ExpectedViewType);
                var measurement = e.Graphics.MeasureString(message, this.Font);

                var left = (clientRectangle.Width - measurement.Width) / 2;
                var top = (clientRectangle.Height - measurement.Height) / 2;

                e.Graphics.DrawString(message, this.Font, brush, left, top);
            }
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            base.Invalidate();
        }
    }
}
