using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickFigureTool
{
    public interface IStickFigureSegmentSet
    {
        IEnumerable<StickFigureSegment> Segments                { get; }
    }

        public interface IStickFigurePointSet
    {
        IEnumerable<StickFigurePoint>   Points                  { get; }
    }

    public class StickFigureObject
    {
        public string                   Name                    { get; set; }  
        public string                   Label                   { get; set; }  
        public object                   Tag                     { get; set; }  
    }

    public class StickFigurePoint : StickFigureObject
    {
        internal Point                  p;
        private StickFigurePoint        parent;

        public StickFigurePoint         Parent                  { get => parent; set => SetParent(value); }
        public bool                     VisiblePoint            { get; set; } = true;
        public Color                    EdgeColor               { get; set; } = Color.White;
        public Color                    Color                   => VisiblePoint ? Color.White : Color.Black;
        public int                      X                       { get => p.X; set => p.X= value; }
        public int                      Y                       { get => p.Y; set => p.Y= value; }
        public Point                    Location                { get => p;   set => p  = value; }
        public List<StickFigurePoint>   Children                { get; private set; } = new List<StickFigurePoint>();

        public StickFigurePoint()
        {
        }

        public StickFigurePoint(Point p)
        {
            this.p  = p;
        }

        public StickFigurePoint(int x, int y)
        {
            this.p  = new Point(x, y);
        }

        private void SetParent(StickFigurePoint value)
        {
            if(null != parent)
                parent.Children.Remove(this);

            parent  = value;

            if(null != parent)
                parent.Children.Add(this);
        }

        public void Set(Point p)
        {
            this.p.X= p.X;
            this.p.Y= p.Y;
        }

        public void Set(int x, int y)
        {
            this.p.X= x;
            this.p.Y= y;
        }

        public void Set(int x, int y, string label)
        {
            this.p.X= x;
            this.p.Y= y;
            Label   = label;
        }

        public void Offset(int x, int y)
        {
            p.X +=x;
            p.Y +=y;
        }
    }

    public class StickFigureSegment : StickFigureObject
    {
        public StickFigurePoint         Begin                   { get; set; }
        public StickFigurePoint         End                     { get; set; }
        public Color                    Color                   { get; set; }

        public StickFigureSegment(StickFigurePoint b, StickFigurePoint e, Color c)
        {
            Begin   = b;
            End     = e;
            Color   = c;
        }
    }
}
