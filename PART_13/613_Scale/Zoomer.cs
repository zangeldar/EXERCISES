using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _613_Scale
{
    public partial class Zoomer : UserControl
    {
        Bitmap photo = new Bitmap(Properties.Resources.Bee_animation_1);
        public Zoomer()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Zoomer_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, 0, 0, Width, Height);
            g.DrawImage(photo, 10, 10, trackBar1.Value, trackBar2.Value);
        }
    }
}
