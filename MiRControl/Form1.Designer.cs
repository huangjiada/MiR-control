namespace MiRControl
{
    partial class Form1
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
            this.btn_call = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_call
            // 
            this.btn_call.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_call.Location = new System.Drawing.Point(6, 3);
            this.btn_call.Name = "btn_call";
            this.btn_call.Size = new System.Drawing.Size(164, 74);
            this.btn_call.TabIndex = 0;
            this.btn_call.Text = "Call Car";
            this.btn_call.UseVisualStyleBackColor = true;
            this.btn_call.Click += new System.EventHandler(this.btn_call_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(175, 81);
            this.Controls.Add(this.btn_call);
            this.Name = "Form1";
            this.Text = "Mir call";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_call;
    }
}

