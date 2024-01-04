using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.BL.Model
{
    public class Member
    {
        public Member(string name, DateOnly birthday)
        {
            Name = name;
            Birthday = birthday;
        }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Naam mag niet langer zijn dan 500 karakters");
                }
                else if (value.Length > 500)
                {
                    throw new ArgumentException("Naam mag niet leeg zijn");
                }
            }
        }
        public DateOnly Birthday { get; set; }
    }
}
