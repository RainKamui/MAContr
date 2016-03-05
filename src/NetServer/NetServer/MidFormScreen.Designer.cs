namespace NetServer {
	partial class MidFormScreen {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MidFormScreen));
			this.tsp_Main = new System.Windows.Forms.ToolStrip();
			this.tsb_StartScreen = new System.Windows.Forms.ToolStripButton();
			this.tsb_FullScreen = new System.Windows.Forms.ToolStripButton();
			this.tsb_SendMouseMove = new System.Windows.Forms.ToolStripButton();
			this.tsb_SendMouseClick = new System.Windows.Forms.ToolStripButton();
			this.tsb_Scale = new System.Windows.Forms.ToolStripButton();
			this.pic_Screen = new System.Windows.Forms.PictureBox();
			this.tsp_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic_Screen)).BeginInit();
			this.SuspendLayout();
			// 
			// tsp_Main
			// 
			this.tsp_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_StartScreen,
            this.tsb_FullScreen,
            this.tsb_SendMouseMove,
            this.tsb_SendMouseClick,
            this.tsb_Scale});
			this.tsp_Main.Location = new System.Drawing.Point(0, 0);
			this.tsp_Main.Name = "tsp_Main";
			this.tsp_Main.Size = new System.Drawing.Size(468, 25);
			this.tsp_Main.TabIndex = 0;
			this.tsp_Main.Text = "toolStrip1";
			// 
			// tsb_StartScreen
			// 
			this.tsb_StartScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsb_StartScreen.Image = ((System.Drawing.Image)(resources.GetObject("tsb_StartScreen.Image")));
			this.tsb_StartScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_StartScreen.Name = "tsb_StartScreen";
			this.tsb_StartScreen.Size = new System.Drawing.Size(23, 22);
			this.tsb_StartScreen.Text = "toolStripButton1";
			// 
			// tsb_FullScreen
			// 
			this.tsb_FullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsb_FullScreen.Image = ((System.Drawing.Image)(resources.GetObject("tsb_FullScreen.Image")));
			this.tsb_FullScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_FullScreen.Name = "tsb_FullScreen";
			this.tsb_FullScreen.Size = new System.Drawing.Size(23, 22);
			this.tsb_FullScreen.Text = "toolStripButton1";
			// 
			// tsb_SendMouseMove
			// 
			this.tsb_SendMouseMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsb_SendMouseMove.Image = ((System.Drawing.Image)(resources.GetObject("tsb_SendMouseMove.Image")));
			this.tsb_SendMouseMove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_SendMouseMove.Name = "tsb_SendMouseMove";
			this.tsb_SendMouseMove.Size = new System.Drawing.Size(23, 22);
			this.tsb_SendMouseMove.Text = "toolStripButton1";
			// 
			// tsb_SendMouseClick
			// 
			this.tsb_SendMouseClick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsb_SendMouseClick.Image = ((System.Drawing.Image)(resources.GetObject("tsb_SendMouseClick.Image")));
			this.tsb_SendMouseClick.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_SendMouseClick.Name = "tsb_SendMouseClick";
			this.tsb_SendMouseClick.Size = new System.Drawing.Size(23, 22);
			this.tsb_SendMouseClick.Text = "toolStripButton1";
			// 
			// tsb_Scale
			// 
			this.tsb_Scale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsb_Scale.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Scale.Image")));
			this.tsb_Scale.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_Scale.Name = "tsb_Scale";
			this.tsb_Scale.Size = new System.Drawing.Size(23, 22);
			this.tsb_Scale.Text = "toolStripButton1";
			this.tsb_Scale.Click += new System.EventHandler(this.tsb_Scale_Click);
			// 
			// pic_Screen
			// 
			this.pic_Screen.BackColor = System.Drawing.Color.Black;
			this.pic_Screen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pic_Screen.Location = new System.Drawing.Point(0, 25);
			this.pic_Screen.Name = "pic_Screen";
			this.pic_Screen.Size = new System.Drawing.Size(468, 273);
			this.pic_Screen.TabIndex = 1;
			this.pic_Screen.TabStop = false;
			this.pic_Screen.Click += new System.EventHandler(this.pic_Screen_Click);
			// 
			// MidFormScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(468, 298);
			this.Controls.Add(this.pic_Screen);
			this.Controls.Add(this.tsp_Main);
			this.Name = "MidFormScreen";
			this.Text = "MidForm_Screen";
			this.Load += new System.EventHandler(this.MidFormScreen_Load);
			this.tsp_Main.ResumeLayout(false);
			this.tsp_Main.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic_Screen)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tsp_Main;
		private System.Windows.Forms.PictureBox pic_Screen;
		private System.Windows.Forms.ToolStripButton tsb_FullScreen;
		private System.Windows.Forms.ToolStripButton tsb_StartScreen;
		private System.Windows.Forms.ToolStripButton tsb_SendMouseMove;
		private System.Windows.Forms.ToolStripButton tsb_SendMouseClick;
		private System.Windows.Forms.ToolStripButton tsb_Scale;
	}
}