using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Model
{
    public class PriceInfo
    {
        public PriceInfo(decimal adultPrice, decimal childPrice, int discount, int adultAge)
        {
            AdultPrice = adultPrice;
            ChildPrice = childPrice;
            Discount = discount;
            AdultAge = adultAge;
        }

        public Decimal AdultPrice { get; set; }
        public Decimal ChildPrice { get; set; }
        public int Discount { get; set; }
        public int AdultAge { get; set; }
    }
}
