using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A02_CSV
{
    internal class Data
    {

        public Data( DateTime Date, decimal Number1, decimal Number2, String Input)
        {   this.Date = Date;
            this.Number1 = Number1; 
            this.Number2 = Number2;
            this.Input = Input;
           
        }

        public String Input { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Number1 { get; private set; }
        public decimal Number2 { get; private set; }

    }
}
