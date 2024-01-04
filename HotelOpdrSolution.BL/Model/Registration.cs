using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Model
{
    public class Registration
    {
        public Registration(int id, List<Member> members, Activity activityRegistration)
        {
            Id = id;
            Members = members;
            ActivityRegistration = activityRegistration;
        }

        public int Id { get; set; }
        public List<Member> Members { get; set; }
        public Activity ActivityRegistration { get; set; }
    }
}
