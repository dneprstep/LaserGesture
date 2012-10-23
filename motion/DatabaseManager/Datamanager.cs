using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIRDatabase
{
    public class Datamanager
    {
        public Firetake firetake;
        Manager M;
        protected int CurrStud;
        public Datamanager()
        {

        }
        public bool NextStudent()
        {
            if (CurrStud == firetake.Squad.Students.Count)
            {
                firetake.ToFile();
                CurrStud = 0;
                return false;
            }
            else
            {
                CurrStud++;
                return true;
            }
        }
        public void EndFiretake()
        {
            firetake.ToFile();
            CurrStud = 0;
        }
        public void Show()
        { 
            M = new Manager(this);
            M.Show();
            M.Focus();
        }
        public void Hide()
        {
            M.Close();
        }
        public string GetCurrStudentName()
        {
            if (firetake!=null&&CurrStud  < firetake.Squad.Students.Count)
                return firetake.Squad.Students[CurrStud].Name;
            else
                return null;
        }
        public void SetMark(int m, int n)
        {
            if (firetake != null && !firetake.saved && CurrStud<firetake.Squad.Students.Count)
            {
                if (firetake != null)
                {
                    firetake.Squad.Students[CurrStud].Mark = m.ToString();
                    firetake.Squad.Students[CurrStud].Score = n.ToString();
                    CurrStud++;
                }
            }
            else
            {
                firetake.ToFile();
                CurrStud = 0;
            }
        }
        public bool ToDocument(List<Firetake> firetakes)
        {
            var res = true;
            return res;
        }
    }
}
