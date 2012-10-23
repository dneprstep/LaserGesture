using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace TIRDatabase
{
    public class Firetake
    {
        DateTime date;
        static string conStr = "Database=military_jpa;Data Source=192.168.2.1;User Id=TIR;Password=TIR2345";
        Squad squad;
        Teacher teacher;
        public bool saved = false;
        public DateTime Date
        {
            get { return date; }
        }
        public Squad Squad
        {
            get { return squad; }
        }
        public Teacher Teacher
        {
            get { return teacher; }
        }
        public Firetake(Teacher t, Squad s)
        {
            date = DateTime.Now;
            teacher = t;
            squad = s;
        }
        /*  public static Firetake GetFiretake(string firetakeId)
          {
              Firetake res = null;
              return res;
          }*/
        public static List<String> GetFiretakes()
        {
            XDocument doc;
            try
            {
                doc = XDocument.Load("firetakes.xml");
                return (from item in doc.Element("Firetakes").Elements() select item.Attribute("Time").Value + " " + item.Attribute("TeacherName").Value + " взвод №" + item.Attribute("SquadName").Value).ToList();
            }
            catch
            {
                return new List<String>();
            }
        }
        public bool ToFile()
        {
            var res = true;
            if (!saved)
            {
                XDocument doc;
                try
                {
                    doc = XDocument.Load("firetakes.xml");
                }
                catch
                {
                    doc = new XDocument();
                    doc.Add(new XElement("Firetakes"));
                }
                var newFiretake = new XElement("Firetake");
                newFiretake.Add(new XAttribute("Time", date.ToString("yyyy.MM.dd HH:mm:ss")), new XAttribute("Squad", squad.Id), new XAttribute("Teacher", teacher.Id),
                    new XAttribute("SquadName", squad.Name), new XAttribute("TeacherName", teacher.Name));
                for (int i = 0; i < squad.Students.Count; i++)
                {
                    if (squad.Students[i].Score != null)
                        newFiretake.Add(new XElement("Student", new XAttribute("Id", squad.Students[i].Id), new XAttribute("Mark", squad.Students[i].Mark), new XAttribute("Score", squad.Students[i].Score), new XAttribute("StudentName", squad.Students[i].Name)));
                }
                doc.Element("Firetakes").Add(newFiretake);
                try
                {
                    doc.Save("firetakes.xml");
                }
                catch
                {
                    res = false;
                }
                saved = true;
            }
            return res;
        }
        public static bool ToBase(string firetakeNumber)
        {
            var res = true;
            var xml = XDocument.Load("firetakes.xml");
            var node = xml.Element("Firetakes").Element("Firetake");
            var progress = new Progress();
            progress.Show();
            progress.SetBarSize(node.Elements().Count<XElement>()+1);
            try
            {
                progress.Focus();
                for (int i = 0; i < int.Parse(firetakeNumber); i++)
                {
                    node = node.NextNode as XElement;
                }
                foreach (XElement student in node.Elements())
                {
                    var commandText = "INSERT INTO FIRETAKE(DATETAKEN,STATUS,GRADE,COMMENT,DELETED,STUDENT_ID,TEACHER_ID,SCORE) VALUES('" +
                        node.Attribute("Time").Value + "',0," + student.Attribute("Mark").Value + ",'',0," + student.Attribute("Id").Value + "," +
                        node.Attribute("Teacher").Value + "," + student.Attribute("Score").Value + ")";
                    var con = new MySqlConnection(conStr);
                    var com = new MySqlCommand(commandText, con);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    progress.Increment();                    
                    System.Threading.Thread.Sleep(200);
                }
            node.Remove();
            xml.Save("firetakes.xml");
            }
            catch
            {
                res = false;
            }
            progress.Close();
            return res;
        }
        public static void Delete(int x)
        {
            try
            {
                var doc = XDocument.Load("firetakes.xml");
                var node = doc.Element("Firetakes").Element("Firetake");
                for (int i = 0; i < x; i++)
                {
                    node = node.NextNode as XElement;
                }
                if (x > -1)
                {
                    node.Remove();
                    doc.Save("firetakes.xml");
                }
            }
            catch { }
        }
    }
}
