using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _619_HiveSimulator
{
    public partial class TrackBarValue : UserControl
    {
        public void InitializeTrackBarValue(string Text, int MinValue, int MaxValue, int InitialValue)
        {
            //InitializeComponent();
            label1.Location = new Point(5, 5);
            label1.Text = Text;
            trackBar1.Minimum = MinValue;
            trackBar1.Maximum = MaxValue;
            trackBar1.Value = InitialValue;
            numericUpDown1.Value = InitialValue;
            ResizeMy();
        }

        public TrackBarValue()
        {
            InitializeComponent();
            //InitializeTrackBarValue("TrackBarValue", 0, 100, 50);
            ResizeMy();
        }

        private void ResizeMy()
        {
            trackBar1.Location = new Point(label1.Location.X + label1.Size.Width + 5,
               label1.Location.Y);
            
            numericUpDown1.Location = new Point(this.Size.Width - numericUpDown1.Size.Width - 5,
                label1.Location.Y);

            trackBar1.Size = new Size(numericUpDown1.Location.X - trackBar1.Location.X - 5,
                trackBar1.Size.Height);
        }

        private void TrackBarValue_SizeChanged(object sender, EventArgs e)
        {
            ResizeMy();
        }


        public string TrackBarText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public int MinValue
        {
            get { return trackBar1.Minimum; }
            set 
            {
                if (value > trackBar1.Maximum)
                {
                    //value = trackBar1.Maximum;
                    MessageBox.Show(String.Format("Value: {0} is more than MaximumValue: {1}\r\nNothing changed!", value, trackBar1.Maximum));
                    return;
                }                    
                trackBar1.Minimum = value;
                numericUpDown1.Minimum = value;
            }
        }

        public int MaxValue
        {
            get { return trackBar1.Maximum; }
            set             
            {
                if (value < trackBar1.Minimum)
                {
                    //value = trackBar1.Minimum;
                    MessageBox.Show(String.Format("Value: {0} is less than MinimumValue: {1}\r\nNothing changed!", value, trackBar1.Minimum));
                    return;
                }                    
                trackBar1.Maximum = value;
                numericUpDown1.Maximum = value;
            }
        }
        public int CurValue { 
            get { return trackBar1.Value; } 
            set 
            {                                 
                if (MaxValue < value)
                    MaxValue = value;
                if (MinValue > value)
                    MinValue = value;
                trackBar1.Value = value;
                numericUpDown1.Value = value;
            } 
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = (sender as TrackBar).Minimum;
            numericUpDown1.Maximum = (sender as TrackBar).Maximum;
            numericUpDown1.Value = (sender as TrackBar).Value;
            //numericUpDown1.Value = CurValue;
            //CurValue = (sender as TrackBar).Value;
            //(sender as TrackBar).Invalidate();
            numericUpDown1.Invalidate();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = (int)(sender as NumericUpDown).Value;
            //trackBar1.Value = CurValue;
            //CurValue = (int)(sender as NumericUpDown).Value;
            //(sender as NumericUpDown).Invalidate();
            trackBar1.Invalidate();
        }

    }
}
