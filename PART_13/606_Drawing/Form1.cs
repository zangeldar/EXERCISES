using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _606_Drawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 500;
            this.Height = 500;
        }

        private int clickCount = 0;

        private void Form1_Click(object sender, EventArgs e)
        {
            ResetForm();
            switch (clickCount)
            {
                case 0:                    
                    Click_0();
                    break;
                case 1:                    
                    Click_1();
                    break;
                case 2:
                    Click_2();
                    break;
                default:
                    //throw new NotImplementedException();
                    break;
            }            

            clickCount++;
            if (clickCount > 10)
                clickCount = 0;
        }

        private void ResetForm()
        {
            using (Graphics g = this.CreateGraphics())
            {
                g.FillRectangle(Brushes.SeaShell, this.ClientRectangle);
            }
        }

        private void Click_0()
        {
            using (Graphics g = this.CreateGraphics())
            {
                g.FillRectangle(Brushes.Blue, this.ClientRectangle);

                g.DrawImage(Properties.Resources.Bee_animation_1, 50, 20, 75, 75);
                g.DrawImage(Properties.Resources.Flower, 10, 130, 100, 150);

                using (Pen thickBlackPen = new Pen(Brushes.Black, 3.0F))
                {
                    g.DrawLines(thickBlackPen, new Point[]{
                        new Point(130,110), new Point(120,160), new Point(155,163)});
                    g.DrawCurve(thickBlackPen, new Point[]{
                        new Point(120,160), new Point(175,120), new Point(215,70)});
                }

                using (Font font = new Font("Arial", 16, FontStyle.Italic))
                {
                    SizeF size = g.MeasureString("Nectar here", font);
                    g.DrawString("Nectar here", font, Brushes.Red, new Point(215 - (int)size.Width / 2, 70 - (int)size.Height));
                }
            }
        }

        private void Click_1()
        {
            using (Graphics g = this.CreateGraphics())
            using (Font f = new Font("Arial", 6, FontStyle.Regular))
            {
                for (int x = 0; x < this.Width; x += 20)
                {
                    g.DrawLine(Pens.Black, new Point(x, 0), new Point(x, this.Height));
                    g.DrawString(x.ToString(), f, Brushes.Black, new Point(x, 0));
                }
                for (int y = 0; y < this.Height; y += 20)
                {
                    g.DrawLine(Pens.Black, new Point(0, y), new Point(this.Width, y));
                    g.DrawString(y.ToString(), f, Brushes.Black, new Point(0, y));
                }
            }
        }

        private void Click_2()
        {
            using (Graphics g = CreateGraphics())
            {
                g.DrawImage(Properties.Resources.Hive__inside_,
                    -Width, -Height, Width * 2, Height * 2);
                Size size = new Size(Width / 5, Height / 5);
                DrawBee(g, new Rectangle(
                    new Point(Width/2-50, Height/2-40), size));
                DrawBee(g, new Rectangle(
                    new Point(Width/2-20, Height/2-60), size));
                DrawBee(g, new Rectangle(
                    new Point(Width / 2 - 80, Height / 2 - 30), size));
                DrawBee(g, new Rectangle(
                    new Point(Width / 2 - 90, Height / 2 - 80), size));
            }
        }

        public void DrawBee(Graphics g, Rectangle rect)
        {
            g.DrawImage(Properties.Resources.Bee_animation_1, rect);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(Properties.Resources.Hive__inside_,
    -Width, -Height, Width * 2, Height * 2);
            Size size = new Size(Width / 5, Height / 5);
            DrawBee(g, new Rectangle(
                new Point(Width / 2 - 50, Height / 2 - 40), size));
            DrawBee(g, new Rectangle(
                new Point(Width / 2 - 20, Height / 2 - 60), size));
            DrawBee(g, new Rectangle(
                new Point(Width / 2 - 80, Height / 2 - 30), size));
            DrawBee(g, new Rectangle(
                new Point(Width / 2 - 90, Height / 2 - 80), size));
        }


    }
}
