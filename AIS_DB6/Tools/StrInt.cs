using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_DB6.Tools
{
    class StrInt
    {
        private int _id;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        private string str;

        public string Str
        {
            get => str;
            set => str = value;
        }

        public StrInt(int i, string s)
        {
            Id = i;
           

            Str = Id.ToString() + " " + s;

        }
    }
}
