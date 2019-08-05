using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _619_HiveSimulator
{
    public partial class Form1 : Form
    {
        private int unUsedInt;
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
            hiveForm.Location = new Point(Location.X + Width + 10, Location.Y);
            fieldForm.Location = new Point(Location.X, Location.Y + Height + 10);
        }

        private void ResetSimulator()
        {
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
            hiveForm.Invalidate();
            fieldForm.Invalidate();
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
            //renderer.Reset();
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

            //renderer.Reset();
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
            bool enabled = timer1.Enabled;
            if (enabled)
                timer1.Stop();

            PrintDocument document = new PrintDocument();
            document.PrintPage += document_PrintPage;
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = document;
            preview.ShowDialog(this);

            if (enabled)
                timer1.Start();
        }
        private void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Size stringSize;
            using (Font arial24bold = new Font("Arial", 24, FontStyle.Bold))
            {
                stringSize = Size.Ceiling(
                    g.MeasureString("Bee simulator", arial24bold));
                g.FillEllipse(Brushes.Gray,
                    new Rectangle(e.MarginBounds.X + 2, e.MarginBounds.Y + 2,
                        stringSize.Width + 30, stringSize.Height + 30));
                g.FillEllipse(Brushes.Black,
                    new Rectangle(e.MarginBounds.X, e.MarginBounds.Y,
                        stringSize.Width + 30, stringSize.Height + 30));
                g.DrawString("Bee simulator", arial24bold,
                    Brushes.Gray, e.MarginBounds.X + 17, e.MarginBounds.Y + 17);
                g.DrawString("Bee simulator", arial24bold,
                    Brushes.Black, e.MarginBounds.X + 15, e.MarginBounds.Y + 15);
            }

            int tableX = e.MarginBounds.X + (int)stringSize.Width + 50;
            int tableWidth = e.MarginBounds.X + e.MarginBounds.Width - tableX - 20;
            int firstColumnX = tableX + 2;
            int secondColumnX = tableX + (tableWidth / 2) + 5;
            int tableY = e.MarginBounds.Y;

            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Bees", BeesLbl.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Flowers", FlowersLbl.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Honey in Hive", HoneyInHiveLbl.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Nectar in Flowers", NectarInFlowersLbl.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Frames Run", FramesRunLbl.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Frames Rate", FramesRateLbl.Text);

            g.DrawRectangle(Pens.Black, tableX, e.MarginBounds.Y,
                tableWidth, tableY - e.MarginBounds.Y);
            g.DrawLine(Pens.Black, secondColumnX, e.MarginBounds.Y,
                secondColumnX, tableY);

            using (Pen blackPen = new Pen(Brushes.Black, 2))
            using (Bitmap hiveBitmap = new Bitmap(hiveForm.ClientSize.Width,
                hiveForm.ClientSize.Height))
            using (Bitmap fieldBitmap = new Bitmap(fieldForm.ClientSize.Width,
                fieldForm.ClientSize.Height))
            {
                using (Graphics hiveGraphics = Graphics.FromImage(hiveBitmap))
                {
                    renderer.PaintHive(hiveGraphics);
                }
                int hiveWidth = e.MarginBounds.Width / 2;
                float ratio = (float)hiveBitmap.Height / (float)hiveBitmap.Width;
                int hiveHeight = (int)(hiveWidth * ratio);
                int hiveX = e.MarginBounds.X + (e.MarginBounds.Width - hiveWidth) / 2;
                int hiveY = e.MarginBounds.Height / 3;
                g.DrawImage(hiveBitmap, hiveX, hiveY, hiveWidth, hiveHeight);
                g.DrawRectangle(blackPen, hiveX, hiveY, hiveWidth, hiveHeight);

                using (Graphics fieldGraphics = Graphics.FromImage(fieldBitmap))
                {
                    renderer.PaintField(fieldGraphics);
                }
                int fieldWidth = e.MarginBounds.Width;
                ratio = (float)fieldBitmap.Height / (float)fieldBitmap.Width;
                int fieldHeight = (int)(fieldWidth * ratio);
                int fieldX = e.MarginBounds.X;
                int fieldY = e.MarginBounds.Y + e.MarginBounds.Height - fieldHeight;
                g.DrawImage(fieldBitmap, fieldX, fieldY, fieldWidth, fieldHeight);
                g.DrawRectangle(blackPen, fieldX, fieldY, fieldWidth, fieldHeight);
            }
        }

        private int PrintTableRow(Graphics printGraphics, int tableX,
            int tableWidth, int firstColumnX, int secondColumnX,
            int tableY, string firstColumn, string secondColumn)
        {
            Font arial12 = new Font("Arial", 12);
            Size stringSize = Size.Ceiling(printGraphics.MeasureString(firstColumn, arial12));
            tableY += 2;
            printGraphics.DrawString(firstColumn, arial12, Brushes.Black,
                firstColumnX, tableY);
            printGraphics.DrawString(secondColumn, arial12, Brushes.Black,
                secondColumnX, tableY);
            tableY += (int)stringSize.Height + 2;
            printGraphics.DrawLine(Pens.Black, tableX, tableY, tableX + tableWidth, tableY);
            arial12.Dispose();
            return tableY;
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            MoveChildForms();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            renderer.AnimateBees();
        }
    }
}
