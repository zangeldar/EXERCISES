using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _619_HiveSimulator
{
    public partial class SettingsForm : Form
    {
        private ApplySettings ApplySettingsCallBack;
        public SettingsForm(Settings settings, ApplySettings applySettingsCallBack = null)
        {
            InitializeComponent();
            LoadSettings(settings);
            this.ApplySettingsCallBack = applySettingsCallBack;
        }

        private void LoadSettings(Settings settings)
        {
            //GENERAL            
            tbvGeneralFrameInterval.InitializeTrackBarValue("Frame Interval:", 1, 100, settings.FrameInterval);

            //WORLD
            //tbvWorldNectarHarvestedPerNewFlower.CurValue = Convert.ToInt32(settings.WorldSettings.NectarHarvestedPerNewFlower);
            tbvWorldNectarHarvestedPerNewFlower.InitializeTrackBarValue("Nectar in New Flower", 1, 100, Convert.ToInt32(settings.WorldSettings.NectarHarvestedPerNewFlower));

            //HIVE
            tbvHiveInitialBees.InitializeTrackBarValue("Init.Bees:", 1, 10, settings.HiveSettings.InitialBees);
            tbvHiveInitialHoney.InitializeTrackBarValue("Init.Honey:", 1, 10, Convert.ToInt32(settings.HiveSettings.InitialHoney));
            tbvHiveMaximumBees.InitializeTrackBarValue("Max.Bees:", 1, 100, settings.HiveSettings.MaximumBees);
            tbvHiveMaximumHoney.InitializeTrackBarValue("Max.Honey", 10, 100, Convert.ToInt32(settings.HiveSettings.MaximumHoney));
            tbvHiveMinimumHoneyForCreationBees.InitializeTrackBarValue("Min.Honey For Creation Bees:", 1, 10, Convert.ToInt32(settings.HiveSettings.MinimumHoneyForCreationBees));
            tbvHiveNectarHoneyRatio.InitializeTrackBarValue("Nectar to Honey Ratio (/100):", 1, 100, Convert.ToInt32(settings.HiveSettings.NectarHoneyRatio*100));
            /*
            tbvHiveInitialBees.InitializeTrackBarValue("Init.Bees:", 1, 10, 5);
            tbvHiveInitialHoney.InitializeTrackBarValue("Init.Honey:", 1, 10, 3);
            tbvHiveMaximumBees.InitializeTrackBarValue("Max.Bees:", 1, 100, 10);
            tbvHiveMaximumHoney.InitializeTrackBarValue("Max.Honey", 10, 100, 30);
            tbvHiveMinimumHoneyForCreationBees.InitializeTrackBarValue("Min.Honey For Creation Bees:", 1, 10, 4);
            tbvHiveNectarHoneyRatio.InitializeTrackBarValue("Nectar to Honey Ratio (/100):", 1, 100, 25);
             */ 
        }

        private Settings CurrentSettings()
        {
            HiveSettings hiveSettings = new HiveSettings();
            hiveSettings.InitialBees = tbvHiveInitialBees.CurValue;
            hiveSettings.InitialHoney = tbvHiveInitialHoney.CurValue;
            hiveSettings.MaximumBees = tbvHiveMaximumBees.CurValue;
            hiveSettings.MaximumHoney = tbvHiveMaximumHoney.CurValue;
            hiveSettings.MinimumHoneyForCreationBees = tbvHiveMinimumHoneyForCreationBees.CurValue;
            hiveSettings.NectarHoneyRatio = (double)tbvHiveNectarHoneyRatio.CurValue / 100;

            WorldSettings worldSettings = new WorldSettings();
            worldSettings.NectarHarvestedPerNewFlower = tbvWorldNectarHarvestedPerNewFlower.CurValue;

            Settings result = new Settings(tbvGeneralFrameInterval.CurValue, 
                worldSettings, hiveSettings);
            
            return result;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (ApplySettingsCallBack != null)
                ApplySettingsCallBack(CurrentSettings());
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnApply_Click(sender, e);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            LoadSettings(new Settings());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Program.GetPathToExe();
            sfd.FileName = "HiveSettings.hvs";
            sfd.Filter = "Hive Settings File (*.hvs)|*.hvs";
            sfd.CheckPathExists = true;
            sfd.Title = "Choose a file to save the current settings";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream output = File.OpenWrite(sfd.FileName))
                    {
                        bf.Serialize(output, CurrentSettings());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save the settings file\r\n " + ex.Message,
                        "Bee Simulator Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //throw;
                }
                
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Settings settings;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Program.GetPathToExe();
            ofd.Filter = "Hive Settings File (*.hvs)|*.hvs";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Title = "Choose a file to open settings";
            if (ofd.ShowDialog() == DialogResult.OK)
            {                
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream input = File.OpenRead(ofd.FileName))
                    {
                        settings = (Settings)bf.Deserialize(input);
                    }
                    LoadSettings(settings);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to read the settings file\r\n " + ex.Message,
                        "Bee Simulator Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //settings = CurrentSettings();
                    //throw;
                }                
            }
        }
    }
}
