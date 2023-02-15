namespace StickFigureTool
{
    partial class StickFigureControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bRotation = new System.Windows.Forms.Button();
            this.nudRotation = new System.Windows.Forms.NumericUpDown();
            this.bScaling = new System.Windows.Forms.Button();
            this.nudScale = new System.Windows.Forms.NumericUpDown();
            this.bDeleteFigure = new System.Windows.Forms.Button();
            this.bCreateFigure = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nudPointRadius = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDrawEye = new System.Windows.Forms.CheckBox();
            this.cbShowLabel = new System.Windows.Forms.CheckBox();
            this.bLoadPreset = new System.Windows.Forms.Button();
            this.bSaveImage = new System.Windows.Forms.Button();
            this.cbImageName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPresetName = new System.Windows.Forms.ComboBox();
            this.bSavePreset = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbScale = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMargin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.imageDragComponent1 = new StickFigureTool.ImageDragComponent(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScale)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 640);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseCaptureChanged += new System.EventHandler(this.pictureBox1_MouseCaptureChanged);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(873, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 562);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(200, 562);
            this.splitContainer1.SplitterDistance = 337;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(200, 337);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.bRotation);
            this.panel4.Controls.Add(this.nudRotation);
            this.panel4.Controls.Add(this.bScaling);
            this.panel4.Controls.Add(this.nudScale);
            this.panel4.Controls.Add(this.bDeleteFigure);
            this.panel4.Controls.Add(this.bCreateFigure);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 221);
            this.panel4.TabIndex = 0;
            // 
            // bRotation
            // 
            this.bRotation.Location = new System.Drawing.Point(74, 61);
            this.bRotation.Name = "bRotation";
            this.bRotation.Size = new System.Drawing.Size(90, 23);
            this.bRotation.TabIndex = 5;
            this.bRotation.Text = "Rotation";
            this.bRotation.UseVisualStyleBackColor = true;
            this.bRotation.Click += new System.EventHandler(this.bRotation_Click);
            // 
            // nudRotation
            // 
            this.nudRotation.Location = new System.Drawing.Point(6, 64);
            this.nudRotation.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudRotation.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudRotation.Name = "nudRotation";
            this.nudRotation.Size = new System.Drawing.Size(62, 19);
            this.nudRotation.TabIndex = 4;
            // 
            // bScaling
            // 
            this.bScaling.Location = new System.Drawing.Point(74, 32);
            this.bScaling.Name = "bScaling";
            this.bScaling.Size = new System.Drawing.Size(90, 23);
            this.bScaling.TabIndex = 3;
            this.bScaling.Text = "Scaling";
            this.bScaling.UseVisualStyleBackColor = true;
            this.bScaling.Click += new System.EventHandler(this.bScaling_Click);
            // 
            // nudScale
            // 
            this.nudScale.DecimalPlaces = 2;
            this.nudScale.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.nudScale.Location = new System.Drawing.Point(6, 35);
            this.nudScale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudScale.Name = "nudScale";
            this.nudScale.Size = new System.Drawing.Size(62, 19);
            this.nudScale.TabIndex = 2;
            this.nudScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bDeleteFigure
            // 
            this.bDeleteFigure.Location = new System.Drawing.Point(102, 3);
            this.bDeleteFigure.Name = "bDeleteFigure";
            this.bDeleteFigure.Size = new System.Drawing.Size(90, 23);
            this.bDeleteFigure.TabIndex = 1;
            this.bDeleteFigure.Text = "Delete Figure";
            this.bDeleteFigure.UseVisualStyleBackColor = true;
            this.bDeleteFigure.Click += new System.EventHandler(this.bDeleteFigure_Click);
            // 
            // bCreateFigure
            // 
            this.bCreateFigure.Location = new System.Drawing.Point(6, 3);
            this.bCreateFigure.Name = "bCreateFigure";
            this.bCreateFigure.Size = new System.Drawing.Size(90, 23);
            this.bCreateFigure.TabIndex = 0;
            this.bCreateFigure.Text = "New Figure";
            this.bCreateFigure.UseVisualStyleBackColor = true;
            this.bCreateFigure.Click += new System.EventHandler(this.bCreateFigure_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nudPointRadius);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.nudLineWidth);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbDrawEye);
            this.panel2.Controls.Add(this.cbShowLabel);
            this.panel2.Controls.Add(this.bLoadPreset);
            this.panel2.Controls.Add(this.bSaveImage);
            this.panel2.Controls.Add(this.cbImageName);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cbPresetName);
            this.panel2.Controls.Add(this.bSavePreset);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.cbScale);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.nudMargin);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.nudHeight);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.nudWidth);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(870, 50);
            this.panel2.TabIndex = 2;
            // 
            // nudPointRadius
            // 
            this.nudPointRadius.Location = new System.Drawing.Point(501, 27);
            this.nudPointRadius.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudPointRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPointRadius.Name = "nudPointRadius";
            this.nudPointRadius.Size = new System.Drawing.Size(58, 19);
            this.nudPointRadius.TabIndex = 21;
            this.nudPointRadius.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudPointRadius.ValueChanged += new System.EventHandler(this.nudPointRadius_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(423, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "Point Radius:";
            // 
            // nudLineWidth
            // 
            this.nudLineWidth.Location = new System.Drawing.Point(359, 27);
            this.nudLineWidth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLineWidth.Name = "nudLineWidth";
            this.nudLineWidth.Size = new System.Drawing.Size(58, 19);
            this.nudLineWidth.TabIndex = 19;
            this.nudLineWidth.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudLineWidth.ValueChanged += new System.EventHandler(this.nudLineWidth_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(293, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "Line Width:";
            // 
            // cbDrawEye
            // 
            this.cbDrawEye.AutoSize = true;
            this.cbDrawEye.Checked = true;
            this.cbDrawEye.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDrawEye.Location = new System.Drawing.Point(653, 28);
            this.cbDrawEye.Name = "cbDrawEye";
            this.cbDrawEye.Size = new System.Drawing.Size(73, 16);
            this.cbDrawEye.TabIndex = 17;
            this.cbDrawEye.Text = "Draw Eye";
            this.cbDrawEye.UseVisualStyleBackColor = true;
            this.cbDrawEye.CheckedChanged += new System.EventHandler(this.cbDrawEye_CheckedChanged);
            // 
            // cbShowLabel
            // 
            this.cbShowLabel.AutoSize = true;
            this.cbShowLabel.Checked = true;
            this.cbShowLabel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowLabel.Location = new System.Drawing.Point(565, 28);
            this.cbShowLabel.Name = "cbShowLabel";
            this.cbShowLabel.Size = new System.Drawing.Size(82, 16);
            this.cbShowLabel.TabIndex = 16;
            this.cbShowLabel.Text = "Show Label";
            this.cbShowLabel.UseVisualStyleBackColor = true;
            this.cbShowLabel.CheckedChanged += new System.EventHandler(this.cbShowLabel_CheckedChanged);
            // 
            // bLoadPreset
            // 
            this.bLoadPreset.Location = new System.Drawing.Point(262, 1);
            this.bLoadPreset.Name = "bLoadPreset";
            this.bLoadPreset.Size = new System.Drawing.Size(80, 23);
            this.bLoadPreset.TabIndex = 15;
            this.bLoadPreset.Text = "Load Preset";
            this.bLoadPreset.UseVisualStyleBackColor = true;
            this.bLoadPreset.Click += new System.EventHandler(this.bLoadPreset_Click);
            // 
            // bSaveImage
            // 
            this.bSaveImage.Location = new System.Drawing.Point(549, 1);
            this.bSaveImage.Name = "bSaveImage";
            this.bSaveImage.Size = new System.Drawing.Size(80, 23);
            this.bSaveImage.TabIndex = 13;
            this.bSaveImage.Text = "Save Image:";
            this.bSaveImage.UseVisualStyleBackColor = true;
            this.bSaveImage.Click += new System.EventHandler(this.bSaveImage_Click);
            // 
            // cbImageName
            // 
            this.cbImageName.FormattingEnabled = true;
            this.cbImageName.Items.AddRange(new object[] {
            "50%",
            "66%",
            "100%",
            "125%",
            "150%",
            "200%"});
            this.cbImageName.Location = new System.Drawing.Point(422, 3);
            this.cbImageName.Name = "cbImageName";
            this.cbImageName.Size = new System.Drawing.Size(121, 20);
            this.cbImageName.TabIndex = 12;
            this.cbImageName.Text = "Default";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "Image name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Preset:";
            // 
            // cbPresetName
            // 
            this.cbPresetName.FormattingEnabled = true;
            this.cbPresetName.Items.AddRange(new object[] {
            "50%",
            "66%",
            "100%",
            "125%",
            "150%",
            "200%"});
            this.cbPresetName.Location = new System.Drawing.Point(49, 3);
            this.cbPresetName.Name = "cbPresetName";
            this.cbPresetName.Size = new System.Drawing.Size(121, 20);
            this.cbPresetName.TabIndex = 9;
            this.cbPresetName.Text = "Default";
            // 
            // bSavePreset
            // 
            this.bSavePreset.Location = new System.Drawing.Point(176, 1);
            this.bSavePreset.Name = "bSavePreset";
            this.bSavePreset.Size = new System.Drawing.Size(80, 23);
            this.bSavePreset.TabIndex = 8;
            this.bSavePreset.Text = "Save Preset";
            this.bSavePreset.UseVisualStyleBackColor = true;
            this.bSavePreset.Click += new System.EventHandler(this.bSavePreset_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(635, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Copy to Clipboard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbScale
            // 
            this.cbScale.FormattingEnabled = true;
            this.cbScale.Items.AddRange(new object[] {
            "50%",
            "66%",
            "100%",
            "125%",
            "150%",
            "200%"});
            this.cbScale.Location = new System.Drawing.Point(802, 25);
            this.cbScale.Name = "cbScale";
            this.cbScale.Size = new System.Drawing.Size(48, 20);
            this.cbScale.TabIndex = 7;
            this.cbScale.Text = "100%";
            this.cbScale.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(761, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Scale:";
            this.label4.Visible = false;
            // 
            // nudMargin
            // 
            this.nudMargin.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudMargin.Location = new System.Drawing.Point(229, 27);
            this.nudMargin.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudMargin.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudMargin.Name = "nudMargin";
            this.nudMargin.Size = new System.Drawing.Size(58, 19);
            this.nudMargin.TabIndex = 5;
            this.nudMargin.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nudMargin.ValueChanged += new System.EventHandler(this.nudMargin_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Margin:";
            // 
            // nudHeight
            // 
            this.nudHeight.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudHeight.Location = new System.Drawing.Point(118, 27);
            this.nudHeight.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(58, 19);
            this.nudHeight.TabIndex = 3;
            this.nudHeight.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nudHeight.ValueChanged += new System.EventHandler(this.nudHeight_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "x";
            // 
            // nudWidth
            // 
            this.nudWidth.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudWidth.Location = new System.Drawing.Point(37, 27);
            this.nudWidth.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(58, 19);
            this.nudWidth.TabIndex = 1;
            this.nudWidth.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nudWidth.ValueChanged += new System.EventHandler(this.nudWidth_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Size:";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(870, 512);
            this.panel3.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(870, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 562);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // imageDragComponent1
            // 
            this.imageDragComponent1.Control = this.pictureBox1;
            this.imageDragComponent1.Enabled = true;
            this.imageDragComponent1.BeginDrag += new System.EventHandler<StickFigureTool.DragObjectEventArgs>(this.imageDragComponent1_BeginDrag);
            // 
            // StickFigureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "StickFigureControl";
            this.Size = new System.Drawing.Size(1073, 562);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScale)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.NumericUpDown nudMargin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbScale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bSaveImage;
        private System.Windows.Forms.ComboBox cbImageName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbPresetName;
        private System.Windows.Forms.Button bSavePreset;
        private System.Windows.Forms.Button button1;
        private ImageDragComponent imageDragComponent1;
        private System.Windows.Forms.Button bLoadPreset;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.CheckBox cbDrawEye;
        private System.Windows.Forms.CheckBox cbShowLabel;
        private System.Windows.Forms.NumericUpDown nudLineWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button bRotation;
        private System.Windows.Forms.NumericUpDown nudRotation;
        private System.Windows.Forms.Button bScaling;
        private System.Windows.Forms.NumericUpDown nudScale;
        private System.Windows.Forms.Button bDeleteFigure;
        private System.Windows.Forms.Button bCreateFigure;
        private System.Windows.Forms.NumericUpDown nudPointRadius;
        private System.Windows.Forms.Label label8;
    }
}
