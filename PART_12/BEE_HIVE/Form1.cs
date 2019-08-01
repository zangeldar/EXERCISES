using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEE_HIVE
{
    public partial class Form1 : Form
    {
        private World world;
        private int framesRun;
        public Form1()
        {
            InitializeComponent();
            world = new World();
        }

        private void UpdateStats(TimeSpan frameDuration)
        {
            BeesLbl.Text = world.Bees.Count.ToString();
            FlowersLbl.Text = world.Flowers.Count.ToString();
            HoneyInHiveLbl.Text = String.Format("{0:f3}", world.Hive.Honey);

            double nectar = 0;
            foreach (Flower flower in world.Flowers)
                nectar += flower.Nectar;
            NectarInFlowersLbl.Text = String.Format("{0:f3}", nectar);
            FramesRunLbl.Text = framesRun.ToString();
            double milliSeconds = frameDuration.TotalMilliseconds;
            if (milliSeconds != 0.0)
                FramesRateLbl.Text = string.Format("{0:f0} ({1:f1}ms)", 1000 / milliSeconds, milliSeconds);
            else
                FramesRateLbl.Text = "N/A";
        }
    }
}
