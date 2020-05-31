using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Entities
{
    public class Pet
    {
        public int id { get; set; }

        public int Owner_id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        private string ClinicalRecord;

    }
}
