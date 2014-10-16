using DockPlane.Exterior;
using DockPlane.WKTheme;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DockPlane
{
    internal class Plane : Dockable
    {
        public bool IsCombined
        {
            internal set;
            get;
        }

        private DockState _state = DockState.Floating;
        public DockState State
        {
            private set { _state = value; }
            get { return _state; }
        }

        private DockForm _dockForm;
        private TitleBar _titleBar;
        private Border _border;

        public DockForm DockForm { set { _dockForm = value; } get { return _dockForm; } }
        public TitleBar TitleBar { set { _titleBar = value; } get { return _titleBar; } }
        public Border Border { set { _border = value; } get { return _border; } }

        private bool _active = false;
        public bool Active
        {
            internal set
            {
                if (_active == value)
                    return;
                _active = value;
                if (!_active)
                    TitleBar.Active = Border.Active = false;
            }
            get { return _active; }
        }

        internal Plane(DockForm form)
        {
            if (form == null)
                throw new ArgumentNullException("form could not be null");

            DockForm = form;
            State = DockState.Floating;

            SetupUI();
            FitSize();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            TitleBar.MouseDown += TitleBar_MouseDown;
            TitleBar.MouseUp += TitleBar_MouseUp;
            TitleBar.MouseHover += TitleBar_MouseHover;
            TitleBar.MouseLeave += TitleBar_MouseLeave;
        }

        private void SetupUI()
        {
            DockForm.BeginEmbed();

            TitleBar = DefaultTheme.Default.CreateTitleBar();
            TitleBar.Title = "Test";
            TitleBar.Location = new Point(0, 0);
            TitleBar.Font = DockForm.DesignFont;

            Border = DefaultTheme.Default.CreateBorder();
            Border.Location = new Point(0, TitleBar.Bottom);
            Border.FormSize = DockForm.Size;

            TitleBar.MinLength = Border.Width;
            TitleBar.MaxLength = Border.Width;

            DockForm.Location = new Point(Border.FormOffset.X, Border.FormOffset.Y + TitleBar.Bottom);

            Controls.Add(TitleBar);
            Controls.Add(DockForm);
            Controls.Add(Border);
        }

        private void FitSize()
        {
            Width = Border.Width;
            Height = Border.Height + TitleBar.Height;
        }

        void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            Active = true;
            TitleBar.Active = true;
            BeginDrag(TitleBar, e.Location);
        }

        void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            EndDrag();
        }

        void TitleBar_MouseLeave(object sender, EventArgs e)
        {
            TitleBar.Hover = false;
        }

        void TitleBar_MouseHover(object sender, EventArgs e)
        {
            TitleBar.Hover = true;
        }
    }
}
