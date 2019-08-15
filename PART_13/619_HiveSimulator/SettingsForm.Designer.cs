namespace _619_HiveSimulator
{
    partial class SettingsForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageGeneral = new System.Windows.Forms.TabPage();
            this.pageWorld = new System.Windows.Forms.TabPage();
            this.pageHive = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tbvGeneralFrameInterval = new _619_HiveSimulator.TrackBarValue();
            this.tbvWorldNectarHarvestedPerNewFlower = new _619_HiveSimulator.TrackBarValue();
            this.tbvHiveMaximumHoney = new _619_HiveSimulator.TrackBarValue();
            this.tbvHiveMaximumBees = new _619_HiveSimulator.TrackBarValue();
            this.tbvHiveMinimumHoneyForCreationBees = new _619_HiveSimulator.TrackBarValue();
            this.tbvHiveNectarHoneyRatio = new _619_HiveSimulator.TrackBarValue();
            this.tbvHiveInitialHoney = new _619_HiveSimulator.TrackBarValue();
            this.tbvHiveInitialBees = new _619_HiveSimulator.TrackBarValue();
            this.tabControl1.SuspendLayout();
            this.pageGeneral.SuspendLayout();
            this.pageWorld.SuspendLayout();
            this.pageHive.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageGeneral);
            this.tabControl1.Controls.Add(this.pageWorld);
            this.tabControl1.Controls.Add(this.pageHive);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(361, 373);
            this.tabControl1.TabIndex = 3;
            // 
            // pageGeneral
            // 
            this.pageGeneral.Controls.Add(this.tbvGeneralFrameInterval);
            this.pageGeneral.Location = new System.Drawing.Point(4, 22);
            this.pageGeneral.Name = "pageGeneral";
            this.pageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.pageGeneral.Size = new System.Drawing.Size(353, 347);
            this.pageGeneral.TabIndex = 0;
            this.pageGeneral.Text = "General";
            this.pageGeneral.UseVisualStyleBackColor = true;
            // 
            // pageWorld
            // 
            this.pageWorld.Controls.Add(this.tbvWorldNectarHarvestedPerNewFlower);
            this.pageWorld.Location = new System.Drawing.Point(4, 22);
            this.pageWorld.Name = "pageWorld";
            this.pageWorld.Padding = new System.Windows.Forms.Padding(3);
            this.pageWorld.Size = new System.Drawing.Size(353, 347);
            this.pageWorld.TabIndex = 1;
            this.pageWorld.Text = "World";
            this.pageWorld.UseVisualStyleBackColor = true;
            // 
            // pageHive
            // 
            this.pageHive.Controls.Add(this.tbvHiveMaximumHoney);
            this.pageHive.Controls.Add(this.tbvHiveMaximumBees);
            this.pageHive.Controls.Add(this.tbvHiveMinimumHoneyForCreationBees);
            this.pageHive.Controls.Add(this.tbvHiveNectarHoneyRatio);
            this.pageHive.Controls.Add(this.tbvHiveInitialHoney);
            this.pageHive.Controls.Add(this.tbvHiveInitialBees);
            this.pageHive.Location = new System.Drawing.Point(4, 22);
            this.pageHive.Name = "pageHive";
            this.pageHive.Padding = new System.Windows.Forms.Padding(3);
            this.pageHive.Size = new System.Drawing.Size(353, 347);
            this.pageHive.TabIndex = 2;
            this.pageHive.Text = "Hive";
            this.pageHive.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Location = new System.Drawing.Point(12, 391);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 31);
            this.panel1.TabIndex = 4;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(283, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(202, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(121, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OKay";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDefault);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnLoad);
            this.panel2.Location = new System.Drawing.Point(379, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(81, 410);
            this.panel2.TabIndex = 5;
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(3, 61);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(3, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // tbvGeneralFrameInterval
            // 
            this.tbvGeneralFrameInterval.CurValue = 50;
            this.tbvGeneralFrameInterval.Location = new System.Drawing.Point(6, 6);
            this.tbvGeneralFrameInterval.MaxValue = 100;
            this.tbvGeneralFrameInterval.MinValue = 0;
            this.tbvGeneralFrameInterval.Name = "tbvGeneralFrameInterval";
            this.tbvGeneralFrameInterval.Size = new System.Drawing.Size(344, 51);
            this.tbvGeneralFrameInterval.TabIndex = 0;
            this.tbvGeneralFrameInterval.TrackBarText = "TrackBarValue";
            // 
            // tbvWorldNectarHarvestedPerNewFlower
            // 
            this.tbvWorldNectarHarvestedPerNewFlower.CurValue = 50;
            this.tbvWorldNectarHarvestedPerNewFlower.Location = new System.Drawing.Point(6, 6);
            this.tbvWorldNectarHarvestedPerNewFlower.MaxValue = 100;
            this.tbvWorldNectarHarvestedPerNewFlower.MinValue = 0;
            this.tbvWorldNectarHarvestedPerNewFlower.Name = "tbvWorldNectarHarvestedPerNewFlower";
            this.tbvWorldNectarHarvestedPerNewFlower.Size = new System.Drawing.Size(344, 51);
            this.tbvWorldNectarHarvestedPerNewFlower.TabIndex = 0;
            this.tbvWorldNectarHarvestedPerNewFlower.TrackBarText = "TrackBarValue";
            // 
            // tbvHiveMaximumHoney
            // 
            this.tbvHiveMaximumHoney.CurValue = 0;
            this.tbvHiveMaximumHoney.Location = new System.Drawing.Point(6, 291);
            this.tbvHiveMaximumHoney.MaxValue = 10;
            this.tbvHiveMaximumHoney.MinValue = 0;
            this.tbvHiveMaximumHoney.Name = "tbvHiveMaximumHoney";
            this.tbvHiveMaximumHoney.Size = new System.Drawing.Size(344, 51);
            this.tbvHiveMaximumHoney.TabIndex = 5;
            this.tbvHiveMaximumHoney.TrackBarText = "Max.Honey";
            // 
            // tbvHiveMaximumBees
            // 
            this.tbvHiveMaximumBees.CurValue = 0;
            this.tbvHiveMaximumBees.Location = new System.Drawing.Point(6, 234);
            this.tbvHiveMaximumBees.MaxValue = 10;
            this.tbvHiveMaximumBees.MinValue = 0;
            this.tbvHiveMaximumBees.Name = "tbvHiveMaximumBees";
            this.tbvHiveMaximumBees.Size = new System.Drawing.Size(344, 51);
            this.tbvHiveMaximumBees.TabIndex = 4;
            this.tbvHiveMaximumBees.TrackBarText = "Max.Bees";
            // 
            // tbvHiveMinimumHoneyForCreationBees
            // 
            this.tbvHiveMinimumHoneyForCreationBees.CurValue = 0;
            this.tbvHiveMinimumHoneyForCreationBees.Location = new System.Drawing.Point(6, 177);
            this.tbvHiveMinimumHoneyForCreationBees.MaxValue = 10;
            this.tbvHiveMinimumHoneyForCreationBees.MinValue = 0;
            this.tbvHiveMinimumHoneyForCreationBees.Name = "tbvHiveMinimumHoneyForCreationBees";
            this.tbvHiveMinimumHoneyForCreationBees.Size = new System.Drawing.Size(344, 51);
            this.tbvHiveMinimumHoneyForCreationBees.TabIndex = 3;
            this.tbvHiveMinimumHoneyForCreationBees.TrackBarText = "Min.Honey For Creation Bees";
            // 
            // tbvHiveNectarHoneyRatio
            // 
            this.tbvHiveNectarHoneyRatio.CurValue = 0;
            this.tbvHiveNectarHoneyRatio.Location = new System.Drawing.Point(6, 120);
            this.tbvHiveNectarHoneyRatio.MaxValue = 10;
            this.tbvHiveNectarHoneyRatio.MinValue = 0;
            this.tbvHiveNectarHoneyRatio.Name = "tbvHiveNectarHoneyRatio";
            this.tbvHiveNectarHoneyRatio.Size = new System.Drawing.Size(344, 51);
            this.tbvHiveNectarHoneyRatio.TabIndex = 2;
            this.tbvHiveNectarHoneyRatio.TrackBarText = "Nector to Honey Ratio / 100";
            // 
            // tbvHiveInitialHoney
            // 
            this.tbvHiveInitialHoney.CurValue = 0;
            this.tbvHiveInitialHoney.Location = new System.Drawing.Point(6, 63);
            this.tbvHiveInitialHoney.MaxValue = 10;
            this.tbvHiveInitialHoney.MinValue = 0;
            this.tbvHiveInitialHoney.Name = "tbvHiveInitialHoney";
            this.tbvHiveInitialHoney.Size = new System.Drawing.Size(344, 51);
            this.tbvHiveInitialHoney.TabIndex = 1;
            this.tbvHiveInitialHoney.TrackBarText = "Initial Honey:";
            // 
            // tbvHiveInitialBees
            // 
            this.tbvHiveInitialBees.CurValue = 0;
            this.tbvHiveInitialBees.Location = new System.Drawing.Point(6, 6);
            this.tbvHiveInitialBees.MaxValue = 10;
            this.tbvHiveInitialBees.MinValue = 0;
            this.tbvHiveInitialBees.Name = "tbvHiveInitialBees";
            this.tbvHiveInitialBees.Size = new System.Drawing.Size(344, 51);
            this.tbvHiveInitialBees.TabIndex = 0;
            this.tbvHiveInitialBees.TrackBarText = "Initial Bees:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(463, 426);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.tabControl1.ResumeLayout(false);
            this.pageGeneral.ResumeLayout(false);
            this.pageWorld.ResumeLayout(false);
            this.pageHive.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageGeneral;
        private System.Windows.Forms.TabPage pageWorld;
        private System.Windows.Forms.TabPage pageHive;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private TrackBarValue tbvGeneralFrameInterval;
        private TrackBarValue tbvWorldNectarHarvestedPerNewFlower;
        private TrackBarValue tbvHiveInitialHoney;
        private TrackBarValue tbvHiveInitialBees;
        private TrackBarValue tbvHiveNectarHoneyRatio;
        private TrackBarValue tbvHiveMinimumHoneyForCreationBees;
        private TrackBarValue tbvHiveMaximumBees;
        private TrackBarValue tbvHiveMaximumHoney;


    }
}