using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Utilities
{
   public class OrderItem
    {
        string ItemName = "";
        string ItemPrice = "";
        string ItemType = "";
        ArrayList AddOns = new ArrayList();
        public OrderItem()
        {

        }
        public string Name
        {
            get { return ItemName; }
            set { ItemName = value; }
        }
        public string Price
        {
            get { return ItemPrice; }
            set { ItemPrice = value; }
        }
        public string Type
        {
            get { return ItemType; }
            set { ItemType = value; }
        }
        public void createAddOn(string addOn)
        {
            AddOns.Add(addOn);
        }
        public ArrayList AddOn
        {
            get { return AddOns; }
        }
    }
}
