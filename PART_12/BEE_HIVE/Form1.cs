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
            world = new World(new BeeMessage(SendMessage));

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

            //UpdateListBoxMy();
        }
        
        private void UpdateListBoxMy()
        {
            int idleBees = 0;
            int flyingToFlowerBees = 0;
            int gatheringNectarBees = 0;
            int returningToHiveBees = 0;
            foreach (Bee bee in world.Bees)
            {
                switch (bee.CurrentState)
                {
                    case BeeState.Idle:
                        idleBees++;
                        break;
                    case BeeState.FlyingToFlower:
                        flyingToFlowerBees++;
                        break;
                    case BeeState.GatheringNectar:
                        gatheringNectarBees++;
                        break;
                    case BeeState.ReturningToHive:
                        returningToHiveBees++;
                        break;
                    case BeeState.MakingHoney:
                        break;
                    case BeeState.Retired:
                        break;
                    default:
                        break;
                }
            }
            listBox1.Items.Clear();
            listBox1.Items.Add(String.Format("Idle: {0} {1}", idleBees, HowManyBees(idleBees)));
            listBox1.Items.Add(String.Format("FlyingToFlower: {0} {1}", flyingToFlowerBees, HowManyBees(flyingToFlowerBees)));
            listBox1.Items.Add(String.Format("GatheringNectar: {0} {1}", gatheringNectarBees, HowManyBees(gatheringNectarBees)));
            listBox1.Items.Add(String.Format("ReturningToHive: {0} {1}", returningToHiveBees, HowManyBees(returningToHiveBees)));            
        }
        private string HowManyBees(int beesCount)
        {
            if (beesCount < 2)
                return "bee";
            return "bees";
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
            world = new World(new BeeMessage(SendMessage));
            if (!timer1.Enabled)
                btnTsStartSimulation.Text = "Start simulation";
        }

        private void SendMessage(int ID, string Message)
        {
            statusStrip1.Items[0].Text = "Bee #" + ID + ": " + Message;
            var beeGroups =
                from bee in world.Bees
                group bee by bee.CurrentState into beeGroup
                orderby beeGroup.Key
                select beeGroup;
            listBox1.Items.Clear();

            foreach (var group in beeGroups)
            {
                string s;
                if (group.Count() == 1)
                    s = "";
                else
                    s = "s";

                listBox1.Items.Add(group.Key.ToString() + ": "
                    + group.Count() + " bee" + s);
                if (group.Key == BeeState.Idle
                    && group.Count() == world.Bees.Count()
                    && framesRun > 0)
                {
                    listBox1.Items.Add("Simualtion ended: all bees are idle");
                    toolStrip1.Items[0].Text = "Simulation ended";
                    statusStrip1.Items[0].Text = "Simulation ended";
                    timer1.Enabled = false;
                }
            }
        }
    }
}
