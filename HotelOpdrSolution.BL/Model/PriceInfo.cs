using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Model
{
    public class PriceInfo
    {
        public PriceInfo(int adultPrice, int childPrice, int discount, int adultAge)
        {
            AdultPrice = adultPrice;
            ChildPrice = childPrice;
            Discount = discount;
            AdultAge = adultAge;
        }

        public int AdultPrice { get; set; }
        public int ChildPrice { get; set; }
        public int Discount { get; set; }
        public int AdultAge { get; set; }
    }
}
