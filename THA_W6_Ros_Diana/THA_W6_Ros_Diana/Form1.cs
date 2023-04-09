using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_W6_Ros_Diana
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public int a;
        public Form1()
        {
            InitializeComponent();
            instance = this;
           
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt16(this.textBoxForm1.Text);
            if (a < 3)
            {
                MessageBox.Show("please input more than or equal to 3");
            }
            else
            {
                Form_Player form2 = new Form_Player();
                form2.b = a;
                form2.Show();
            }
        }
    }
}
