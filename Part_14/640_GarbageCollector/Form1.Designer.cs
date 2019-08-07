namespace _640_GarbageCollector
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClone1 = new System.Windows.Forms.Button();
            this.btnClone2 = new System.Windows.Forms.Button();
            this.btnGC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClone1
            // 
            this.btnClone1.Location = new System.Drawing.Point(12, 12);
            this.btnClone1.Name = "btnClone1";
            this.btnClone1.Size = new System.Drawing.Size(75, 23);
            this.btnClone1.TabIndex = 0;
            this.btnClone1.Text = "Clone #1";
            this.btnClone1.UseVisualStyleBackColor = true;
            this.btnClone1.Click += new System.EventHandler(this.btnClone1_Click);
            // 
            // btnClone2
            // 
            this.btnClone2.Location = new System.Drawing.Point(12, 41);
            this.btnClone2.Name = "btnClone2";
            this.btnClone2.Size = new System.Drawing.Size(75, 23);
            this.btnClone2.TabIndex = 1;
            this.btnClone2.Text = "Clone #2";
            this.btnClone2.UseVisualStyleBackColor = true;
            this.btnClone2.Click += new System.EventHandler(this.btnClone2_Click);
            // 
            // btnGC
            // 
            this.btnGC.Location = new System.Drawing.Point(12, 70);
            this.btnGC.Name = "btnGC";
            this.btnGC.Size = new System.Drawing.Size(75, 23);
            this.btnGC.TabIndex = 2;
            this.btnGC.Text = "GC";
            this.btnGC.UseVisualStyleBackColor = true;
            this.btnGC.Click += new System.EventHandler(this.btnGC_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(116, 108);
            this.Controls.Add(this.btnGC);
            this.Controls.Add(this.btnClone2);
            this.Controls.Add(this.btnClone1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClone1;
        private System.Windows.Forms.Button btnClone2;
        private System.Windows.Forms.Button btnGC;
    }
}

