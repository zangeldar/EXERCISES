namespace _512_DelegateCuisine
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
            this.amountNum = new System.Windows.Forms.NumericUpDown();
            this.useIngridientButton = new System.Windows.Forms.Button();
            this.getSuzanneButton = new System.Windows.Forms.Button();
            this.getAmyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.amountNum)).BeginInit();
            this.SuspendLayout();
            // 
            // amountNum
            // 
            this.amountNum.Location = new System.Drawing.Point(152, 12);
            this.amountNum.Name = "amountNum";
            this.amountNum.Size = new System.Drawing.Size(120, 20);
            this.amountNum.TabIndex = 0;
            this.amountNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // useIngridientButton
            // 
            this.useIngridientButton.Location = new System.Drawing.Point(12, 9);
            this.useIngridientButton.Name = "useIngridientButton";
            this.useIngridientButton.Size = new System.Drawing.Size(134, 23);
            this.useIngridientButton.TabIndex = 1;
            this.useIngridientButton.Text = "Get The Ingridient";
            this.useIngridientButton.UseVisualStyleBackColor = true;
            this.useIngridientButton.Click += new System.EventHandler(this.useIngridientButton_Click);
            // 
            // getSuzanneButton
            // 
            this.getSuzanneButton.Location = new System.Drawing.Point(12, 38);
            this.getSuzanneButton.Name = "getSuzanneButton";
            this.getSuzanneButton.Size = new System.Drawing.Size(260, 23);
            this.getSuzanneButton.TabIndex = 2;
            this.getSuzanneButton.Text = "Get Suzanne\'s delegate";
            this.getSuzanneButton.UseVisualStyleBackColor = true;
            this.getSuzanneButton.Click += new System.EventHandler(this.getSuzanneButton_Click);
            // 
            // getAmyButton
            // 
            this.getAmyButton.Location = new System.Drawing.Point(12, 67);
            this.getAmyButton.Name = "getAmyButton";
            this.getAmyButton.Size = new System.Drawing.Size(260, 23);
            this.getAmyButton.TabIndex = 3;
            this.getAmyButton.Text = "Get Amy\'s delegate";
            this.getAmyButton.UseVisualStyleBackColor = true;
            this.getAmyButton.Click += new System.EventHandler(this.getAmyButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 97);
            this.Controls.Add(this.getAmyButton);
            this.Controls.Add(this.getSuzanneButton);
            this.Controls.Add(this.useIngridientButton);
            this.Controls.Add(this.amountNum);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.amountNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown amountNum;
        private System.Windows.Forms.Button useIngridientButton;
        private System.Windows.Forms.Button getSuzanneButton;
        private System.Windows.Forms.Button getAmyButton;
    }
}

