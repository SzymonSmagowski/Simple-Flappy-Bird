using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int points = 0;
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void GameTimerEvenet(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            score.Text = "Score: "+points;
            pipeSpeed = 8 + points / 2;
            Random rand = new();
            int rng = rand.Next(200) + 200;
            if (pipeBottom.Left < -100)
            {
                pipeBottom.Left = 800;
                pipeBottom.Height = rng;
                points++;
            }
            if (pipeTop.Left < -100)
            {
                pipeTop.Left = 800;
                //int x = pipeTop.Location.X;
                //int y = pipeTop.Location.Y;
                //pipeTop.Location = new Point(x, y+rng);
                //pipeTop.Height = 681 - (y + rng);
                points++;
            }
            if (bird.Bounds.IntersectsWith(pipeBottom.Bounds)||
                bird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                bird.Bounds.IntersectsWith(ground.Bounds)||
                bird.Top <-25)
            {
                Endgame();
            }
        }

        private void GameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void GameKeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void Endgame()
        {
            gameTimer.Stop();
            score.Text += " Game over!!!";
        }
    }
}
