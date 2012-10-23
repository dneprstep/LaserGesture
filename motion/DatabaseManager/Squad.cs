using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace TIRDatabase
{
    public class Squad
    {
        static string conStr = "Database=military_jpa;Data Source=192.168.2.1;User Id=TIR;Password=TIR2345";
        string name,id;
        List<Student> students;
        public string Name
        {
            get
            { return name; }
        }
        public string Id
        {
            get
            { return id; }
        }
        public List<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
            }
        }
        public Squad(string Name, string Id)
        {
            name = Name;
            id = Id;
        }
        public Squad(string Name, string Id,List<Student> Students)
        {
            name = Name;
            id = Id;
            students = Students;
        }
        public static bool AllSquadsToFile()
        {
            var res = true;
            try
            {
                var squadsList = new List<Squad>();//Считываем номера всех взводов
                var commandText = "SELECT ID,NAME FROM SQUAD ORDER BY ID";
                var con = new MySqlConnection(conStr);
                var com = new MySqlCommand(commandText, con);
                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    squadsList.Add(new Squad(dr.GetString(1),dr.GetString(0)));
                }
                dr.Close();
                con.Close();
                var studentsList = new List<Student>();//Считываем всех студентов
                var squadIds2=new List<string>();
                commandText = "SELECT ID,SQUAD_ID FROM STUDENT ORDER BY SQUAD_ID";
                con = new MySqlConnection(conStr);
                com = new MySqlCommand(commandText, con);
                con.Open();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    studentsList.Add(new Student(dr.GetString(0)));
                    squadIds2.Add(dr.GetString(1));
                }
                dr.Close();
                con.Close();
                commandText = "SELECT ID, NAME FROM PERSON ORDER BY ID";//Считываем все имена
                con = new MySqlConnection(conStr);
                com = new MySqlCommand(commandText, con);
                con.Open();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var id=dr.GetString(0);
                    for (int i = 0; i < studentsList.Count; i++)
                    {
                        if (studentsList[i].Id == id)
                        {
                            studentsList[i].Name = dr.GetString(1);
                        }
                    }
                }
                dr.Close();
                con.Close();
                var xml = new XDocument();
                var squads = new XElement("Squads");
                XElement squad;
                for (int i = 0; i < squadsList.Count; i++)
                {
                    if (squadsList[i].Name != "")
                    {
                        var empty = true;
                        squad = new XElement("Squad", new XAttribute("Name", squadsList[i].Name), new XAttribute("Id", squadsList[i].Id));
                        for (int i2 = 0; i2 < studentsList.Count; i2++)
                        {
                            if (squadsList[i].Id == squadIds2[i2])
                            {
                                squad.Add(new XElement("Student", new XAttribute("Name", studentsList[i2].Name), new XAttribute("Id", studentsList[i2].Id)));
                                        empty = false;                                   
                            }
                        }
                        if (!empty)
                        {
                            squads.Add(squad);
                        }
                    }
                }
                xml.Add(squads);
                xml.Save("students.xml");
            }
            catch
            {
                res = false;
            }
            return res;
        }
        public static List<Squad> GetSquads()
        {
            try
            {
                var xml = XDocument.Load("students.xml");
                return (from item in xml.Element("Squads").Elements() select new Squad(item.Attribute("Name").Value, item.Attribute("Id").Value)).ToList();
            }
            catch
            {
                return null;
            }
        }
        public static Squad GetSquad(string id)
        {
            var xml = XDocument.Load("students.xml");
            var res = (from item in xml.Element("Squads").Elements() where item.Attribute("Id").Value==id
                              select new Squad(item.Attribute("Name").Value, item.Attribute("Id").Value,
                              (from item2 in xml.Element("Squads").Elements("Squad").Elements("Student") where item2.Parent.Attribute("Id").Value == id
                               select new Student(item2.Attribute("Id").Value, item2.Attribute("Name").Value)).ToList())).ToList();
            return res[0];
        }               
    }
}
