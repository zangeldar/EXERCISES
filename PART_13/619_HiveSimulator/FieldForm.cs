using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _619_HiveSimulator
{
    public partial class FieldForm : Form
    {
        public FieldForm()
        {
            InitializeComponent();
        }

        private void FieldForm_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.Location.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            { 
            // page 602
            /*
            PictureBox beePicture = new PictureBox();
            beePicture.Location = new Point(10, 10);
            beePicture.Size = new Size(100, 100);
            beePicture.BorderStyle = BorderStyle.FixedSingle;
            beePicture.Image = Renderer.ResizeImage(Properties.Resources.Bee_animation_1, 80, 40);
            Controls.Add(beePicture);
             */
            }
            using (Graphics g = this.CreateGraphics())
            {
                g.DrawLine(Pens.Blue, 30, 10, 100, 45);
                g.DrawLine(Pens.Blue, new Point(30, 45), new Point(100, 10));
                g.FillRectangle(Brushes.SlateGray, new Rectangle(150, 15, 140, 90));
                g.DrawRectangle(Pens.SkyBlue, new Rectangle(150, 15, 140, 90));
                g.FillEllipse(Brushes.DarkGray, new Rectangle(45, 65, 200, 100));
                g.FillEllipse(Brushes.Silver, new Rectangle(40, 60, 200, 100));
                using (Font arial24Bold = new Font("Arial", 24, FontStyle.Bold))
                {
                    g.DrawString("Hi there!", arial24Bold, Brushes.Red, 50, 75);
                }

            }
        }
    }
}
