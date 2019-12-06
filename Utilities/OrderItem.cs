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
        float ItemPrice = 0;
        string ItemType = "";
        string AddOns = "";
        public OrderItem()
        {

        }
        public string Name
        {
            get { return ItemName; }
            set { ItemName = value; }
        }
        public float Price
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
            AddOns = string.Join(",", addOn);
        }
        public string AddOn
        {
            get { return AddOns; }
        }
    }
}
