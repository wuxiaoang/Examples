namespace ThreadSafeCallsWinFormsControls
{
    partial class Form2
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.setTextUnsafeBtn = new System.Windows.Forms.Button();
            this.setTextBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(356, 390);
            this.textBox1.TabIndex = 0;
            // 
            // setTextUnsafeBtn
            // 
            this.setTextUnsafeBtn.Location = new System.Drawing.Point(385, 92);
            this.setTextUnsafeBtn.Name = "setTextUnsafeBtn";
            this.setTextUnsafeBtn.Size = new System.Drawing.Size(120, 35);
            this.setTextUnsafeBtn.TabIndex = 1;
            this.setTextUnsafeBtn.Text = "在窗体主线程外更新文本框";
            this.setTextUnsafeBtn.UseVisualStyleBackColor = true;
            this.setTextUnsafeBtn.Click += new System.EventHandler(this.setTextUnsafeBtn_Click);
            // 
            // setTextBtn
            // 
            this.setTextBtn.Location = new System.Drawing.Point(385, 38);
            this.setTextBtn.Name = "setTextBtn";
            this.setTextBtn.Size = new System.Drawing.Size(120, 37);
            this.setTextBtn.TabIndex = 2;
            this.setTextBtn.Text = "在窗体主线程中更新文本框";
            this.setTextBtn.UseVisualStyleBackColor = true;
            this.setTextBtn.Click += new System.EventHandler(this.setTextBtn_Click);
            // 
            // WithInvokeRequiredAndDelegate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 396);
            this.Controls.Add(this.setTextBtn);
            this.Controls.Add(this.setTextUnsafeBtn);
            this.Controls.Add(this.textBox1);
            this.Name = "WithInvokeRequiredAndDelegate";
            this.Text = "利用InvokeRequired和委托安全调用";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button setTextUnsafeBtn;
        private System.Windows.Forms.Button setTextBtn;
    }
}

