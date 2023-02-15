using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickFigureTool
{
    public partial class StickFigureControl : UserControl
    {
        public StickFigureScene         Scene                   { get; private set; }
        public StickFigureRenderer      Renderer                { get; private set; }
        public bool                     Dragging                { get; private set; }
        public StickFigurePoint         DragPoint               { get; private set; }
        public Point                    OldLocation             { get; private set; }
        public Point                    DownLocation            { get; private set; }
        public Point                    LastLocation            { get; private set; }
        public bool                     MoveChilren             { get; private set; }
        public string                   AssemblyDirectory       => Path.GetDirectoryName(GetType().Assembly.Location);
        public string                   PresetsDirectory        => Path.Combine(AssemblyDirectory, "presets");
        public string                   ImagesDirectory         => Path.Combine(AssemblyDirectory, "images");

        public StickFigureControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Scene       = new StickFigureScene();
            var figure  = Scene.CreateFigure(256, 160);
            figure.Name = "Figure 1";
            figure.Label= "Figure 1";
            Renderer    = new StickFigureRenderer();

            LoadPreset();

            if(Directory.Exists(PresetsDirectory))
            {
                cbPresetName.Items.Clear();

                foreach(var i in Directory.GetFiles(PresetsDirectory, "*.json"))
                {
                    var name= Path.GetFileNameWithoutExtension(i);

                    cbPresetName.Items.Add(name);
                }
            }

            UpdateTree();
        }

        private void UpdateTree()
        {
            treeView1.BeginUpdate();

            try
            {
                treeView1.Nodes.Clear();

                if(null == Scene)
                    return;

                foreach(var i in Scene.Figures)
                    BuildTree(treeView1.Nodes, i);
            } finally
            {
                treeView1.EndUpdate();
            }

            treeView1.ExpandAll();
        }

        private TreeNode BuildTree(TreeNodeCollection nodes, StickFigure value)
        {
            var node    = nodes.Add(value.Label);
            node.Tag    = value;

            foreach(var i in value.Points)
                BuildTree(node.Nodes, i);

            return node;
        }

        private TreeNode BuildTree(TreeNodeCollection nodes, StickFigurePoint value)
        {
            var node    = nodes.Add(value.Label);
            node.Tag    = value;
            node.Checked= value.VisiblePoint;

            return node;
        }

        private Point PointToLogical(Point point)
        {
            var m   = (int)nudMargin.Value;

            return new Point(point.X - m, point.Y - m);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left
            || e.Button == MouseButtons.Middle)
            {
                var p   = PointToLogical(e.Location);
                var hti = Scene.HitTest(p.X, p.Y);

                if(hti.Distance < 8)
                {
                    Dragging    = true;
                  //MoveChilren = e.Button == MouseButtons.Middle;
                    MoveChilren = e.Button == MouseButtons.Left;
                    DragPoint   = hti.Point;
                    DownLocation= p;
                    LastLocation= p;
                    OldLocation = DragPoint.Location;
                    pictureBox1.Capture = true;
                    imageDragComponent1.Enabled= false;

                    SetSelectFigurePoint(DragPoint);
                }
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(Dragging)
            {
                if(null == DragPoint)
                    return;

                var p       = PointToLogical(e.Location);
                var dx      = p.X - LastLocation.X;
                var dy      = p.Y - LastLocation.Y;
                LastLocation= p;

                DragPoint.Set(DragPoint.X + dx, DragPoint.Y + dy);

                if(MoveChilren)
                    foreach(var i in DragPoint.Children.SelectRecursive(i => i.Children))
                        i.Set(i.X + dx, i.Y + dy);

                Repaint();
            }
        }

        private void EndDrag()
        {
            pictureBox1.Capture = false;
            Dragging            = false;        
            DragPoint           = null;
            imageDragComponent1.Enabled= true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(Dragging && e.Button == MouseButtons.Left)
            {
                EndDrag();
            }
        }

        private void pictureBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            if(!pictureBox1.Capture)
                EndDrag();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(null != Scene)
            {
                var m               = (int)nudMargin.Value;
                var w               = (int)nudWidth.Value;
                var h               = (int)nudHeight.Value;
                e.Graphics.Transform= new System.Drawing.Drawing2D.Matrix(1, 0, 0, 1, m, m);

                e.Graphics.DrawRectangle(new Pen(Color.Gray), 0, 0, w, h);
                Renderer?.Render(pictureBox1, e.Graphics, Scene);
            }
        }

        private Image CreateImage()
        {
            var w   = (int)nudWidth .Value;
            var h   = (int)nudHeight.Value;
            var img = new Bitmap(w, h, PixelFormat.Format24bppRgb);

            using(var g= Graphics.FromImage(img))
            {
                g.Clear(Color.Black);

                Renderer.ShowEye        = cbDrawEye.Checked;
                Renderer.ShowPoints     = false;
                Renderer.ShowFigureLabel=
                Renderer.ShowEndLabel   = false;

                Renderer.Render(pictureBox1, g, Scene);

                Renderer.ShowPoints     =
                Renderer.ShowEye        = true;
                Renderer.ShowFigureLabel=
                Renderer.ShowEndLabel   = cbShowLabel.Checked;
            }

            return img;
        }

        private void imageDragComponent1_BeginDrag(object sender, DragObjectEventArgs e)
        {
            var imgfile = SaveImage();

            e.DataObject= new DataObject(DataFormats.FileDrop, new [] { imgfile });
        }

        public int CalcWidth()
        {
            int w   = (int)nudWidth.Value;
            var m   = (int)nudMargin.Value;

            return w + m * 2;
        }

        public int CalcHeight()
        {
            int h   = (int)nudHeight.Value;
            var m   = (int)nudMargin.Value;

            return h + m * 2;
        }

        public void Repaint()
        {
            pictureBox1.Invalidate();
        }

        private void nudWidth_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Width   = CalcWidth();
            Scene.Width         = (int)nudWidth.Value;
            Repaint();
        }

        private void nudHeight_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Height  = CalcHeight();
            Scene.Height        = (int)nudWidth.Value;
            Repaint();
        }

        private void nudMargin_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Width   = CalcWidth();
            pictureBox1.Height  = CalcHeight();
            Scene.Margin        = (int)nudMargin.Value;
            Repaint();
        }

        private void nudLineWidth_ValueChanged(object sender, EventArgs e)
        {
            Renderer.SegmentWidth= (int)nudLineWidth.Value;
            Scene.LineWidth     = (int)nudLineWidth.Value;
            Repaint();
        }

        private void cbShowLabel_CheckedChanged(object sender, EventArgs e)
        {
            Renderer.ShowFigureLabel=
            Renderer.ShowEndLabel   = cbShowLabel.Checked;
            Repaint();
        }

        private void cbDrawEye_CheckedChanged(object sender, EventArgs e)
        {
        }

        private string GetUnusedName()
        {
            for(int i= 1; i < 1000; ++i)
            {
                var name= $"Figure {i}";

                if(!Scene.Figures.Any(j => j.Name == name))
                    return name;
            }

            return "Figure";
        }

        private void bCreateFigure_Click(object sender, EventArgs e)
        {
            var figure  = new StickFigure(new Point(100, 120));
            var node    = default(TreeNode);

            Scene.Figures.Add(figure);
            treeView1.BeginUpdate();

            try
            {
                var name    = GetUnusedName();
                figure.Name = name;
                figure.Label= name;
                node        = BuildTree(treeView1.Nodes, figure);
            } finally
            {
                treeView1.EndUpdate();
            }

            node?.Expand();
            Repaint();
        }

        private void SetSelectFigurePoint(StickFigurePoint p)
        {
            foreach(TreeNode i in treeView1.Nodes)
            {
                foreach(TreeNode j in i.Nodes)
                {
                    if(p == j.Tag)
                    {
                        treeView1.SelectedNode  = j;
                        break;
                    }
                }
            }
        }

        private void bDeleteFigure_Click(object sender, EventArgs e)
        {
            var node= treeView1.SelectedNode;

            switch(node?.Tag)
            {
            case StickFigurePoint p:
                Scene.Figures.Remove(node.Parent.Tag as StickFigure);

                node.Parent.Remove();
                break;

            case StickFigure f:
                Scene.Figures.Remove(f);

                node.Remove();
                break;
            }

            bDeleteFigure.Enabled   = false;

            Repaint();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bDeleteFigure.Enabled= e.Node != null;
        }

        private void bScaling_Click(object sender, EventArgs e)
        {
            var node= treeView1.SelectedNode;

            if(null == node)
                return;

            var figure  = node.Tag as StickFigure ?? node.Parent.Tag as StickFigure;
            var p       = figure.Body.Location;
            var scale   = (float)nudScale.Value;

            foreach(var i in figure.Points)
            {
                var dx  = i.X - p.X;
                var dy  = i.Y - p.Y;

                i.Set((int)(p.X + dx * scale), (int)(p.Y + dy * scale));
            }

            Repaint();
        }

        private void bRotation_Click(object sender, EventArgs e)
        {
            var node= treeView1.SelectedNode;

            if(null == node)
                return;

            var figure  = node.Tag as StickFigure ?? node.Parent.Tag as StickFigure;
            var p       = figure.Body.Location;
            var scale   = (float)nudScale.Value;
            var r       = (double)nudRotation.Value;
          //r           = r * Math.PI / 180;
            var points  = figure.Points.Select(i => new Point(i.X - p.X, i.Y - p.Y)).ToArray();
            var mat     = new System.Drawing.Drawing2D.Matrix();

            mat.Rotate((float)r);
            mat.TransformPoints(points);

            foreach(var (point, location) in figure.Points.Zip(points, Tuple.Create))
                point.Set(p.X + location.X, p.Y + location.Y);

            Repaint();
        }

        private void bSaveImage_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private string SaveImage()
        {
            var dir = Path.GetDirectoryName(GetType().Assembly.Location);
            dir     = Path.Combine(dir, "images");

            if(!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var name= cbImageName.Text;
            var file= Path.Combine(dir, $"{name}.png");

            using(var s= File.OpenWrite(file))
                using(var img = CreateImage())
                    img.Save(s, ImageFormat.Png);

            return file;
        }

        private void bSavePreset_Click(object sender, EventArgs e)
        {
            SavePreset();
        }

        private void SavePreset()
        {
            try
            {
                var dir = Path.GetDirectoryName(GetType().Assembly.Location);
                dir     = Path.Combine(dir, "presets");

                if(!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                var name= cbPresetName.Text;
                var file= Path.Combine(dir, $"{name}.json");
            
                Scene.Save(file);

                var idx = cbPresetName.Items.IndexOf(name);

                if(idx >= 0)
                    cbPresetName.Items.RemoveAt(idx);

                cbPresetName.Items.Insert(0, name);

                cbPresetName.Text   = name;
            } catch { }
        }

        private void bLoadPreset_Click(object sender, EventArgs e)
        {
            LoadPreset();
        }

        private void LoadPreset()
        {
            try
            {
                var dir = Path.GetDirectoryName(GetType().Assembly.Location);
                dir     = Path.Combine(dir, "presets");
                var name= cbPresetName.Text;
                var file= Path.Combine(dir, $"{name}.json");

                if(File.Exists(file))
                {
                    Scene.Load(file);

                    nudWidth.Value      = Scene.Width;
                    nudHeight.Value     = Scene.Height;
                    nudMargin.Value     = Scene.Margin;
                    nudLineWidth.Value  = (decimal)Scene.LineWidth;

                    Repaint();
                }

                UpdateTree();
            } catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetImage(CreateImage());
            } catch { }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Node?.Tag is StickFigurePoint p)
                p.VisiblePoint  = e.Node.Checked;

            Repaint();
        }

        private void nudPointRadius_ValueChanged(object sender, EventArgs e)
        {
            Renderer.PointRadius    = (float)nudPointRadius.Value;

            Repaint();
        }
    }

    public static class Extention
    {
        public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> self, Func<T, IEnumerable<T>> func)
        {
            foreach(var i in self)
            {
                yield return i;

                foreach(var j in func(i).SelectRecursive(func))
                    yield return j;
            }
        }
    }
}
