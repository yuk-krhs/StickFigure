using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickFigureTool
{
    public class StickFigureHead : StickFigurePoints, IStickFigureSegmentSet, IStickFigurePointSet
    {
        public StickFigurePoint         Root                    => this[0];
        public StickFigurePoint         Face                    => this[0];
        public StickFigurePoint         LeftEye                 => this[1];
        public StickFigurePoint         RightEye                => this[2];
        public StickFigurePoint         LeftEyeEnd              => this[3];
        public StickFigurePoint         RightEyeEnd             => this[4];
        public StickFigureSegment       FaceToLeftEye           { get; private set; }
        public StickFigureSegment       FaceToRightEye          { get; private set; }
        public StickFigureSegment       LeftEyeToEnd            { get; private set; }
        public StickFigureSegment       RightEyeToEnd           { get; private set; }

        public StickFigureHead(Point p)
            : base(5)
        {
            Face        .Set(p);                Face       .Name= "Face";       Face       .Label= "Face";
            LeftEye     .Set(p.X + 15, p.Y-5);  LeftEye    .Name= "L Eye";      LeftEye    .Label= "L Eye";
            RightEye    .Set(p.X - 15, p.Y-5);  RightEye   .Name= "R Eye";      RightEye   .Label= "R Eye";
            LeftEyeEnd  .Set(p.X + 30, p.Y);    LeftEyeEnd .Name= "L Eye End";  LeftEyeEnd .Label= "L Eye";
            RightEyeEnd .Set(p.X - 30, p.Y);    RightEyeEnd.Name= "R Eye End";  RightEyeEnd.Label= "R Eye";

            LeftEyeEnd.Parent   = LeftEye;
            LeftEye.Parent      = Face;
            RightEyeEnd.Parent  = RightEye;
            RightEye.Parent     = Face;

            #if FLIP_COLOR_SIDE
            FaceToLeftEye   = new StickFigureSegment(Face,     LeftEye,     Color.FromArgb( 51, 0, 153));
            LeftEyeToEnd    = new StickFigureSegment(LeftEye,  LeftEyeEnd,  Color.FromArgb(102, 0, 153));
            FaceToRightEye  = new StickFigureSegment(Face,     RightEye,    Color.FromArgb(153, 0, 153));
            RightEyeToEnd   = new StickFigureSegment(RightEye, RightEyeEnd, Color.FromArgb(153, 0, 102));
            #else
            FaceToLeftEye   = new StickFigureSegment(Face,     LeftEye,     Color.FromArgb(153, 0, 153));
            LeftEyeToEnd    = new StickFigureSegment(LeftEye,  LeftEyeEnd,  Color.FromArgb(153, 0, 102));
            FaceToRightEye  = new StickFigureSegment(Face,     RightEye,    Color.FromArgb( 51, 0, 153));
            RightEyeToEnd   = new StickFigureSegment(RightEye, RightEyeEnd, Color.FromArgb(102, 0, 153));
            #endif
        }

        public IEnumerable<StickFigureSegment> Segments
        {
            get
            {
                yield return FaceToLeftEye;
                yield return FaceToRightEye;
                yield return LeftEyeToEnd;
                yield return RightEyeToEnd;
            }
        }

        public IEnumerable<StickFigurePoint> Points => this;
    }

    public class StickFigureArm : StickFigureLimbs, IStickFigureSegmentSet, IStickFigurePointSet
    {
        public StickFigurePoint         Arm                     => this[0];
        public StickFigurePoint         Elbow                   => this[1];
        public StickFigurePoint         Hand                    => this[2];
        public StickFigureSegment       ArmToElbow              { get; private set; }
        public StickFigureSegment       BlbowToHand             { get; private set; }

        public StickFigureArm(Point p, int index)
            : base(3)
        {
            if((index % 2) == 0)
            {
                Arm  .Set(p.X+  0, p.Y);        Arm  .Name= "L Arm";    Arm  .Label= "L Arm";
                Elbow.Set(p.X+ 20, p.Y+50);     Elbow.Name= "L Elbow";  Elbow.Label= "L Elbow";
                Hand .Set(p.X+ 20, p.Y+100);    Hand .Name= "L Hand";   Hand .Label= "L Hand";

                #if FLIP_COLOR_SIDE
                ArmToElbow  = new StickFigureSegment(Arm,   Elbow, Color.FromArgb(152,102, 0));
                BlbowToHand = new StickFigureSegment(Elbow, Hand,  Color.FromArgb(152,153, 0));
                #else
                ArmToElbow  = new StickFigureSegment(Arm,   Elbow, Color.FromArgb(102,153, 0));
                BlbowToHand = new StickFigureSegment(Elbow, Hand,  Color.FromArgb( 53,153, 0));
                #endif
            } else
            {
                Arm  .Set(p.X-  0, p.Y);        Arm  .Name= "R Arm";    Arm  .Label= "R Arm";
                Elbow.Set(p.X- 20, p.Y+50);     Elbow.Name= "R Elbow";  Elbow.Label= "R Elbow";
                Hand .Set(p.X- 20, p.Y+100);    Hand .Name= "R Hand";   Hand .Label= "R Hand";

                #if FLIP_COLOR_SIDE
                ArmToElbow  = new StickFigureSegment(Arm,   Elbow, Color.FromArgb(102,153, 0));
                BlbowToHand = new StickFigureSegment(Elbow, Hand,  Color.FromArgb( 53,153, 0));
                #else
                ArmToElbow  = new StickFigureSegment(Arm,   Elbow, Color.FromArgb(152,102, 0));
                BlbowToHand = new StickFigureSegment(Elbow, Hand,  Color.FromArgb(152,153, 0));
                #endif
            }

            Hand.Parent = Elbow;
            Elbow.Parent= Arm;
        }

        public IEnumerable<StickFigureSegment> Segments
        {
            get
            {
                yield return ArmToElbow;
                yield return BlbowToHand;
            }
        }

        public IEnumerable<StickFigurePoint> Points => this;
    }

    public class StickFigureLeg : StickFigureLimbs, IStickFigureSegmentSet, IStickFigurePointSet
    {
        public StickFigurePoint         Leg                     => this[0];
        public StickFigurePoint         Nee                     => this[1];
        public StickFigurePoint         Foot                    => this[2];
        public StickFigureSegment       LegToNee                { get; private set; }
        public StickFigureSegment       NeeToFoot               { get; private set; }

        public StickFigureLeg(Point p, int index)
            : base(3)
        {
            if((index % 2) == 0)
            {
                Leg .Set(p.X,    p.Y);      Leg .Name= "L Leg";  Leg .Label= "L Leg";
                Nee .Set(p.X+10, p.Y+ 80);  Nee .Name= "L Nee";  Nee .Label= "L Leg";
                Foot.Set(p.X+10, p.Y+150);  Foot.Name= "L Foot"; Foot.Label= "L Foot";

                #if FLIP_COLOR_SIDE
                LegToNee    = new StickFigureSegment(Leg, Nee,  Color.FromArgb(0, 153,  51));
                NeeToFoot   = new StickFigureSegment(Nee, Foot, Color.FromArgb(0, 153, 102));
                #else
                LegToNee    = new StickFigureSegment(Leg, Nee,  Color.FromArgb(0, 102, 153));
                NeeToFoot   = new StickFigureSegment(Nee, Foot, Color.FromArgb(0,  51, 153));
                #endif
            } else
            {
                Leg .Set(p.X,    p.Y);      Leg .Name= "R Leg";  Leg .Label= "R Leg";
                Nee .Set(p.X-10, p.Y+ 80);  Nee .Name= "R Nee";  Nee .Label= "R Leg";
                Foot.Set(p.X-10, p.Y+150);  Foot.Name= "R Foot"; Foot.Label= "R Foot";
                #if FLIP_COLOR_SIDE
                LegToNee    = new StickFigureSegment(Leg, Nee,  Color.FromArgb(0, 102, 153));
                NeeToFoot   = new StickFigureSegment(Nee, Foot, Color.FromArgb(0,  51, 153));
                #else
                LegToNee    = new StickFigureSegment(Leg, Nee,  Color.FromArgb(0, 153,  51));
                NeeToFoot   = new StickFigureSegment(Nee, Foot, Color.FromArgb(0, 153, 102));
                #endif
            }

            Foot.Parent = Nee;
            Nee.Parent  = Leg;
        }

        public IEnumerable<StickFigureSegment> Segments
        {
            get
            {
                yield return LegToNee;
                yield return NeeToFoot;
            }
        }

        public IEnumerable<StickFigurePoint> Points => this;
    }

    public class StickFigureLimbs : StickFigurePoints
    {
        public StickFigurePoint         Root                    => this[0];
        public StickFigurePoint         End                     => this[Count-1];

        public StickFigureLimbs(int num)
            : base(num)
        {
        }
    }

    public class StickFigurePoints : List<StickFigurePoint>
    {
        public StickFigurePoints(int num)
        {
            for(int i= 0; i < num; i++)
                Add(new StickFigurePoint());
        }

        public Point Get(int index)             => this[index].p;
        public void Set(int index, Point value) => this[index].Set(value);

        public void Offset(Point off)
        {
            foreach(var i in this)
                i.Offset(off.X, off.Y);
        }
    }
}
