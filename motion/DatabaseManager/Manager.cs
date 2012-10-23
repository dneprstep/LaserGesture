using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TIRDatabase
{
    public partial class Manager : Form
    {
        Datamanager DM;
        List<Squad> squads;
        List<Teacher> teachers;
        public Manager(Datamanager dm)
        {
            InitializeComponent();
            DM = dm;
            FillComboBoxes(11);
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Squad.AllSquadsToFile();
            Teacher.AllTeachersToFile();
            Squad.GetSquads();
            Teacher.GetTeachers();
            FillComboBoxes(10);
        }

        void FillComboBoxes(int what)
        {
            if (what/10 == 1)
            {
                var t = new DataTable("Squad");
                t.Columns.Add("Name", typeof(string));
                t.Columns.Add("Id", typeof(string));
                SelectedSquad.DataBindings.Clear();
                SelectedTeacher.DataBindings.Clear();
                squads = Squad.GetSquads();
                for (int i = 0; i < (squads == null ? 0 : squads.Count); i++)
                {
                    var o = new object[2];
                    o[0] = squads[i].Name;
                    o[1] = squads[i].Id;
                    t.Rows.Add(o);
                }
                SelectedSquad.DataSource = t;
                SelectedSquad.DisplayMember = "Name";
                SelectedSquad.ValueMember = "Id";
                SelectedSquad.SelectionStart = 0;
                teachers = Teacher.GetTeachers();
                t = new DataTable("Teacher");
                t.Columns.Add("Name", typeof(string));
                t.Columns.Add("Id", typeof(string));
                for (int i = 0; i < (teachers == null ? 0 : teachers.Count); i++)
                {
                    var o = new object[2];
                    o[0] = teachers[i].Name;
                    o[1] = teachers[i].Id;
                    t.Rows.Add(o);
                }
                SelectedTeacher.DataSource = t;
                SelectedTeacher.ValueMember = "Id";
                SelectedTeacher.DisplayMember = "Name";
                SelectedTeacher.SelectionStart = 0;
            }
            if (what % 10 == 1)
            {
                SelectedFiretake.Items.Clear();
                var firetakes = Firetake.GetFiretakes();
                for (int i = 0; i < firetakes.Count; i++)
                {
                    SelectedFiretake.Items.Add(firetakes[i]);
                }
                if (firetakes.Count > 0)
                SelectedFiretake.SelectedIndex = 0;
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            try
            {
                DM.firetake = new Firetake(new Teacher(SelectedTeacher.Text, SelectedTeacher.SelectedValue.ToString()),
                                            Squad.GetSquad(SelectedSquad.SelectedValue.ToString()));
                this.Close();
            }
            catch { }
        }

        private void WriteToBase_Click(object sender, EventArgs e)
        {
            if(SelectedFiretake.Items.Count>0)
            {
                Firetake.ToBase(SelectedFiretake.SelectedIndex.ToString());
            }
            FillComboBoxes(1);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Firetake.Delete(SelectedFiretake.SelectedIndex);
            FillComboBoxes(1);
        }
    }
}
