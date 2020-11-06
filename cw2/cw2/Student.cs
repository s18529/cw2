using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{   
    public class Student
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string kierunek { get; set; }
        public string type { get; set; }
        public string index { get; set; }
        public DateTime bdate { get; set; }
        public string mail { get; set; }
        public string mname { get; set; }
        public string dname { get; set; }
        public Student(string fname, string lname, string kierunek, string type, string index, DateTime bdate, string mail, string mname, string dname)
        {
            this.fname = fname;
            this.lname = lname;
            this.kierunek = kierunek;
            this.type = type;
            this.index = index;
            this.bdate = bdate;
            this.mail = mail;
            this.mname = mname;
            this.dname = dname;
        }

        public Student() { }
    }
}
