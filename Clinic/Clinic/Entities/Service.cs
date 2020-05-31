using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Entities
{
    public class Service
    {
        public string serviceName { set; get; }

        public string serviceType { set; get; }

        public DateTime serviceDate { set; get; }

        public int payment { set; get; }

    }
}
