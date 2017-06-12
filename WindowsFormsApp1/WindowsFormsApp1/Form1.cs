using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const int movementspeed = 3, topWorld = 0, bottomWorld = 498; 
        bool isUpPressedForPlayer1, isDownPressedForPlayer1, isUpPressedForPlayer2, isDownPressedForPlayer2;
        bool? wasGoingUpLastTickForPlayer1, wasGoingUpLastTickForPlayer2;
        int numberOfTickGoingInTheSameDirectionForPlayer1, numberOfTickGoingInTheSameDirectionForPlayer2;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            ProcessMove(Paddle1, isUpPressedForPlayer1, isDownPressedForPlayer1 , ref wasGoingUpLastTickForPlayer1 , ref numberOfTickGoingInTheSameDirectionForPlayer1);
            ProcessMove(Paddle2, isUpPressedForPlayer2, isDownPressedForPlayer2, ref wasGoingUpLastTickForPlayer2 , ref numberOfTickGoingInTheSameDirectionForPlayer2);
        }

        private void ProcessMove(PictureBox paddle, bool isUpPressed, bool isDownPressed, ref bool? wasGoingUp, ref int numberOfTickGoingInTheSameDirection)
        {
            bool? goingUp = null;


            if (isUpPressed)
            {
                goingUp = true;
            }
            if (isDownPressed)
            {
                if (goingUp.HasValue)
                {
                    goingUp = null;
                }
                else
                {
                    goingUp = false;
                }
            }

            if(wasGoingUp.HasValue)
            {
                if(!goingUp.HasValue)
                {
                    wasGoingUp = null;
                    numberOfTickGoingInTheSameDirection = 0;
                } else if(wasGoingUp.Value == goingUp.Value)
                {
                    numberOfTickGoingInTheSameDirection++;
                } else
                {
                    wasGoingUp = goingUp;
                    numberOfTickGoingInTheSameDirection = 1;
                }
            } else if(goingUp.HasValue)
            {
                wasGoingUp = goingUp;
                numberOfTickGoingInTheSameDirection = 1;
            }



            DoMove(paddle, goingUp , numberOfTickGoingInTheSameDirection);
        }

        private void DoMove(PictureBox paddle, bool? goingUp, int numberOfTickGoingInTheSameDirection)
        {
            if(goingUp.HasValue) {
                var speed = movementspeed * (numberOfTickGoingInTheSameDirection / 10);
                if(goingUp.Value)
                {
                    speed *= -1;
                }
                paddle.Location = new Point(paddle.Location.X,
                   Math.Max(topWorld,
                  Math.Min(bottomWorld, paddle.Location.Y + speed
                   )
                   ));
            }
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            CheckKeys(e, true);



            /*if(e.KeyCode == Keys.Up)
            {
                isUpPressed = true;
            } else if (e.KeyCode == Keys.Down)
            {
                isDownPressed = true;
            }*/


        }

        private void CheckKeys(KeyEventArgs e, bool isDown)
        {
            switch (e.KeyCode)
            {
               
                case Keys.Up:
                    isUpPressedForPlayer1 = isDown;
                    break;
                case Keys.Down:
                    isDownPressedForPlayer1 = isDown;
                    break;

                case Keys.Oemcomma:
                case Keys.W:
                    isUpPressedForPlayer2 = isDown;
                    break;
                case Keys.O:
                case Keys.S:
                    isDownPressedForPlayer2 = isDown;
                    break;


            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            CheckKeys(e, false);


            /*if (e.KeyCode == Keys.Up)
            {
                isUpPressed = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                isDownPressed = false;
            }*/
        }

    }
}
