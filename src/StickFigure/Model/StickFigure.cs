using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StickFigureTool
{
    public class StickFigure : StickFigureObject, IStickFigureSegmentSet, IStickFigurePointSet
    {
        public bool                     Enabled                 { get; set; } = true;
        public StickFigurePoint         Body                    { get; set; }
        public StickFigureHead          Head                    { get; set; }
        public StickFigureArm           LeftArm                 { get; private set; }
        public StickFigureArm           RightArm                { get; private set; }
        public StickFigureLeg           LeftLeg                 { get; private set; }
        public StickFigureLeg           RightLeg                { get; private set; }
        public StickFigureSegment       BodyToHead              { get; private set; }
        public StickFigureSegment       BodyToLeftLeg           { get; private set; }
        public StickFigureSegment       BodyToRightLeg          { get; private set; }
        public StickFigureSegment       BodyToLeftArm           { get; private set; }
        public StickFigureSegment       BodyToRightArm          { get; private set; }

        public IEnumerable<StickFigurePoint> Points
        {
            get
            {
                yield return Body;

                foreach(var i in Head)      yield return i;
                foreach(var i in LeftLeg)   yield return i;
                foreach(var i in RightLeg)  yield return i;
                foreach(var i in LeftArm)   yield return i;
                foreach(var i in RightArm)  yield return i;
            }
        }

        public IEnumerable<StickFigureSegment> Segments
        {
            get
            {
                yield return BodyToHead;
                yield return BodyToLeftLeg;
                yield return BodyToRightLeg;
                yield return BodyToLeftArm;
                yield return BodyToRightArm;

                foreach(var i in Head    .Segments) yield return i;
                foreach(var i in LeftArm .Segments) yield return i;
                foreach(var i in RightArm.Segments) yield return i;
                foreach(var i in LeftLeg .Segments) yield return i;
                foreach(var i in RightLeg.Segments) yield return i;
            }
        }

        public Rectangle                Bounds
        {
            get
            {
                var minx    = int.MaxValue;
                var miny    = int.MaxValue;
                var maxx    = int.MinValue;
                var maxy    = int.MinValue;

                foreach(var i in Points)
                {
                    if(i.X < minx)  minx= i.X;
                    if(i.Y < miny)  miny= i.Y;
                    if(i.X > maxx)  maxx= i.X;
                    if(i.Y > maxy)  maxx= i.Y;
                }

                return Rectangle.FromLTRB(minx, miny, maxx, maxy);
            }
        }

        public StickFigure(Point p)
        {
            Body            = new StickFigurePoint(p) { Name= "Body", Label= "Body" };
            Head            = new StickFigureHead(new Point(p.X, p.Y-40));
            LeftArm         = new StickFigureArm(new Point(p.X + 20, p.Y +  0), 0);
            RightArm        = new StickFigureArm(new Point(p.X - 20, p.Y +  0), 1);
            LeftLeg         = new StickFigureLeg(new Point(p.X + 12, p.Y +100), 0);
            RightLeg        = new StickFigureLeg(new Point(p.X - 12, p.Y +100), 1);

            Head    .Root.Parent = Body;
            LeftArm .Root.Parent = Body;
            RightArm.Root.Parent = Body;
            LeftLeg .Root.Parent = Body;
            RightLeg.Root.Parent = Body;
            #if FLIP_COLOR_SIDE
            BodyToHead      = new StickFigureSegment(Body, Head.Root,     Color.FromArgb(0,   0, 153));
            BodyToLeftArm   = new StickFigureSegment(Body, LeftArm.Root,  Color.FromArgb(153,  0,  0));
            BodyToLeftLeg   = new StickFigureSegment(Body, LeftLeg.Root,  Color.FromArgb(  0,153,  0));
            BodyToRightArm  = new StickFigureSegment(Body, RightArm.Root, Color.FromArgb(153, 51,  0));
            BodyToRightLeg  = new StickFigureSegment(Body, RightLeg.Root, Color.FromArgb(  0,153,153));
            #else
            BodyToHead      = new StickFigureSegment(Body, Head.Root,     Color.FromArgb(0,   0, 153));
            BodyToLeftArm   = new StickFigureSegment(Body, LeftArm.Root,  Color.FromArgb(153, 51,  0));
            BodyToRightArm  = new StickFigureSegment(Body, RightArm.Root, Color.FromArgb(153,  0,  0));
            BodyToLeftLeg   = new StickFigureSegment(Body, LeftLeg.Root,  Color.FromArgb(  0,153,153));
            BodyToRightLeg  = new StickFigureSegment(Body, RightLeg.Root, Color.FromArgb(  0,153,  0));
            #endif
        }

        public void Offset(int x, int y)
        {
            foreach(var i in Points)
                i.Offset(x, y);
        }

        public StickFigureHitInfo HitTest(int x, int y, int range = 4)
        {
            var dist    = int.MaxValue;
            var closest = default(StickFigurePoint);
            range       *=range;

            foreach(var i in Points)
            {
                var xx  = x - i.X;
                var yy  = y - i.Y;
                var d   = xx*xx + yy*yy;

                if(d < dist)
                {
                    closest = i;
                    dist    = d;
                }
            }

            return new StickFigureHitInfo(Math.Sqrt(dist), closest);
        }
    }

    public class StickFigureHitInfo
    {
        public double                   Distance                { get; private set; } = double.MaxValue;
        public StickFigurePoint         Point                   { get; private set; }

        public StickFigureHitInfo(double dist, StickFigurePoint p)
        {
            Distance= dist;
            Point   = p;
        }
    }
}
