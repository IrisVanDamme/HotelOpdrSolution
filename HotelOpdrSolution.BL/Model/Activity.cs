using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Model
{
    public class Activity
    {
        public Activity(int id, DateTime fixture, int nrOfPlaces, Description descriptionActivity, PriceInfo priceInfoActivity)
        {
            Id = id;
            Fixture = fixture;
            NrOfPlaces = nrOfPlaces;
            DescriptionActivity = descriptionActivity;
            PriceInfoActivity = priceInfoActivity;
        }

        public int Id { get; set; }
        public DateTime Fixture { get; set; }
        public int NrOfPlaces { get; set; }
        public Description DescriptionActivity { get; set; }
        public PriceInfo PriceInfoActivity { get; set; }
    }
}
