using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace motion
{
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Text = textBox1r.Text;
                textBox2.Text = textBox2r.Text;
            }
            if (textBox1.Text.Equals(textBox2.Text))
            {
                System.IO.StreamReader str = new System.IO.StreamReader("C:\\Program Files\\LazerShot\\ust.tir");
                string s = str.ReadToEnd();
                str.Close();
                string[] ss = s.Split('/');
                string pass = PassCodet();
                string rez = string.Format(ss[0]+"/#"+pass+".");
                System.IO.File.Delete("C:\\Program Files\\LazerShot\\ust.tir");
                System.IO.StreamWriter strw = new System.IO.StreamWriter("C:\\Program Files\\LazerShot\\ust.tir");
                strw.Write(rez);
                strw.Close();
                MessageBox.Show("Пароль змінено");
                this.Close();
            }
            else
                MessageBox.Show("Паролі не співпадають");
        }
        private string PassCodet()
        {
            char[] charItems = textBox1.Text.ToCharArray();
            string rezalt = "";

            for (int i = 0; i < charItems.Length; i++)
            {
                string temp = string.Format(rezalt);
                if (i != charItems.Length - 1)
                    rezalt = string.Format(temp + "{0}.", charItems[i] * 2 - 1);
                else
                    rezalt = string.Format(temp + "{0}", charItems[i] * 2 - 1);
            }
            return rezalt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 5)
            {
                label1.ForeColor = Color.LimeGreen;
            }
            else
                label1.ForeColor = Color.White;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text.Equals(textBox2.Text))&&(textBox1.Text.Length>5))
            {
                label2.ForeColor = Color.LimeGreen;
                button1.Enabled = true;
            }
            else
            {
                label2.ForeColor = Color.Red;
                button1.Enabled = false;
            }
        }

        private void vievSumbol()
        {
            if (checkBox1.Checked)
            {
                textBox1.Visible = textBox2.Visible = false;

                textBox1r.Location = textBox1.Location;
                textBox2r.Location = textBox2.Location;

                textBox1r.Visible = textBox2r.Visible = true;

                textBox1r.Text = textBox1.Text;
                textBox2r.Text = textBox2.Text;
            }
            else 
            {
                textBox1.Visible = textBox2.Visible = true;

                textBox1r.Visible = textBox2r.Visible = false;

                textBox1.Text = textBox1r.Text;
                textBox2.Text = textBox2r.Text;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            vievSumbol();
        }

        private void textBox1r_TextChanged(object sender, EventArgs e)
        {
            if (textBox1r.Text.Length > 5)
            {
                label1.ForeColor = Color.LimeGreen;
            }
            else
                label1.ForeColor = Color.White;
        }

        private void textBox2r_TextChanged(object sender, EventArgs e)
        {
            if (textBox1r.Text.Equals(textBox2r.Text))
            {
                label2.ForeColor = Color.LimeGreen;
                button1.Enabled = true;
            }
            else
            {
                if (textBox2r.Text.Length > 5)
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.White;
                button1.Enabled = false;
            }
        }
       
    }
}
