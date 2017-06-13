using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Ball
    {
        private PictureBox ball;
        Random rand = new Random();
        int xSpeed, ySpeed;
        Player leftPlayer, rightPlayer;
        public Ball(PictureBox ball, Player leftPlayer, Player rightPlayer)
        {
            this.ball = ball;
            this.leftPlayer = leftPlayer;
            this.rightPlayer = rightPlayer;
            xSpeed = 1;
            ySpeed = 2;
            ResetBall();
        }

        internal void ProcessMove()
        {
            var bottom = PongWorldInfo.bottomWorld - ball.Height;
            ball.Location = new Point(ball.Location.X + xSpeed,
               Math.Max(PongWorldInfo.topWorld, Math.Min(PongWorldInfo.bottomWorld - ball.Height, ball.Location.Y + ySpeed)));
            if (ball.Location.Y >= bottom || ball.Location.Y <= PongWorldInfo.topWorld)
            {
                ySpeed *= -1;
            }

            if (ball.Location.X <= PongWorldInfo.leftOfWorld)
            {
                Score(leftPlayer);
            } else if(ball.Location.X >= PongWorldInfo.rightOfWorld - ball.Width)
            {
                Score(rightPlayer);
            }
            if(leftPlayer.paddle.Bounds.IntersectsWith(ball.Bounds)
                || rightPlayer.paddle.Bounds.IntersectsWith(ball.Bounds)) {
                xSpeed *= -2;
                ySpeed *= 2;
            }
            
        }


        private void Score(Player winningPlayer)
        {
            winningPlayer.score++;
            ResetBall();
        }

        private void ResetBall()
        {
            ball.Location = new Point((PongWorldInfo.leftOfWorld + PongWorldInfo.rightOfWorld) / 2, (PongWorldInfo.topWorld + PongWorldInfo.bottomWorld) / 2);
            do
            {
                xSpeed = rand.Next(-3, 3);
                ySpeed = rand.Next(-3, 3);
            } while (Math.Abs(xSpeed) + Math.Abs(ySpeed) <= 3 || Math.Abs(xSpeed) <= 1);
        }
    }
}

