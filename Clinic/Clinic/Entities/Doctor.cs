using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Entities
{
    public class Doctor
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Experience { get; set; }

        public string Specialty { get; set; }

        //public string Shedule { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}
