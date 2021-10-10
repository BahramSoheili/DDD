using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUGHUBLib.ValueObjetcs
{
    public class PersonData
    {
        public RiskData riskData { get; set; }
        public decimal tax { get; set; }
        public string insurer { get; set; }
        public string error { get; set; }
    }
}
