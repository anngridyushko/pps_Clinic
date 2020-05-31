using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Entities
{
    public class User
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public int TypeOfUser { get; set; }
    }
}
