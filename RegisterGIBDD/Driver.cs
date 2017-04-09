using System;
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

        private int _drivinglicensenumber;

        public int Drivinglicensenumber
        {
            get { return _drivinglicensenumber; }
            set { _drivinglicensenumber = value; }
        }

        public Driver(string surname, string name, int drivinglicensenumber)
        {
            _surname = surname;
            _name = name;
            _drivinglicensenumber = drivinglicensenumber;
        }
    }
}
