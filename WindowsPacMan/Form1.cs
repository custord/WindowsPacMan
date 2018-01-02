using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Week9_Tut_g1
{

    public partial class Form1 : Form
    {
        private const int MAXMONKEY = 12;
        private Graphics myG;
        private int scX = 500;
        private int scY = 500;
        private RoodyShip roodyShip;
        private MonkeyShip[] monkey = new MonkeyShip[MAXMONKEY];
        private int gameMode = 0;
        private int score = 0;
        private SoundPlayer soundOpening, soundGame , soundDead , soundGameover , soundEaten;
        private static int numofmonkey = 12;

        public static void setMonkey() {
            numofmonkey--;
        }

        public Form1()
        {
            InitializeComponent();
            roodyShip = new RoodyShip(scX / 2, scY - 50, 7);
            for (int k = 0; k < MAXMONKEY; k++)
                monkey[k] = new MonkeyShip((scX / (MAXMONKEY + 1) * (k + 1)), 150, 14,true);
            soundOpening = new SoundPlayer("opening.wav");
            soundGame = new SoundPlayer("gameon.wav");
            soundDead = new SoundPlayer("dead.wav");
            soundGameover = new SoundPlayer("gameover.wav");
            soundEaten = new SoundPlayer("eaten.wav");
            soundGame.PlayLooping();

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            myG = Graphics.FromHwnd(this.Handle);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            myG.FillRectangle(Brushes.Black, 0, 0, scX, scY);
            roodyShip.drawShip(myG, Brushes.Green);
                for (int k = 0; k < MAXMONKEY; k++)
                if (monkey[k].getAlive() == true)
                {
                    monkey[k].drawShip(myG, Brushes.Red);
                    
                }
            if ((gameMode == 0) | (gameMode == 2))
            {
                myG.DrawString("Press START to begin..",
                    new Font("Times", 16), Brushes.LimeGreen, 150, 200);
            }
            if (gameMode == 2)
            {
                
                myG.DrawString("G A M E  O V E R",
                    new Font("Times", 16), Brushes.LimeGreen, 170, 250);
            }
            if (gameMode == 10)
            {
                myG.DrawString("P A U S E",
                    new Font("Times", 20), Brushes.LimeGreen, 200, 230);
            }
            if (gameMode == 3)
            {
                
                myG.DrawString("Y O U  W I N!",
                    new Font("Times", 16), Brushes.Green, 180, 230);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            roodyShip.moveUp();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            roodyShip.moveDown();
        }

        private void tmrStart_Tick(object sender, EventArgs e)
        {
            for (int k = 0; k < MAXMONKEY; k++)
            {
                monkey[k].moveAway(roodyShip.getX(), roodyShip.getY());
                monkey[k].updatePos();
                monkey[k].handleBorderCollision(scX, scY);
                if (monkey[k].collideWithRoody(roodyShip.getX(), roodyShip.getY()) == true && monkey[k].getAlive())
                {
                    monkey[k].setAlive(false);
                    soundEaten.Play();

                }
            }

            lblnumofmonkey.Text = numofmonkey.ToString();
            roodyShip.updatePos();
            if (roodyShip.isBorderCollision(scX, scY))
            {
                soundDead.Play();
                gameOver();
            }
            score--;
            if (score == 0)
            {
                soundDead.Play();
                gameOver();
            }
            if (numofmonkey == 0)
                gameWin();
            labScore.Text = score.ToString();
            Refresh();
        }

        private void gameWin()
        {
            gameMode = 3;
            btnStart.Visible = true;
            tmrStart.Enabled = false;
            btnPause.Visible = false;
            soundOpening.PlayLooping();

        }

        private void gameOver()
        {
            gameMode = 2;
            btnStart.Visible = true;
            tmrStart.Enabled = false;
            btnPause.Visible = false;
            soundDead.Play();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            soundOpening.Stop();
            soundGameover.Stop();
            roodyShip.reset();
            for (int k = 0; k < MAXMONKEY; k++)
            {
                monkey[k].setAlive(true);
                monkey[k].reset();
            }
            tmrStart.Enabled = true;
            numofmonkey = 12;
            lblnumofmonkey.Text = numofmonkey.ToString();
            gameMode = 1;
            btnStart.Visible = false;
            btnPause.Visible = true;
            score = 1000;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            roodyShip.moveRight();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            roodyShip.moveLeft();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (tmrStart.Enabled == true)
            {
                tmrStart.Enabled = false;
                btnPause.Text = "CONTINUE";
                gameMode = 10;
            }
            else
            {
                tmrStart.Enabled = true;
                btnPause.Text = "PAUSE";
                gameMode = 1;
            }

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Down)
            {
                roodyShip.moveDown();
            }
            if (keyData == Keys.Up)
            {
                roodyShip.moveUp();
            }
            if (keyData == Keys.Left)
            {
                roodyShip.moveLeft();
            }
            if (keyData == Keys.Right)
            {
                roodyShip.moveRight();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRestart_Click_1(object sender, EventArgs e)
        {
            gameMode = 0;
            btnStart.Visible = true;
            tmrStart.Enabled = false;
            btnPause.Visible = false;
            
            soundGameover.Stop();
            soundGame.PlayLooping();
        }
    }
}
