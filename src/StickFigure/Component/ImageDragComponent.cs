using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickFigureTool
{
    public partial class ImageDragComponent : Component
    {
        private Control control;

        public Control                  Control                     { get => control; set => SetControl(value); }
        public bool                     Dragging                    { get; private set; }
        public DataObject               DraggingObject              { get; private set; }
        public Point                    BeginLocation               { get; private set; }
        public bool                     Enabled                     { get; set; } = true;

        public event EventHandler<DragObjectEventArgs> BeginDrag;

        public ImageDragComponent()
        {
            InitializeComponent();
        }

        public ImageDragComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected virtual void OnBeginDrag(DragObjectEventArgs e)   => BeginDrag?.Invoke(this, e);

        private void SetControl(Control value)
        {
            if(value == control)
                return;

            if(null != control)
            {
                control.MouseDown           -=Control_MouseDown;
                control.MouseMove           -=Control_MouseMove;
                control.MouseUp             -=Control_MouseUp;
                control.MouseCaptureChanged -=Control_MouseCaptureChanged;
            }

            control = value;

            if(null != control)
            {
                control.MouseDown           +=Control_MouseDown;
                control.MouseMove           +=Control_MouseMove;
                control.MouseUp             +=Control_MouseUp;
                control.MouseCaptureChanged +=Control_MouseCaptureChanged;
            }
        }

        private void DragBegin(MouseEventArgs e)
        {
            Control.Capture = true;
            Dragging        = true;
            BeginLocation   = e.Location;
        }

        private void DragEnd()
        {
            Control.Capture = false;
            Dragging        = false;
            DraggingObject  = null;
        }

        private void DragUpdate(MouseEventArgs e)
        {
            if(DraggingObject != null)
                return;

            var xx  = e.X - BeginLocation.X;
            var yy  = e.Y - BeginLocation.Y;

            if(xx*xx + yy*yy >= 10)
            {
                var e2  = new DragObjectEventArgs();
                
                OnBeginDrag(e2);

                if(null != e2.DataObject)
                {
                    DraggingObject  = e2.DataObject;

                    Control.DoDragDrop(DraggingObject, DragDropEffects.Copy);
                }
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if(!Enabled)
                return;

            if(e.Button == MouseButtons.Left)
                DragBegin(e);
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if(!Enabled)
                return;

            if(Dragging)
                DragEnd();
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if(!Enabled)
                return;

            if(e.Button == MouseButtons.Left && Dragging)
                DragUpdate(e);
        }

        private void Control_MouseCaptureChanged(object sender, EventArgs e)
        {
            if(!Enabled)
                return;

            if(!Control.Capture && Dragging)
                DragEnd();
        }
    }

    public class DragObjectEventArgs : EventArgs
    {
        public DataObject DataObject { get; set; }
    }
}
