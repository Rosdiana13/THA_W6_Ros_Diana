using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_W6_Ros_Diana
{
    public partial class Form_Player : Form
    {
        public static Form_Player instance;
        public int b;
        List<Button> buttonlist = new List<Button>();
        string jawaban;

        string kataTebakan = "";
        int counter = 0;
        int counter2 = 0;
        string[] listKatakata = File.ReadAllText("Wordle Word List.txt").Split(',');

        public Form_Player()
        {
            instance = this;
            b = Form1.instance.a;
            InitializeComponent();

            Random random = new Random();
            jawaban = listKatakata[random.Next(0, listKatakata.Length - 1)].ToUpper();
        }
        private void Form_Player_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(70, 63);
                    button.Tag = counter2.ToString();
                    button.Location = new Point(j * button.Width, i * button.Height++);
                    buttonlist.Add(button);
                    counter2++;
                }
            }
            updateButtons();
        }
        bool delete2 = false;
        bool tebakanAda = false;
        int batas = 5;
        string tebakan;
        public void ketik(string keyboard)
        {
            if (keyboard == "Enter")
            {
                // untuk cek apakah user input ada di list
                if (kataTebakan.Length >= batas)
                {
                    if (kataTebakan.Substring(batas - 5, 5) == jawaban)
                    {
                        for (int p = batas - 5; p < batas; p++)
                        {
                            Button button = buttonlist[p];
                            button.BackColor = Color.GreenYellow;
                        }
                            MessageBox.Show("Selamat anda menang");
                        this.Close();
                    }
                    else
                    {
                        for (int i = 0; i < listKatakata.Length - 1; i++)
                        {
                            if (kataTebakan.Substring(batas - 5, 5) == listKatakata[i].ToUpper())
                            {
                                //ada di list
                                tebakanAda = true;
                            }
                        }
                        if (tebakanAda == true)
                        {
                            tebakan = kataTebakan.Substring(batas - 5, 5);
                            //cek huruf tapi beda posisi // KUNING
                            for (int j = 0; j < jawaban.Length; j++)
                            {
                                if (tebakan[j] == jawaban[0] || tebakan[j] == jawaban[1] || tebakan[j] == jawaban[2] ||
                                tebakan[j] == jawaban[3] || tebakan[j] == jawaban[4])
                                {
                                    for (int p = batas - 5; p < batas; p++)
                                    {
                                        Button button = buttonlist[p];
                                        if (tebakan[j].ToString() == button.Text)
                                        {
                                            button.BackColor = Color.Yellow;
                                        }
                                    }
                                }
                            }
                            //cek huruf sama posisi // HIJAU
                            for (int i = 0; i < jawaban.Length; i++)
                            {
                                if (tebakan[i] == jawaban[i])
                                {
                                    for (int p = batas - 5; p < batas; p++)
                                    {
                                        Button button = buttonlist[p];
                                        if (button.Text == tebakan[i].ToString() && Convert.ToInt32(button.Tag)-batas+5 == i)
                                        {
                                            button.BackColor = Color.GreenYellow;
                                        }
                                    }
                                }
                            }
                            batas += 5;
                        }
                        else
                        {
                            MessageBox.Show(kataTebakan.Substring(batas - 5, 5) + " tidak di temukan");
                        }
                        tebakanAda = false;
                    }
                }
                else
                {
                    MessageBox.Show("kata belum 5 huruf");
                }

                if (batas-5 == 5*b)
                {
                    MessageBox.Show("maaf anda kalah");
                    this.Close();
                }
            }
            else if (keyboard == "Delete")
            {
                if (counter > 0 && counter > batas-5)
                {
                    kataTebakan = kataTebakan.Substring(0, kataTebakan.Length - 1);
                    counter -= 1;
                    delete2 = true;
                }
            }
            else if (counter < batas)
            {
                kataTebakan += keyboard;
                counter += 1;
            }
            updateButtons();
        }
        public void updateButtons()
        {
            //muncul button nya
            foreach (Button button in buttonlist)
            {
                int counterr = counter - 1;
                int panjangkata = kataTebakan.Length;
                if (counter > batas-5 && button.Tag.ToString() == counterr.ToString()) 
                { 
                    button.Text = kataTebakan[counter-1].ToString();
                }
                else if (delete2 == true && button.Tag.ToString() == panjangkata.ToString())
                {
                    button.Text = " ";
                    delete2 = false;
                }
                this.Controls.Add(button);
            }
        }
        private void a_Click(object sender, EventArgs e)
        {
            ketik("A");
        }
        private void s_Click(object sender, EventArgs e)
        {
            ketik("S");
        }
        private void d_Click(object sender, EventArgs e)
        {
            ketik("D");
        }
        private void f_Click(object sender, EventArgs e)
        {
            ketik("F");
        }
        private void g_Click(object sender, EventArgs e)
        {
            ketik("G");
        }
        private void h_Click(object sender, EventArgs e)
        {
            ketik("H");
        }
        private void j_Click(object sender, EventArgs e)
        {
            ketik("J");
        }
        private void k_Click(object sender, EventArgs e)
        {
            ketik("K");
        }
        private void l_Click(object sender, EventArgs e)
        {
            ketik("L");
        }
        private void q_Click(object sender, EventArgs e)
        {
            ketik("Q");
        }
        private void w_Click(object sender, EventArgs e)
        {
            ketik("W");
        }
        private void e_Click(object sender, EventArgs e)
        {
            ketik("E");
        }
        private void R_Click(object sender, EventArgs e)
        {
            ketik("R");
        }
        private void t_Click(object sender, EventArgs e)
        {
            ketik("T");
        }
        private void y_Click(object sender, EventArgs e)
        {
            ketik("Y");
        }
        private void u_Click(object sender, EventArgs e)
        {
            ketik("U");
        }
        private void i_Click(object sender, EventArgs e)
        {
            ketik("I");
        }
        private void o_Click(object sender, EventArgs e)
        {
            ketik("O");
        }
        private void p_Click(object sender, EventArgs e)
        {
            ketik("P");
        }
        private void z_Click(object sender, EventArgs e)
        {
            ketik("Z");
        }
        private void x_Click(object sender, EventArgs e)
        {
            ketik("X");
        }
        private void c_Click(object sender, EventArgs e)
        {
            ketik("C");
        }
        private void v_Click(object sender, EventArgs e)
        {
            ketik("V");
        }
        private void btn_b_Click(object sender, EventArgs e)
        {
            ketik("B");
        }

        private void n_Click(object sender, EventArgs e)
        {
            ketik("N");
        }
        private void m_Click(object sender, EventArgs e)
        {
            ketik("M");
        }
        private void enter_Click(object sender, EventArgs e)
        {
            ketik("Enter");
        }
        private void delete_Click(object sender, EventArgs e)
        {
            ketik("Delete");
        }
    }
}
