using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Model
{
    public class Organizer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ContactInfo ContactInfoOrganizer { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
