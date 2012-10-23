using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using System.Xml;

namespace TIRDatabase
{
    public static class Results
    {
        static string conStr = "Database=military_jpa;Data Source=192.168.2.1;User Id=TIR;Password=TIR2345";
        public static bool GetAllStudents()
        {
            var res = true;
            try
            {
                var squadNums = new List<string>();//Считываем номера всех взводов
                var squadIds = new List<string>();
                var commandText = "SELECT ID,NAME FROM SQUAD ORDER BY ID";
                var con = new MySqlConnection(conStr);
                var com = new MySqlCommand(commandText, con);
                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    squadNums.Add(dr.GetString(1));
                    squadIds.Add(dr.GetString(0));
                }
                dr.Close();
                con.Close();
                var studentIds = new List<string>();//Считываем всех студентов
                var squadIds2 = new List<string>();
                commandText = "SELECT ID,SQUAD_ID FROM STUDENT ORDER BY SQUAD_ID";
                con = new MySqlConnection(conStr);
                com = new MySqlCommand(commandText, con);
                con.Open();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    studentIds.Add(dr.GetString(0));
                    squadIds2.Add(dr.GetString(1));
                }
                dr.Close();
                con.Close();
                var ids = new List<string>();//Считываем все имена
                var names = new List<string>();
                commandText = "SELECT ID, NAME FROM PERSON ORDER BY ID";
                con = new MySqlConnection(conStr);
                com = new MySqlCommand(commandText, con);
                con.Open();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    ids.Add(dr.GetString(0));
                    names.Add(dr.GetString(1));
                }
                dr.Close();
                con.Close();
                var xml = new XDocument();
                var squads = new XElement("Squads");
                XElement squad;
                for (int i = 0; i < squadNums.Count; i++)
                {
                    if (squadNums[i] != "")
                    {
                        var empty = true;
                        squad = new XElement("Squad", new XAttribute("Number", squadNums[i]), new XAttribute("Id", squadIds[i]));
                        for (int i2 = 0; i2 < studentIds.Count; i2++)
                        {
                            if (squadIds[i] == squadIds2[i2])
                            {
                                for (int i3 = 0; i3 < names.Count; i3++)
                                {
                                    if (studentIds[i2] == ids[i3])
                                    {
                                        squad.Add(new XElement("Student", new XAttribute("Name", names[i3]), new XAttribute("Id", studentIds[i2])));
                                        empty = false;
                                    }
                                }
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
        public static List<string> GetSquads()
        {
            var res = new List<string>();
            var xml = XDocument.Load("students.xml");
            return (from item in xml.Element("Squads").Elements() select item.Element("Squad").Attribute("Number").Value).ToList();
        }
    }
}
