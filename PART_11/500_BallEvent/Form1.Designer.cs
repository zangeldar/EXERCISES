namespace _500_BallEvent
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trajectoryNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.distanceNum = new System.Windows.Forms.NumericUpDown();
            this.playBallButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trajectoryNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceNum)).BeginInit();
            this.SuspendLayout();
            // 
            // trajectoryNum
            // 
            this.trajectoryNum.Location = new System.Drawing.Point(152, 14);
            this.trajectoryNum.Name = "trajectoryNum";
            this.trajectoryNum.Size = new System.Drawing.Size(120, 20);
            this.trajectoryNum.TabIndex = 0;
            this.trajectoryNum.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Trajectory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Distance";
            // 
            // distanceNum
            // 
            this.distanceNum.Location = new System.Drawing.Point(152, 40);
            this.distanceNum.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.distanceNum.Name = "distanceNum";
            this.distanceNum.Size = new System.Drawing.Size(120, 20);
            this.distanceNum.TabIndex = 3;
            this.distanceNum.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // playBallButton
            // 
            this.playBallButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playBallButton.Location = new System.Drawing.Point(95, 66);
            this.playBallButton.Name = "playBallButton";
            this.playBallButton.Size = new System.Drawing.Size(75, 23);
            this.playBallButton.TabIndex = 4;
            this.playBallButton.Text = "Play ball!";
            this.playBallButton.UseVisualStyleBackColor = true;
            this.playBallButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 109);
            this.Controls.Add(this.playBallButton);
            this.Controls.Add(this.distanceNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trajectoryNum);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trajectoryNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown trajectoryNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown distanceNum;
        private System.Windows.Forms.Button playBallButton;
    }
}