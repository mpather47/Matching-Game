/*MatchingGame
 * Author: Marcell Pather 2A (217053947)
 * Date: 20 March 2019
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace MatchingGame
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            //This code runs the second Form first
            Thread t = new Thread(new ThreadStart(MatchingGame));
            
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
            
        }
        public void MatchingGame()
        {
            
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
           
        }
        
        List<Button> buttons = new List<Button>();
        String[] arr = new String[] { "Card1.png", "Card1.png", "Card2.png", "Card2.png", "Card3.png",
                "Card3.png", "Card4.png", "Card4.png","Card5.png", "Card5.png", "Card6.png", "Card6.png",
                "Card7.png", "Card7.png", "Card8.png", "Card8.png" , "Card9.png", "Card9.png", "Card10.png",
                "Card10.png", "Card11.png", "Card11.png", "Card12.png", "Card12.png" ,
                "Card13.png", "Card13.png", "Card14.png", "Card14.png", "Card15.png",
                "Card15.png", "Card16.png", "Card16.png", "Card17.png", "Card17.png" ,
                "Card18.png", "Card18.png", "Card19.png", "Card19.png", "Card20.png"  ,
                "Card20.png", "Card11.png", "Card11.png", "Card12.png", "Card12.png" ,
                "Card13.png", "Card13.png", "Card14.png", "Card14.png", "Card15.png",
                "Card15.png", "Card16.png", "Card16.png", "Card17.png", "Card17.png"  ,
                "Card18.png", "Card18.png", "Card19.png", "Card19.png", "Card20.png",
                "Card20.png", "Card4.png", "Card4.png","Card5.png", "Card5.png"};
        int n = 12;
        PictureBox[] Shapes ;
        PictureBox pendingImage1;
        PictureBox pendingImage2;
        int[] Tag = new int[] { 1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,
                                9,9,10,10,11,11,12,12,13,13,14,14,
                                15,15,16,16,17,17,18,18,19,19,20,20,11,11,
                                12,12,13,13,14,14,15,15,16,16,17,17,
                                18,18,19,19,20,20,4,4,5,5};
        Random random1 = new Random();
        Panel dynamicPanel = new Panel();
        int y = 0;
        int x = 0;
        int counter = 0;
        int score = 0;
        string text = "Level 1";

        private void Form1_Load(object sender, EventArgs e)
        {

            dynamicPanel.BackColor = Color.Yellow;
        
            timer1.Start();
            Controls.Add(dynamicPanel);
            Shapes = new PictureBox[n];
            //this loop srambles up the picturs
            for (int i = 0; i < Shapes.Length; i++)
            {
                
                random(i);
               
            }
            //this loop displays the scrambled up pictures
            for (int i = 0; i < Shapes.Length; i++)
            {
                display(i);
            }
           
            //resizes image to apporopriate size 
            foreach (PictureBox picture in dynamicPanel.Controls)
            {
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.Cursor = Cursors.Hand;
            }
        }
        /*This method adds the pictur files into an array and formats the images so it can
        be displayed in formated rows and columns*/
        #region Display
        public void display(int i)
        {

            Shapes[i] = new PictureBox();
            Shapes[i].Name = "Picture" + i.ToString();
            Shapes[i].Size = new Size(100, 120);
           
            Shapes[i].Image = Image.FromFile(Application.StartupPath + "\\Cards\\" + arr[i]);
            Shapes[i].Visible = true;
            Shapes[i].Tag = Tag[i];
            Shapes[i].Enabled = false;

            dynamicPanel.Controls.Add(Shapes[i]);
            dynamicPanel.Size = new System.Drawing.Size(1900, 1000);
            int n = i;
            Shapes[i].Click += (object s, EventArgs ea) => ChangeImage(n);
            x = x + 100;

            if (i == 0)
            {
                x = 100;
                y = 50;
                if (Shapes.Length == 12)
                {
                    x = 400;
                }else if (Shapes.Length == 24)
                {
                    x = 250;
                }
                else if (Shapes.Length == 32)
                {
                    x = 90;
                }
                else if (Shapes.Length == 48|| Shapes.Length == 64)
                {
                    x = 80;
                    y = 30;
                }
                
            }
          

            if (Shapes.Length == 12)
            {
                if (i == 3 || i == 6||i==9)
                {
                    y += 120;
                    x = 400;

                }

            }

            else if (Shapes.Length == 24)
            {

                if (i == 6 || i == 12 || i == 18)
                {
                    y += 120;
                    x = 250;

                }

            }
            else if (Shapes.Length == 32)
            {

                if (i == 8 || i == 16 || i == 24)
                {
                    y += 120;
                    x = 90;

                }

            }
            else if (Shapes.Length == 48)
            {

                if (i == 8 || i == 16 || i == 24||i==32||i==40)
                {
                    y += 100;
                    x = 80;
                    
                }

            }
            else if (Shapes.Length == 64)
            {

                if (i == 8 || i == 16 || i == 24 || i == 32 || i == 40||i==48|i==56)
                {
                   
                    y += 90;
                    x = 80;
              
                }

            }
            Shapes[i].Location = new Point(x, y);

           
            
        }
        #endregion
        /*This method uses a random sorting algorithm which scrambles up the images in the 
         * array
         */
        #region Random Pictures
        public void random(int i)
        {
            int k = random1.Next(Shapes.Length);
            String value = arr[k];
            arr[k] = arr[i];
            arr[i] = value;

            int value2 = Tag[k];
            Tag[k] = Tag[i];
            Tag[i] = value2;
        }
        #endregion
        /*This method checks if you click on a picture and matches images of the same type.
         * It keeps track of the amount of mistakes you do.
         */
        #region Change Images
        void ChangeImage(int index)
        {
            
            timer3.Start();
           
            // Process the panel clicks here
            Shapes[index].Image = Image.FromFile(Application.StartupPath+"\\Cards\\" + arr[index]);
            if (pendingImage1==null)
            {
                pendingImage1 = Shapes[index];
               pendingImage1.Enabled = false;

            }else if (pendingImage1 !=null && pendingImage2 ==null)
            {
                pendingImage2 = Shapes[index];
                pendingImage2.Enabled = false;
            }

            if (pendingImage1 != null && pendingImage2 != null)
            {
                if ((int)pendingImage1.Tag == (int)pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    counter++;
                    
                }
                else
                {
                    timer2.Start();
                    score += 10;
                    label2.Text = Convert.ToString(score);
                    pendingImage1.Enabled = true;
                    pendingImage2.Enabled = true;
                }
            }
             
           
        }
        #endregion
       
        #region Timers
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            timer1.Stop();
           
            //if three seconds has passed it hides the pictures
            for (int i = 0; i < Shapes.Length; i++)
            {
                Shapes[i].Enabled = true;
                Shapes[i].Image = Image.FromFile(Application.StartupPath+ "\\Cards\\Cover.png");

            }
        }
        //if the two pictures clicked doesnt match it hides the pictures
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            pendingImage1.Image = Image.FromFile(Application.StartupPath + "\\Cards\\Cover.png");
            pendingImage2.Image = Image.FromFile(Application.StartupPath + "\\Cards\\Cover.png");
            pendingImage1 = null;
            pendingImage2 = null;
        }
        /*this method keeps track of the time in the game and also checks if 
          all the images are matched to stop the time from incrementing
          */

        private void timer3_Tick(object sender, EventArgs e)
        {
            int timer = Convert.ToInt32(label4.Text);
            timer = timer -1;
            label4.Text = Convert.ToString(timer);
            if (counter==(n/2) )
            {
                timer3.Stop();
               
                MessageBox.Show("You Win!");
                
                foreach (PictureBox picture in dynamicPanel.Controls)
                {
                    picture.Enabled = false;
                }
                
            }
            else
            if (timer ==0)
            {
                timer3.Stop();
                MessageBox.Show("You Lose!");
                foreach (PictureBox picture in dynamicPanel.Controls)
                {
                    picture.Enabled = false;
                }
                
               
            }
           
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
           
            counter = 0;
            for (int j = 0; j < Shapes.Length; j++)
            {
                Shapes[j].Image = null;
                dynamicPanel.Controls.Remove(Shapes[j]);
            }
            Controls.Add(dynamicPanel);
            text = comboBox1.SelectedItem.ToString();

            switch (text)
            {
                case "Level 1":
                    timer3.Stop();
                    score = 0;
                    label4.Text = Convert.ToString("30");
                    label2.Text = Convert.ToString("0");
                    n = 12;
                    Shapes = new PictureBox[n];
                    
                    timer1.Start();
                    for (int i = 0; i < Shapes.Length; i++)
                    {
                        random(i);

                    }
                    for (int i = 0; i < Shapes.Length; i++)
                    {

                        display(i);
                    }
                    break;
                case "Level 2":
                    timer3.Stop();
                    score = 0;
                    label4.Text = Convert.ToString("40");
                    label2.Text = Convert.ToString("0");
                    n = 24;
                    Shapes = new PictureBox[n];
                    timer1.Start();
                    
                    for (int i = 0; i < Shapes.Length; i++)
                    {
                        random(i);
                        
                    }
                    for (int i = 0; i < Shapes.Length; i++)
                    {
                        
                        display(i);
                    }
                    break;
                case "Level 3":
                    score = 0;
                    timer3.Stop();
                    label4.Text = Convert.ToString("50");
                    label2.Text = Convert.ToString("0");
                    n = 32;
                    Shapes = new PictureBox[n];
                    timer1.Start();

                    for (int i = 0; i < Shapes.Length; i++)
                    {
                        random(i);

                    }
                    for (int i = 0; i < Shapes.Length; i++)
                    {

                        display(i);
                    }
                    break;
                case "Level 4":
                    score = 0;
                    timer3.Stop();
                    label4.Text = Convert.ToString("75");
                    label2.Text = Convert.ToString("0");
                    n = 48;
                    Shapes = new PictureBox[n];
                    timer1.Start();
                    for (int i = 0; i < Shapes.Length; i++)
                    {
                        random(i);

                    }
                    for (int i = 0; i < Shapes.Length; i++)
                    {

                        display(i);
                        Shapes[i].Size = new Size(80, 100);
                    }
                 
                    break;
                case "Level 5":
                    score = 0;
                    timer3.Stop();
                    label4.Text = Convert.ToString("90");
                    label2.Text = Convert.ToString("0");
                    n = 64;
                    Shapes = new PictureBox[n];
                    timer1.Start();
                    for (int i = 0; i < Shapes.Length; i++)
                    {
                        random(i);

                    }
                    for (int i = 0; i < Shapes.Length; i++)
                    {

                        display(i);
                        Shapes[i].Size = new Size(80, 80);
                    }
                   
                    break;
            }
          


            foreach (PictureBox picture in dynamicPanel.Controls)
            {
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.Cursor = Cursors.Hand;
            }
        }

        
    }
        
}
