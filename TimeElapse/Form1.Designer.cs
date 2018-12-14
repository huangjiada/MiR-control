namespace TimeElapse
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
            this.components = new System.ComponentModel.Container();
            this.StartButton = new System.Windows.Forms.Button();
            this.TimeLab = new System.Windows.Forms.Label();
            this.HourTextBox = new System.Windows.Forms.TextBox();
            this.MinuteTextBox = new System.Windows.Forms.TextBox();
            this.SecondTextBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Resetbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 197);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(121, 27);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // TimeLab
            // 
            this.TimeLab.AutoSize = true;
            this.TimeLab.Location = new System.Drawing.Point(41, 151);
            this.TimeLab.Name = "TimeLab";
            this.TimeLab.Size = new System.Drawing.Size(29, 12);
            this.TimeLab.TabIndex = 1;
            this.TimeLab.Text = "time";
            // 
            // HourTextBox
            // 
            this.HourTextBox.Location = new System.Drawing.Point(19, 61);
            this.HourTextBox.Name = "HourTextBox";
            this.HourTextBox.Size = new System.Drawing.Size(67, 21);
            this.HourTextBox.TabIndex = 2;
            this.HourTextBox.Text = "00";
            // 
            // MinuteTextBox
            // 
            this.MinuteTextBox.Location = new System.Drawing.Point(114, 63);
            this.MinuteTextBox.Name = "MinuteTextBox";
            this.MinuteTextBox.Size = new System.Drawing.Size(78, 21);
            this.MinuteTextBox.TabIndex = 3;
            this.MinuteTextBox.Text = "00";
            // 
            // SecondTextBox
            // 
            this.SecondTextBox.Location = new System.Drawing.Point(217, 61);
            this.SecondTextBox.Name = "SecondTextBox";
            this.SecondTextBox.Size = new System.Drawing.Size(55, 21);
            this.SecondTextBox.TabIndex = 4;
            this.SecondTextBox.Text = "05";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Resetbutton
            // 
            this.Resetbutton.Location = new System.Drawing.Point(164, 197);
            this.Resetbutton.Name = "Resetbutton";
            this.Resetbutton.Size = new System.Drawing.Size(108, 27);
            this.Resetbutton.TabIndex = 5;
            this.Resetbutton.Text = "Reset";
            this.Resetbutton.UseVisualStyleBackColor = true;
            this.Resetbutton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Resetbutton);
            this.Controls.Add(this.SecondTextBox);
            this.Controls.Add(this.MinuteTextBox);
            this.Controls.Add(this.HourTextBox);
            this.Controls.Add(this.TimeLab);
            this.Controls.Add(this.StartButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label TimeLab;
        private System.Windows.Forms.TextBox HourTextBox;
        private System.Windows.Forms.TextBox MinuteTextBox;
        private System.Windows.Forms.TextBox SecondTextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Resetbutton;
    }
}

