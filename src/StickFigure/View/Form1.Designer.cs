namespace StickFigureTool
{
    partial class Form1
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.stickFigureControl1 = new StickFigureTool.StickFigureControl();
            this.SuspendLayout();
            // 
            // stickFigureControl1
            // 
            this.stickFigureControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stickFigureControl1.Location = new System.Drawing.Point(0, 0);
            this.stickFigureControl1.Name = "stickFigureControl1";
            this.stickFigureControl1.Size = new System.Drawing.Size(1264, 761);
            this.stickFigureControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.stickFigureControl1);
            this.Name = "Form1";
            this.Text = "StickFigure";
            this.ResumeLayout(false);

        }

        #endregion

        private StickFigureControl stickFigureControl1;
    }
}

