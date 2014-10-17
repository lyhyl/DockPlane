using DockPlane.Exterior;
using DockPlane.WKTheme;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DockPlane
{
    public class Plane : Dockable
    {
        #region controls

        private DockForm _dockForm;
        public DockForm DockForm { set { _dockForm = value; } get { return _dockForm; } }
        private TitleBar _titleBar;
        public TitleBar TitleBar { set { _titleBar = value; } get { return _titleBar; } }
        private Border _border;
        public Border Border { set { _border = value; } get { return _border; } }

        #endregion

        private bool _isActive = false;
        public override bool IsActive
        {
            internal set
            {
                if (_isActive == value)
                    return;
                _isActive = TitleBar.Active = Border.Active = value;
            }
            get { return _isActive; }
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

        private void RegisterEvents()
        {
            TitleBar.MouseDown += TitleBar_MouseDown;
            TitleBar.MouseUp += TitleBar_MouseUp;
            TitleBar.MouseHover += TitleBar_MouseHover;
            TitleBar.MouseLeave += TitleBar_MouseLeave;
        }

        void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (!IsActive)
            {
                IsActive = true;
                OnActive();
            }
            BeginDrag(TitleBar, e.Location);
            OnDragging();
        }

        void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            EndDrag();
            OnDragged();
        }

        void TitleBar_MouseLeave(object sender, EventArgs e)
        {
            TitleBar.Hover = false;
        }

        void TitleBar_MouseHover(object sender, EventArgs e)
        {
            TitleBar.Hover = true;
        }

        public override void DockTo(DockState ds)
        {
            State = ds;
        }
    }
}
