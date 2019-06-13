using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIS_DB6.Models;

namespace AIS_DB6.ViewModels
{
    class GoodVM
    {
        public Good TheGood { get; set; }

        public GoodVM()
        {
            TheGood = new Good();
        }

    }
}
