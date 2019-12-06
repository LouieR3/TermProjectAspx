using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Merchant
    {
        private string email = "";
        private string name = "";
        public Merchant()
        {

        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
