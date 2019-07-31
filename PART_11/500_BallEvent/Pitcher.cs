using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _500_BallEvent
{
    class Pitcher
    {
        public Pitcher(Ball ball)
        {
            ball.BallInPlay += new EventHandler<BallEventArgs>(ball_BallInPlay);
        }

        private void ball_BallInPlay(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if ((ballEventArgs.Distance < 95) && (ballEventArgs.Trajectory < 60))
                    CatchBall();
                else
                    CoverFirstBase();
            }
        }

        private void CoverFirstBase()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Pitcher: I covered first base");
        }

        private void CatchBall()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Pitcher: I caught the ball");
        }



    }
}
