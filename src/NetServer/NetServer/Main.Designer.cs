namespace NetServer
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.lst_Error = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// lst_Error
			// 
			this.lst_Error.FormattingEnabled = true;
			this.lst_Error.ItemHeight = 12;
			this.lst_Error.Location = new System.Drawing.Point(12, 237);
			this.lst_Error.Name = "lst_Error";
			this.lst_Error.Size = new System.Drawing.Size(611, 124);
			this.lst_Error.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(402, 42);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 44);
			this.button1.TabIndex = 2;
			this.button1.Text = "Listen";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(421, 126);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(12, 12);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(359, 208);
			this.richTextBox1.TabIndex = 4;
			this.richTextBox1.Text = "";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(638, 373);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lst_Error);
			this.Name = "Main";
			this.Text = "Main";
			this.Load += new System.EventHandler(this.Main_Load);
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.ListBox lst_Error;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

