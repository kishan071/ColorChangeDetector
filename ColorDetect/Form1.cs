using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorDetect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        public Color startingColor;
        SoundPlayer soundPlayer;
        Bitmap snapshot;
        public string X_Cordinate
        {
            get
            {
                return this.x_cor.Text;
            }
            set
            {
                this.x_cor.Text = value;
            }
        }

        public string Y_Cordinate
        {
            get
            {
                return this.y_cor.Text;
            }
            set
            {
                this.y_cor.Text = value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            soundPlayer = new SoundPlayer();
        }        

        private void timer1_Tick(object sender, EventArgs e)
        {
            checkForColorDifference();
        }

        public Color GetPixelColor(int x, int y)
        {
            snapshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);

            using (Graphics gph = Graphics.FromImage(snapshot))
            {
                gph.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            }

            return snapshot.GetPixel(x, y);
        }

        public void checkForColorDifference()
        {
            Color currentColor = GetPixelColor(int.Parse(x_cor.Text), int.Parse(y_cor.Text));
            snapshot?.Dispose();
            if (currentColor== Color.FromArgb(255,255,0,0))
            {
                timer1.Enabled = false;
                soundPlayer.Play();
                startingColor = currentColor;
                timer1.Enabled = true;
            }
            else
            {
                try
                {
                    soundPlayer.Stop();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            checkForColorDifference();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            this.Hide();
            getcords gt = new getcords();
            gt.Show();
        }        

        private void button2_Click(object sender, EventArgs e)
        {    
            if(soundPlayer.SoundLocation!=null)
                timer1.Enabled = true;
            else
                MessageBox.Show("Please Select A Sound 1st !");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.DefaultExt = ".png";
            openFileDialog1.Filter = "Wave Files (*.wav)|*.wav";
            openFileDialog1.ShowDialog();
            soundPlayer.SoundLocation = openFileDialog1.FileName;
            
        }
    }
}
