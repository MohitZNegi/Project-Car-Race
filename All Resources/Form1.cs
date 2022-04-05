using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Resources;


namespace Project_Car_Race
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int gamespeed = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Media.SoundPlayer  player = new System.Media.SoundPlayer(Properties.Resources.car_race_sound_start);
            player.Play();

          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        int time = 0;
        int sec = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            time++;
            if (time % 10 == 0)
            {
                sec += 1;
            }
            label1.Text = "Time:" + sec;
            if (sec == 3)
            {
                yellow.Visible = true;
                yellow2.Visible = true;
                green.Visible = true;
                coin1.Visible = true;
                coin2.Visible = true;
                coin3.Visible = true;
                car_race.Visible = false;
                ready.Visible = false;
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveline(gamespeed);
            opponent(40);
            coins(gamespeed);
            coinscollection();
            gameover();


            
        }

        Random r = new Random();
        int x, y, z;

        void opponent(int speed)
        {

            if (yellow.Top >= 500)
            {
                x = r.Next(12, 310);

                if (x > 130 && x < 240)
                {
                    x = 100;
                }


                yellow.Location = new Point(x, 0);


            }
            else
            {
                yellow.Top += speed;
            }

            if (yellow2.Top >= 500)
            {
                y = r.Next(12, 310);

                if (y > 130 && y < 240)
                {
                    y = 330;
                }

                yellow2.Location = new Point(y, 0);

            }
            else
            {
                yellow2.Top += speed;
            }

            if (green.Top >= 3000)
            {
                z = r.Next(12, 300);

                if (z > 130 && z < 240)
                {
                    z = 300;
                }
                green.Location = new Point(z, 0);

            }
            else
            {
                green.Top += speed;
            }


        }

        void coins(int speed)
        {
            if (coin1.Top >= 500)
            {
                x = r.Next(12, 310);

                if (x > 130 && x < 240)
                {
                    x = 100;
                }


                coin1.Location = new Point(x, 0);


            }
            else
            {
                coin1.Top += speed;
            }

            if (coin2.Top >= 500)
            {
                y = r.Next(12, 310);

                if (y > 130 && y < 240)
                {
                    y = 270;
                }


                coin2.Location = new Point(y, 0);


            }
            else
            {
                coin2.Top += speed;
            }

            if (coin3.Top >= 500)
            {
                z = r.Next(12, 310);

                if (z > 130 && z < 240)
                {
                    z = 300;
                }


                coin3.Location = new Point(z, 0);


            }
            else
            {
                coin3.Top += speed;
            }

        }

        int coin = 0;
        void coinscollection()
        {
            if (car.Bounds.IntersectsWith(coin1.Bounds) && coin1.Visible == true)
            {
                coin++;
                label2.Text = "Coins=" + coin.ToString();
                coin1.Location = new Point(200, 100);
            }

            if (car.Bounds.IntersectsWith(coin2.Bounds) && coin2.Visible == true)
            {
                coin++;
                label2.Text = "Coins=" + coin.ToString();
                coin2.Location = new Point(300, 50);
            }

            if (car.Bounds.IntersectsWith(coin3.Bounds) && coin3.Visible == true)
            {
                coin++;
                label2.Text = "Coins=" + coin.ToString();
                coin3.Location = new Point(100, 100);
            }
        }
        void gameover()
        {


        if (car.Bounds.IntersectsWith(yellow.Bounds) && yellow.Visible == true)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.crash_sound);
                player.PlaySync();
                game_over.Visible = true;
                timer1.Enabled = false;
                timer2.Enabled = false;
                car.Visible = false;
                label5.Visible = true;

            }
        if (car.Bounds.IntersectsWith(yellow2.Bounds) && yellow2.Visible == true)
            {
                game_over.Visible = true;
                timer1.Enabled = false;
                timer2.Enabled = false;
                car.Visible = false;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.crash_sound);
                player.PlaySync();
                label5.Visible = true;
            }
        if (car.Bounds.IntersectsWith(green.Bounds) && green.Visible == true)
            {
                game_over.Visible = true;
                timer1.Enabled = false;
                timer2.Enabled = false;
                car.Visible = false;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.crash_sound);
                player.PlaySync();
                label5.Visible = true;
            }
            
       
        }

    void moveline(int speed)
        {

             if (pictureBox1.Top >= 495)
             {
                 pictureBox1.Top = 0;
             }
             else
             {
                 pictureBox1.Top += speed;
             }

             if (pictureBox2.Top >= 495)
             {
                 pictureBox2.Top = 0;
             }
             else
             { pictureBox2.Top += speed; }

             if (pictureBox3.Top == 495)
             {
                 pictureBox3.Top = 0;
             }
             else
             { pictureBox3.Top += speed; }

             if (pictureBox4.Top >= 495)
             {
                 pictureBox4.Top = 0;
             }
             else
             { pictureBox4.Top += speed; }

        }

        private void car_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
         

            if (e.KeyCode == Keys.Left)
            {
                if (car.Left > 0)
                car.Left += -8; 
            }
            if (e.KeyCode == Keys.Right)
            {
                if (car.Right < 380)
                car.Left += 8; 
            }
            if (e.KeyCode == Keys.Up)
            {
               

                if (gamespeed < 80)

                { 
                    gamespeed++;
                   
                }

                if (gamespeed ==10  && sec >= 4)
                {

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.speed_sound);
                    player.PlayLooping();

                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (gamespeed > 0)

                { gamespeed--; }

                if (gamespeed == 0 && sec >= 4)
                {

                    System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(Properties.Resources.speed_sound);
                    player1.Stop();

                }

            }
            if (e.KeyCode == Keys.Space)
            {
                
                Form1 form = new Form1();
                form.Show();
                this.Hide();
                

            }
            label4.Text = "Speed=" + gamespeed + "km/h";

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}
