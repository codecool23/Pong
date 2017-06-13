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
        
        Player player1, player2;
        Ball ball;


       
        public Form1()
        {
            InitializeComponent();

            player1 = new Player(Paddle1, labelPlayer1);
            player2 = new Player(Paddle2, labelPlayer2);
            ball = new Ball(Ball, player1, player2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            player1.ProcessMove();
            player2.ProcessMove();
            ball.ProcessMove();
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
                    player1.isUpPressed = isDown;
                    break;
                case Keys.Down:
                    player1.isDownPressed = isDown;
                    break;

                case Keys.Oemcomma:
                case Keys.W:
                    player2.isUpPressed = isDown;
                    break;
                case Keys.O:
                case Keys.S:
                    player2.isDownPressed = isDown;
                    break;


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
