using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorDetect
{
    public partial class getcords : Form
    {
        public getcords()
        {
            InitializeComponent();
        }

        Form1 main = new Form1();        

        private void getcords_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            this.MouseDown += new MouseEventHandler(Loop_MouseDown);
        }
        private void Loop_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            this.Hide();
            main.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            main.X_Cordinate = Cursor.Position.X.ToString();
            main.Y_Cordinate = Cursor.Position.Y.ToString();
        }
    }
}
