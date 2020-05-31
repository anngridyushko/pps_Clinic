using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Entities
{
    public class Client
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int PersonalRelief { get; set; }

        private List<Pet> pets = new List<Pet>();
        private List<Service> services = new List<Service>();

        public void setService(Service s)
        {
            services.Add(s);
        }

     
        public List<Service> GetServices()
        {
            return services;
        }
    }
}
