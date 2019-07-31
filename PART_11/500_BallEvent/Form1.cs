using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _500_BallEvent
{
    public partial class Form1 : Form
    {
        Ball ball = new Ball();
        Pitcher pitcher;
        Fan fan;
        public Form1()
        {
            InitializeComponent();
            pitcher = new Pitcher(ball);
            fan = new Fan(ball);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BallEventArgs ballEventArgs = new BallEventArgs((int)trajectoryNum.Value, (int)distanceNum.Value);
            //ball.OnBallInPlay(ballEventArgs);
            Bat bat = ball.GetNewBat();
            bat.HitTheBall(ballEventArgs);
        }
    }
}
