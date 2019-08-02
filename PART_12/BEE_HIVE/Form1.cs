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

namespace BEE_HIVE
{
    public partial class Form1 : Form
    {
        private HiveForm hiveForm = new HiveForm();
        private FieldForm fieldForm = new FieldForm();
        private Renderer renderer;

        private World world;
        private Random random = new Random();
        private DateTime start = DateTime.Now;
        private DateTime end;
        private int framesRun = 0;
        public Form1()
        {
            InitializeComponent();

            MoveChildForms();
            hiveForm.Show(this);
            fieldForm.Show(this);
            
            ResetSimulator();

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(RunFrame);
            timer1.Enabled = false;
            UpdateStats(new TimeSpan());            
        }
        private void MoveChildForms()
        {
            //throw new NotImplementedException();
            hiveForm.Location = new Point(Location.X + Width + 10, Location.Y);
            fieldForm.Location = new Point(Location.X, Location.Y + Height + 10);
        }

        private void ResetSimulator()
        {
            //throw new NotImplementedException();
            framesRun = 0;
            world = new World(new BeeMessage(SendMessage));
            renderer = new Renderer(world, hiveForm, fieldForm);
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
            renderer.Render();
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
            renderer.Reset();
            ResetSimulator();
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

        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            World currentWorld = world;
            int currentFramesRun = framesRun;

            bool enabled = timer1.Enabled;
            if (enabled)
                timer1.Stop();
            
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Simulator File (*.bees)|*.bees";
            openDialog.CheckPathExists = true;
            openDialog.CheckFileExists = true;
            openDialog.Title = "Choose a file with a simulation to load";
            openDialog.InitialDirectory = GetPathToExe();

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream input = File.OpenRead(openDialog.FileName))
                    {
                        world = (World)bf.Deserialize(input);
                        framesRun = (int)bf.Deserialize(input);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to read the simulator file\r\n" + ex.Message,
                        "Bees Simulator Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    world = currentWorld;
                    framesRun = currentFramesRun;
                    //throw;
                }
            }

            world.Hive.MessageSender = new BeeMessage(SendMessage);
            foreach (Bee bee in world.Bees)
                bee.MessageSender = new BeeMessage(SendMessage);

            renderer.Reset();
            renderer = new Renderer(world, hiveForm, fieldForm);
            if (enabled)
                timer1.Start();            
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            bool enabled = timer1.Enabled;
            if (enabled)
                timer1.Stop();

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Simulator File (*.bees)|*.bees";
            //saveDialog.CheckFileExists = true;
            saveDialog.CheckPathExists = true;
            saveDialog.Title = "Choose a file to save the current simulation";
            saveDialog.InitialDirectory = GetPathToExe();
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream output = File.OpenWrite(saveDialog.FileName))
                    {
                        bf.Serialize(output, world);
                        bf.Serialize(output, framesRun);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save the simulator file\r\n " + ex.Message,
                        "Bee Simulator Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //throw;
                }
            }
            if (enabled)
                timer1.Start();
        }

        private string GetPathToExe()
        {
            string result = @Application.ExecutablePath;
            int posOfLastSlash = result.LastIndexOf('\\');
            posOfLastSlash = Math.Max(posOfLastSlash, result.LastIndexOf('/'));
            result = @result.Substring(0, posOfLastSlash);
            return result;
        }

        private void печатьToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Move(object sender, EventArgs e)
        {
            MoveChildForms();
        }
    }
}
