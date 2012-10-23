using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace TIRDatabase
{
    public class Teacher
    {
        static string conStr = "Database=military_jpa;Data Source=192.168.2.1;User Id=TIR;Password=TIR2345";
        string name, id;
        public string Name
        {
            get { return name; }
        }
        public string Id
        {
            get { return id; }
        }
        public Teacher(string Name, string Id)
        {
            name = Name;
            id = Id;
        }
        public static List<Teacher> GetTeachers()
        {
            try
            {
                var xml = XDocument.Load("teachers.xml");
                return (from item in xml.Element("Teachers").Elements() select new Teacher(item.Attribute("Name").Value, item.Attribute("Id").Value)).ToList();
            }
            catch
            {
                return null;
            }
        }
        public static bool AllTeachersToFile()
        {
            bool res = true;
            try
            {
                var teachersList = new List<Teacher>();
                var commandText = "select t.ID, p.NAME from TEACHER t left join PERSON p on t.ID=p.ID";
                var con = new MySqlConnection(conStr);
                var com = new MySqlCommand(commandText, con);
                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    teachersList.Add(new Teacher(dr.GetString(1), dr.GetString(0)));
                }
                dr.Close();
                con.Close();
                var xml = new XDocument();
                var teachers = new XElement("Teachers");
                for (int i = 0; i < teachersList.Count; i++)
                {
                    teachers.Add(new XElement("Teacher",new XAttribute("Name",teachersList[i].Name),new XAttribute("Id",teachersList[i].Id)));
                }
                xml.Add(teachers);
                xml.Save("teachers.xml");
            }
            catch
            {
                res = false;
            }
            return res;
        }
    }
}
