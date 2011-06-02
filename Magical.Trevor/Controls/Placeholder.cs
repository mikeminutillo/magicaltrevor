using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Magical.Trevor.Controls
{
    [DesignerCategory("Code"), ToolboxItem(true)]
    public partial class Placeholder : Control
    {
        private readonly Lifetime _lifetime = new Lifetime();

        public Placeholder()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            base.BackColor = Color.Transparent;
        }

        public Placeholder(IContainer container) : this()
        {
            container.Add(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (base.DesignMode)
            {
                using (Pen pen = new Pen(this.ForeColor))
                {
                    using (Brush brush = new SolidBrush(this.ForeColor))
                    {
                        Rectangle clientRectangle = base.ClientRectangle;
                        clientRectangle.Height--;
                        clientRectangle.Width--;
                        pen.DashStyle = DashStyle.Dash;
                        e.Graphics.DrawRectangle(pen, clientRectangle);
                        e.Graphics.DrawString(this.Name, this.Font, brush, (float)(clientRectangle.X + 2), (float)(clientRectangle.Y + 2));
                    }
                }
            }
        }

        private object _viewModel;

        public object ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                if (_viewModel == value) return;

                _lifetime.Flush();
                Controls.Clear();
                _viewModel = value;
                if (_viewModel == null) return;

                var view = Dependecies.ViewLocator.GetViewForModel(_viewModel);
                if (view == null) return; // TODO: <-- Ensure we never get null?

                var binding = Dependecies.ViewBinder.Bind(view, _viewModel);
                _lifetime.Add(binding);

                view.Dock = DockStyle.Fill;
                view.Show();
                Controls.Add(view);
            }
        }
    }
}
