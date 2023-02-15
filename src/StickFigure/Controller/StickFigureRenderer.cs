using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickFigureTool
{
    public class StickFigureRenderer
    {
        public float                    PointRadius             { get; set; } = 3;
        public float                    SegmentWidth            { get; set; } = 6;
        public bool                     ShowSegments            { get; set; } = true;
        public bool                     ShowPoints              { get; set; } = true;
        public bool                     ShowEye                 { get; set; } = true;
        public bool                     ShowEndLabel            { get; set; } = true;
        public bool                     ShowFigureLabel         { get; set; } = true;

        public StickFigureRenderer()
        {
        }

        public void Render(Control c, Graphics g, StickFigureScene scene)
        {
            // Segments
            g.CompositingQuality= CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.Bicubic;
            g.SmoothingMode     = SmoothingMode.AntiAlias;
            g.CompositingMode   = CompositingMode.SourceOver;

            if(ShowSegments)
            foreach(var i in scene.Figures)
            {
                foreach(var j in i.Segments)
                {
                    if(!ShowEye)
                    {
                        if(j.Begin.Name.Contains(" Eye")
                        || j.End  .Name.Contains(" Eye"))
                            continue;
                    }

                    var pen = new Pen(j.Color, SegmentWidth) { LineJoin= LineJoin.Round, EndCap= LineCap.Round, StartCap= LineCap.Round };

                    g.DrawLine(pen, j.Begin.X, j.Begin.Y, j.End.X, j.End.Y);
                }
            }

            // Points
            var r   = PointRadius;
            var r2  = PointRadius * 2;

            foreach(var i in scene.Figures)
            {
                foreach(var j in i.Points)
                {
                    if(!ShowEye)
                    {
                        if(j.Name.Contains(" Eye"))
                            continue;
                    }

                    var brs = new SolidBrush(j.Color);
                    var pen = new Pen(j.EdgeColor, 1);

                    g.FillEllipse(brs, j.X-r, j.Y-r, r2, r2);

                    if(ShowPoints)
                        g.DrawEllipse(pen, j.X-r, j.Y-r, r2, r2);
                }
            }

            // Labels
            if(ShowFigureLabel)
                foreach(var i in scene.Figures)
                    DrawLabel(c, g, i.Body);

            if(ShowEndLabel)
            {
                foreach(var i in scene.Figures)
                {
                    DrawLabel(c, g, i.Head    .LeftEyeEnd);
                    DrawLabel(c, g, i.Head    .RightEyeEnd);
                    DrawLabel(c, g, i.LeftArm .Hand);
                    DrawLabel(c, g, i.RightArm.Hand);
                    DrawLabel(c, g, i.LeftLeg .Foot);
                    DrawLabel(c, g, i.RightLeg.Foot);
                }
            }
        }

        private void DrawLabel(Control c, Graphics g, StickFigurePoint p)
        {
            var l   = p.Label;
            var size= g.MeasureString(l, c.Font);
            var x   = p.X - size.Width  / 2;
            var y   = p.Y - size.Height - 4;

            g.DrawString(l, c.Font, new SolidBrush(Color.White), x, y);
        }
    }
}
