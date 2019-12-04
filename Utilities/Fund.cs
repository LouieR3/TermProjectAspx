using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Utilities
{
    public class Fund
    {
        private string email = "";
        private double amount = 0.0;

        public Fund()
        {

        }
        public string Email
            {
            get { return email; }
            set { email = value; }
        }
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}
