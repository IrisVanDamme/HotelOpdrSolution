using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Model
{
    public class Description
    {
        public Description(int duration, string location, string descriptionStr, string name)
        {
            Duration = duration;
            Location = location;
            DescriptionStr = descriptionStr;
            Name = name;
        }

        public int Duration { get; set; }
        public string Location { get; set; }
        public string DescriptionStr { get; set; }
        public string Name { get; set; }
    }
}
