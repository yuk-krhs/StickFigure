using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;

namespace StickFigureTool
{
    public class StickFigureScene
    {
        public float                    LineWidth               { get; set; } = 6;
        public int                      Width                   { get; set; } = 512;
        public int                      Height                  { get; set; } = 512;
        public int                      Margin                  { get; set; } = 64;
        public List<StickFigure>        Figures                 { get; private set; }

        public StickFigureScene()
        {
            Figures = new List<StickFigure>();
        }

        public StickFigure CreateFigure(int x, int y)
        {
            var figure  = new StickFigure(new Point(x, y));
            
            Figures.Add(figure);

            return figure;
        }

        public StickFigureHitInfo HitTest(int x, int y)
        {
            var dist    = double.MaxValue;
            var result  = default(StickFigureHitInfo);

            foreach(var i in Figures)
            {
                var hti = i.HitTest(x, y);

                if(hti.Distance < dist)
                {
                    dist    = hti.Distance;
                    result  = hti;
                }
            }

            return result;
        }

        public static JsonData ToJsonData(StickFigureScene value)
        {
            var data            = new JsonData();
            var settings        = new JsonData();
            var figures         = new JsonData();
            data["settings"]    = settings;
            data["figures"]     = figures;
            settings["width"]   = value.Width;
            settings["height"]  = value.Height;
            settings["margin"]  = value.Margin;
            settings["line width"]= value.LineWidth;

            foreach(var i in value.Figures)
            {
                var figure  = ToJsonData(i);

                figures.Add(figure);
            }

            return data;
        }

        public static JsonData ToJsonData(StickFigure value)
        {
            var data        = new JsonData();
            var points      = new JsonData();
            data["name"]    = value.Name;
            data["label"]   = value.Label;
            data["points"]  = points;

            foreach(var i in value.Points)
            {
                var point   = ToJsonData(i);

                points[i.Name]= point;
            }

            return data;
        }

        public static JsonData ToJsonData(StickFigurePoint value)
        {
            var data        = new JsonData();
            data["name"]    = value.Name;
            data["label"]   = value.Label;
            data["x"]       = value.X;
            data["y"]       = value.Y;

            return data;
        }

        public void Save(string file)
        {
            var data    = ToJsonData(this);
            var sb      = new StringBuilder();

            JsonMapper.ToJson(data, new JsonWriter(sb) { PrettyPrint= true, IndentValue= 2 });

            File.WriteAllText(file, sb.ToString());
        }

        public void Load(string file)
        {
            Figures.Clear();

            var json    = File.ReadAllText(file);
            var data    = JsonMapper.ToObject(json);
            var settings= data["settings"];

            Width       = (int)settings["width"];
            Height      = (int)settings["height"];
            Margin      = (int)settings["margin"];
            LineWidth   = (float)(double)settings["line width"];

            foreach(JsonData i in data["figures"])
                if(FromJsonData(i, out var figure))
                    Figures.Add(figure);
        }

        private static bool FromJsonData(JsonData data, out StickFigure value)
        {
            value       = new StickFigure(Point.Empty);
            value.Name  = (string)data["name"];
            value.Label = (string)data["label"];

            var pts = data["points"];
            var p   = pts["Body"];      value.Body            .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["Face"];      value.Head.Face       .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["L Eye"];     value.Head.LeftEye    .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["R Eye"];     value.Head.RightEye   .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["L Eye End"]; value.Head.LeftEyeEnd .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["R Eye End"]; value.Head.RightEyeEnd.Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["L Leg"];     value.LeftLeg.Leg     .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["L Nee"];     value.LeftLeg.Nee     .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["L Foot"];    value.LeftLeg.Foot    .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["R Leg"];     value.RightLeg.Leg    .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["R Nee"];     value.RightLeg.Nee    .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["R Foot"];    value.RightLeg.Foot   .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["L Arm"];     value.LeftArm.Arm     .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["L Elbow"];   value.LeftArm.Elbow   .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["L Hand"];    value.LeftArm.Hand    .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["R Arm"];     value.RightArm.Arm    .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["R Elbow"];   value.RightArm.Elbow  .Set((int)p["x"], (int)p["y"], (string)p["label"]);
            p       = pts["R Hand"];    value.RightArm.Hand   .Set((int)p["x"], (int)p["y"], (string)p["label"]);

            return true;
        }
    }
}
