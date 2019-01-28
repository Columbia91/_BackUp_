using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BackUp_
{
    public class HDD : Storage
    {
        public HDD(string name, string model, double capacity, double writeSpeed)
            : base(name, model, capacity, writeSpeed) { }
    }
}
