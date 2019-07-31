using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _500_BallEvent
{
    class Fan
    {
        public Fan(Ball ball)
        {
            ball.BallInPlay += ball_BallInPlay;
        }

        void ball_BallInPlay(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if ((ballEventArgs.Distance > 400) && (ballEventArgs.Trajectory > 30))
                    Console.WriteLine("Fan: Home run! I'm going for the ball!");
                else
                    Console.WriteLine("Fan: Woo-hoo! Yeah!");
            }
        }
    }
}
