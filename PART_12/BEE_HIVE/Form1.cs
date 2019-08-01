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
        private Random random = new Random();
        private DateTime start = DateTime.Now;
        private DateTime end;
        private int framesRun = 0;
        public Form1()
        {
            InitializeComponent();
            world = new World();

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(RunFrame);
            timer1.Enabled = false;
            UpdateStats(new TimeSpan());
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

        public void RunFrame(object sender, EventArgs e)
        {
            framesRun++;
            world.Go(random);
            end = DateTime.Now;
            TimeSpan frameDuration = end - start;
            start = end;
            UpdateStats(frameDuration);
        }

        private void btnTsStartSimulation_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled)
                btnTsStartSimulation.Text = "Pause simulator";
            else
                btnTsStartSimulation.Text = "Resume simulator";
        }

        private void btnTsReset_Click(object sender, EventArgs e)
        {
            framesRun = 0;
            world = new World();
            if (!timer1.Enabled)
                btnTsStartSimulation.Text = "Start simulation";
        }
    }
}
