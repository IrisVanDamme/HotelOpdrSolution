using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Model
{
    public class Registration
    {
        public int Id { get; set; }
        public List<Member> Members { get; set; }
    }
}
