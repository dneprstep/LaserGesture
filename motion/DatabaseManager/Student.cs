using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIRDatabase
{
    public class Student
    { 
        string id, name, mark, score;
        public string Id
        {
            get 
            {
                return id; 
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
            }
        }
        public string Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
        public Student(string Id)
        {
            id = Id;
        }
        public Student(string Id, string Name)
        {
            id = Id;
            name = Name;
        }
    }
}
