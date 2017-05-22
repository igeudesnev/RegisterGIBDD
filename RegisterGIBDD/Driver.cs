﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterGIBDD
{
    class Driver
    {
        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _drivinglicensenumber;

        public string Drivinglicensenumber
        {
            get { return _drivinglicensenumber; }
            set { _drivinglicensenumber = value; }
        }

        private string _car1;

        public string Car1
        {
            get { return _car1; }
            set { _car1 = value; }
        }

        private string _car2;

        public string Car2
        {
            get { return _car2; }
            set { _car2 = value; }
        }

        private string _car3;

        public string Car3
        {
            get { return _car3; }
            set { _car3 = value; }
        }


        public Driver(string surname, string name, string drivinglicensenumber)
        {
            _surname = surname;
            _name = name;
            _drivinglicensenumber = drivinglicensenumber;
        }

        public Driver(string surname, string name, string drivinglicensenumber, string car1)
            : this(surname, name, drivinglicensenumber)
        {
            _car1 = car1;
        }

        public Driver(string surname, string name, string drivinglicensenumber, string car1, string car2)
            : this(surname, name, drivinglicensenumber, car1)
        {
            _car2 = car2;
        }

        public Driver(string surname, string name, string drivinglicensenumber, string car1, string car2, string car3)
            : this(surname, name, drivinglicensenumber, car1, car2)
        {
            _car3 = car3;
        }

        public string Show(string surname, string name, string drivinglicensenumber)
        {
            return string.Format("{0}<>{1}<>{2}\n", surname, name, drivinglicensenumber);
        }
    }
}
