namespace ImageView
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
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
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
			this.components = new System.ComponentModel.Container();
			this.CntMenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.CcntMenuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.CntMenuReset = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuMirror = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuFlip = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuZoom = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuZoom025p = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuZoom050p = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuZoom075p = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuZoom100p = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuZoom150p = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuZoom200p = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuZoom400p = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuZoom600p = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuZoom800p = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuAngle = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuAngle0d = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuAngle90d = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuAngle180d = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuAngle270d = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.CntMenuOptShowGrip = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuOptNoBorder = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuOptFitImage = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuOptShowDebug = new System.Windows.Forms.ToolStripMenuItem();
			this.CntMenuMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// CntMenuMain
			// 
			this.CntMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CcntMenuClose,
            this.toolStripSeparator1,
            this.CntMenuReset,
            this.CntMenuMirror,
            this.CntMenuFlip,
            this.CntMenuZoom,
            this.CntMenuAngle,
            this.toolStripSeparator2,
            this.CntMenuOptShowGrip,
            this.CntMenuOptNoBorder,
            this.CntMenuOptFitImage,
            this.CntMenuOptShowDebug});
			this.CntMenuMain.Name = "cntMenu";
			this.CntMenuMain.Size = new System.Drawing.Size(169, 236);
			// 
			// CcntMenuClose
			// 
			this.CcntMenuClose.Name = "CcntMenuClose";
			this.CcntMenuClose.Size = new System.Drawing.Size(168, 22);
			this.CcntMenuClose.Text = "Close (&C)";
			this.CcntMenuClose.Click += new System.EventHandler(this.CntMenuClose_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
			// 
			// CntMenuReset
			// 
			this.CntMenuReset.Name = "CntMenuReset";
			this.CntMenuReset.Size = new System.Drawing.Size(168, 22);
			this.CntMenuReset.Text = "Reset(&R)";
			this.CntMenuReset.Click += new System.EventHandler(this.CntMenuReset_Click);
			// 
			// CntMenuMirror
			// 
			this.CntMenuMirror.Checked = true;
			this.CntMenuMirror.CheckOnClick = true;
			this.CntMenuMirror.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CntMenuMirror.Name = "CntMenuMirror";
			this.CntMenuMirror.Size = new System.Drawing.Size(168, 22);
			this.CntMenuMirror.Text = "Mirror(&M)";
			this.CntMenuMirror.Click += new System.EventHandler(this.CntMenuMirror_Click);
			// 
			// CntMenuFlip
			// 
			this.CntMenuFlip.Checked = true;
			this.CntMenuFlip.CheckOnClick = true;
			this.CntMenuFlip.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CntMenuFlip.Name = "CntMenuFlip";
			this.CntMenuFlip.Size = new System.Drawing.Size(168, 22);
			this.CntMenuFlip.Text = "Flip(&F)";
			this.CntMenuFlip.Click += new System.EventHandler(this.CntMenuFlip_Click);
			// 
			// CntMenuZoom
			// 
			this.CntMenuZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CntMenuZoom025p,
            this.CntMenuZoom050p,
            this.CntMenuZoom075p,
            this.CntMenuZoom100p,
            this.CntMenuZoom150p,
            this.CntMenuZoom200p,
            this.CntMenuZoom400p,
            this.CntMenuZoom600p,
            this.CntMenuZoom800p});
			this.CntMenuZoom.Name = "CntMenuZoom";
			this.CntMenuZoom.Size = new System.Drawing.Size(168, 22);
			this.CntMenuZoom.Text = "Zoom(&Z)";
			// 
			// CntMenuZoom025p
			// 
			this.CntMenuZoom025p.Name = "CntMenuZoom025p";
			this.CntMenuZoom025p.Size = new System.Drawing.Size(102, 22);
			this.CntMenuZoom025p.Text = "25%";
			this.CntMenuZoom025p.Click += new System.EventHandler(this.CntMenuZoomPer_Click);
			// 
			// CntMenuZoom050p
			// 
			this.CntMenuZoom050p.Name = "CntMenuZoom050p";
			this.CntMenuZoom050p.Size = new System.Drawing.Size(102, 22);
			this.CntMenuZoom050p.Text = "50%";
			this.CntMenuZoom050p.Click += new System.EventHandler(this.CntMenuZoomPer_Click);
			// 
			// CntMenuZoom075p
			// 
			this.CntMenuZoom075p.Name = "CntMenuZoom075p";
			this.CntMenuZoom075p.Size = new System.Drawing.Size(102, 22);
			this.CntMenuZoom075p.Text = "75%";
			this.CntMenuZoom075p.Click += new System.EventHandler(this.CntMenuZoomPer_Click);
			// 
			// CntMenuZoom100p
			// 
			this.CntMenuZoom100p.Name = "CntMenuZoom100p";
			this.CntMenuZoom100p.Size = new System.Drawing.Size(102, 22);
			this.CntMenuZoom100p.Text = "100%";
			this.CntMenuZoom100p.Click += new System.EventHandler(this.CntMenuZoomPer_Click);
			// 
			// CntMenuZoom150p
			// 
			this.CntMenuZoom150p.Name = "CntMenuZoom150p";
			this.CntMenuZoom150p.Size = new System.Drawing.Size(102, 22);
			this.CntMenuZoom150p.Text = "150%";
			this.CntMenuZoom150p.Click += new System.EventHandler(this.CntMenuZoomPer_Click);
			// 
			// CntMenuZoom200p
			// 
			this.CntMenuZoom200p.Name = "CntMenuZoom200p";
			this.CntMenuZoom200p.Size = new System.Drawing.Size(102, 22);
			this.CntMenuZoom200p.Text = "200%";
			this.CntMenuZoom200p.Click += new System.EventHandler(this.CntMenuZoomPer_Click);
			// 
			// CntMenuZoom400p
			// 
			this.CntMenuZoom400p.Name = "CntMenuZoom400p";
			this.CntMenuZoom400p.Size = new System.Drawing.Size(102, 22);
			this.CntMenuZoom400p.Text = "400%";
			this.CntMenuZoom400p.Click += new System.EventHandler(this.CntMenuZoomPer_Click);
			// 
			// CntMenuZoom600p
			// 
			this.CntMenuZoom600p.Name = "CntMenuZoom600p";
			this.CntMenuZoom600p.Size = new System.Drawing.Size(102, 22);
			this.CntMenuZoom600p.Text = "600%";
			this.CntMenuZoom600p.Click += new System.EventHandler(this.CntMenuZoomPer_Click);
			// 
			// CntMenuZoom800p
			// 
			this.CntMenuZoom800p.Name = "CntMenuZoom800p";
			this.CntMenuZoom800p.Size = new System.Drawing.Size(102, 22);
			this.CntMenuZoom800p.Text = "800%";
			this.CntMenuZoom800p.Click += new System.EventHandler(this.CntMenuZoomPer_Click);
			// 
			// CntMenuAngle
			// 
			this.CntMenuAngle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CntMenuAngle0d,
            this.CntMenuAngle90d,
            this.CntMenuAngle180d,
            this.CntMenuAngle270d});
			this.CntMenuAngle.Name = "CntMenuAngle";
			this.CntMenuAngle.Size = new System.Drawing.Size(168, 22);
			this.CntMenuAngle.Text = "Angle(&A)";
			// 
			// CntMenuAngle0d
			// 
			this.CntMenuAngle0d.Name = "CntMenuAngle0d";
			this.CntMenuAngle0d.Size = new System.Drawing.Size(115, 22);
			this.CntMenuAngle0d.Text = "0 deg";
			this.CntMenuAngle0d.Click += new System.EventHandler(this.CntMenuAngle_Click);
			// 
			// CntMenuAngle90d
			// 
			this.CntMenuAngle90d.Name = "CntMenuAngle90d";
			this.CntMenuAngle90d.Size = new System.Drawing.Size(115, 22);
			this.CntMenuAngle90d.Text = "90 deg";
			this.CntMenuAngle90d.Click += new System.EventHandler(this.CntMenuAngle_Click);
			// 
			// CntMenuAngle180d
			// 
			this.CntMenuAngle180d.Name = "CntMenuAngle180d";
			this.CntMenuAngle180d.Size = new System.Drawing.Size(115, 22);
			this.CntMenuAngle180d.Text = "180 deg";
			this.CntMenuAngle180d.Click += new System.EventHandler(this.CntMenuAngle_Click);
			// 
			// CntMenuAngle270d
			// 
			this.CntMenuAngle270d.Name = "CntMenuAngle270d";
			this.CntMenuAngle270d.Size = new System.Drawing.Size(115, 22);
			this.CntMenuAngle270d.Text = "270 deg";
			this.CntMenuAngle270d.Click += new System.EventHandler(this.CntMenuAngle_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
			// 
			// CntMenuOptShowGrip
			// 
			this.CntMenuOptShowGrip.Checked = true;
			this.CntMenuOptShowGrip.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CntMenuOptShowGrip.Name = "CntMenuOptShowGrip";
			this.CntMenuOptShowGrip.Size = new System.Drawing.Size(168, 22);
			this.CntMenuOptShowGrip.Text = "Show GripArea(&G)";
			this.CntMenuOptShowGrip.Click += new System.EventHandler(this.CntMenuOptShowGrip_Click);
			// 
			// CntMenuOptNoBorder
			// 
			this.CntMenuOptNoBorder.Checked = true;
			this.CntMenuOptNoBorder.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CntMenuOptNoBorder.Name = "CntMenuOptNoBorder";
			this.CntMenuOptNoBorder.Size = new System.Drawing.Size(168, 22);
			this.CntMenuOptNoBorder.Text = "No Border(&N)";
			this.CntMenuOptNoBorder.Click += new System.EventHandler(this.CntMenuOptNoBorder_Click);
			// 
			// CntMenuOptFitImage
			// 
			this.CntMenuOptFitImage.Checked = true;
			this.CntMenuOptFitImage.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CntMenuOptFitImage.Name = "CntMenuOptFitImage";
			this.CntMenuOptFitImage.Size = new System.Drawing.Size(168, 22);
			this.CntMenuOptFitImage.Text = "Fit Image(&F)";
			this.CntMenuOptFitImage.Click += new System.EventHandler(this.CntMenuOptFitImage_Click);
			// 
			// CntMenuOptShowDebug
			// 
			this.CntMenuOptShowDebug.Name = "CntMenuOptShowDebug";
			this.CntMenuOptShowDebug.Size = new System.Drawing.Size(168, 22);
			this.CntMenuOptShowDebug.Text = "Show Debug(&D)";
			this.CntMenuOptShowDebug.Click += new System.EventHandler(this.CntMenuOptShowDebug_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(256, 256);
			this.ContextMenuStrip = this.CntMenuMain;
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
			this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
			this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseWheel);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.CntMenuMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ContextMenuStrip CntMenuMain;
		private System.Windows.Forms.ToolStripMenuItem CcntMenuClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem CntMenuMirror;
		private System.Windows.Forms.ToolStripMenuItem CntMenuFlip;
		private System.Windows.Forms.ToolStripMenuItem CntMenuReset;
		private System.Windows.Forms.ToolStripMenuItem CntMenuZoom;
		private System.Windows.Forms.ToolStripMenuItem CntMenuZoom025p;
		private System.Windows.Forms.ToolStripMenuItem CntMenuZoom050p;
		private System.Windows.Forms.ToolStripMenuItem CntMenuZoom075p;
		private System.Windows.Forms.ToolStripMenuItem CntMenuZoom100p;
		private System.Windows.Forms.ToolStripMenuItem CntMenuZoom150p;
		private System.Windows.Forms.ToolStripMenuItem CntMenuZoom200p;
		private System.Windows.Forms.ToolStripMenuItem CntMenuZoom400p;
		private System.Windows.Forms.ToolStripMenuItem CntMenuZoom600p;
		private System.Windows.Forms.ToolStripMenuItem CntMenuZoom800p;
		private System.Windows.Forms.ToolStripMenuItem CntMenuAngle;
		private System.Windows.Forms.ToolStripMenuItem CntMenuAngle0d;
		private System.Windows.Forms.ToolStripMenuItem CntMenuAngle90d;
		private System.Windows.Forms.ToolStripMenuItem CntMenuAngle180d;
		private System.Windows.Forms.ToolStripMenuItem CntMenuAngle270d;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem CntMenuOptShowGrip;
		private System.Windows.Forms.ToolStripMenuItem CntMenuOptNoBorder;
		private System.Windows.Forms.ToolStripMenuItem CntMenuOptFitImage;
		private System.Windows.Forms.ToolStripMenuItem CntMenuOptShowDebug;
	}
}

