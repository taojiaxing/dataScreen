namespace dataScreen
{
    partial class form1
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
            this.display = new System.Windows.Forms.PictureBox();
            this.read = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.titleFont = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(12, 12);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(800, 400);
            this.display.TabIndex = 0;
            this.display.TabStop = false;
            this.display.Click += new System.EventHandler(this.display_Click);
            // 
            // read
            // 
            this.read.Location = new System.Drawing.Point(1155, 11);
            this.read.Name = "read";
            this.read.Size = new System.Drawing.Size(75, 23);
            this.read.TabIndex = 2;
            this.read.Text = "read";
            this.read.UseVisualStyleBackColor = true;
            this.read.Click += new System.EventHandler(this.read_Click);
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(1074, 11);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 3;
            this.open.Text = "open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(836, 12);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(232, 21);
            this.textBox_path.TabIndex = 4;
            this.textBox_path.TextChanged += new System.EventHandler(this.textBox_path_TextChanged);
            // 
            // titleFont
            // 
            this.titleFont.Location = new System.Drawing.Point(836, 70);
            this.titleFont.Name = "titleFont";
            this.titleFont.Size = new System.Drawing.Size(75, 23);
            this.titleFont.TabIndex = 5;
            this.titleFont.Text = "titleFont";
            this.titleFont.UseVisualStyleBackColor = true;
            this.titleFont.Click += new System.EventHandler(this.titleFont_Click);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 432);
            this.Controls.Add(this.titleFont);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.open);
            this.Controls.Add(this.read);
            this.Controls.Add(this.display);
            this.Name = "form1";
            this.Text = "测试";
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox display;
        private System.Windows.Forms.Button read;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button titleFont;
    }
}

