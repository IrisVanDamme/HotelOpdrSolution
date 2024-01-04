using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Model
{
    public class Organizer
    {
        public Organizer(int id, string name, ContactInfo contactInfoOrganizer, List<Activity> activities)
        {
            Id = id;
            Name = name;
            ContactInfoOrganizer = contactInfoOrganizer;
            Activities = activities;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ContactInfo ContactInfoOrganizer { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
