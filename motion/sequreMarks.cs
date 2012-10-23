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
    public partial class sequreMarks : Form
    {
        public sequreMarks()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            next();
        }
        
        private void next()
        {
            if (System.IO.File.Exists("C:\\Program Files\\LazerShot\\ust.tir"))
            {
                string addres = "C:\\Program Files\\LazerShot\\ust.tir";
                System.IO.StreamReader str = new System.IO.StreamReader(addres);
                string s = str.ReadToEnd();

                string kontrol = string.Format("#"+PassCodet()+".");

                string[] ss = s.Split('/'); 

                str.Close();
                if (ss[1].Equals(kontrol))
                {
                    panel1.Visible = true;
                    panel1.Location = new Point(0, 0);
                }
                else
                {
                    MessageBox.Show("Невірний пароль, доступ заборонено");
                    textBox1.Text = "";
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
                next();
        }

        private void Cansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            int p1;
            int p2;
            int p3;
            int p4;
            int p5;
            
            try
            {
                string s = "fail";
                p1 = int.Parse(ShotNumber.Text);
                if (p1 < 1)
                {
                    ShotNumber.Text = s;
                    p1 = int.Parse(ShotNumber.Text);
                }

                p2 = int.Parse(onFive.Text);
                if (p2 < 0)
                {
                    onFive.Text = s;
                    p2 = int.Parse(onFive.Text);
                }

                p3 = int.Parse(onFor.Text);
                if ((p3 < 0)||(p3>p2))
                {
                    onFor.Text = s;
                    p3 = int.Parse(onFor.Text);
                }

                p4 = int.Parse(onthee.Text);
                if ((p4 < 0)||(p4>p3))
                {
                    onthee.Text = s;
                    p4 = int.Parse(onthee.Text);
                }

                p5 = int.Parse(ontwo.Text);
                if ((p5 < 0)||(p5>p4))
                {
                    ontwo.Text = s;
                    p5 = int.Parse(ontwo.Text);
                }

                if (System.IO.File.Exists("C:\\Program Files\\LazerShot\\pass.tir"))
                {
                     string addres = "C:\\Program Files\\LazerShot\\pass.tir";
                     string rez = string.Format( (char)p1 + "." + (char)p2 + "." + (char)p3 + "." + (char)p4 + "." + (char)p5);

                     System.IO.File.Delete(addres);
                     System.IO.StreamWriter str1 = new System.IO.StreamWriter(addres);
                     str1.Write(rez);
                     str1.Close();
                     this.Close();
                }
            }
            catch
            { MessageBox.Show("Невірно заповнені поля!"); }
        }

        private void sequreMarks_Load(object sender, EventArgs e)
        {
            try
            {
            string addres = "C:\\Program Files\\LazerShot\\pass.tir";
            System.IO.StreamReader str = new System.IO.StreamReader(addres);
            string strn = str.ReadToEnd();
            str.Close();

            char[] ss1 = strn.ToCharArray();
            
                ShotNumber.Text = string.Format("{0}", (int)ss1[0]);
                onFive.Text = string.Format("{0}", (int)ss1[2]);
                onFor.Text = string.Format("{0}", (int)ss1[4]);
                onthee.Text = string.Format("{0}", (int)ss1[6]);
                ontwo.Text = string.Format("{0}", (int)ss1[8]);
            }
            catch
            {
                MessageBox.Show("Файл оцінювання пошкоджено або видалено користувачем. Відновлення попередньо заданих оцінок неможливо. Система автоматично скине всі налаштування до стандартних");
                string pass = ".#...";
                System.IO.StreamWriter str1 = new System.IO.StreamWriter("C:\\Program Files\\LazerShot\\pass.tir");
                str1.Write(pass);
                str1.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangePass f = new ChangePass();
            f.ShowDialog();
        }

        private string PassCodet()
        {
            char[] charItems = textBox1.Text.ToCharArray();
            string rezalt="";

            for (int i = 0; i < charItems.Length; i++)
            {
                string temp = string.Format(rezalt);
                if (i!=charItems.Length-1)
                    rezalt = string.Format(temp+"{0}.",charItems[i]*2-1);
                else
                    rezalt = string.Format(temp + "{0}", charItems[i]*2-1);
            }
            return rezalt;
        }
    }
       
}
