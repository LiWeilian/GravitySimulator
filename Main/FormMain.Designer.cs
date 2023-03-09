
namespace Main
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ResultField = new SkiaSharp.Views.Desktop.SKControl();
            this.SuspendLayout();
            // 
            // ResultField
            // 
            this.ResultField.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ResultField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultField.Location = new System.Drawing.Point(0, 0);
            this.ResultField.Name = "ResultField";
            this.ResultField.Size = new System.Drawing.Size(1582, 753);
            this.ResultField.TabIndex = 4;
            this.ResultField.Text = "skControl1";
            this.ResultField.PaintSurface += new System.EventHandler<SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs>(this.SKElement_PaintSurface);
            this.ResultField.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ResultField_KeyUp);
            this.ResultField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ResultField_MouseClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 753);
            this.Controls.Add(this.ResultField);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gravity   L/R - Add Sun/Planet, R - Reset, G - Display Grids, T - Display Tails";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private SkiaSharp.Views.Desktop.SKControl ResultField;
    }
}

