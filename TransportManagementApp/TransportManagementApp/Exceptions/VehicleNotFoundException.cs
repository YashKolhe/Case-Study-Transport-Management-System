using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementApp.Exceptions
{
    public class VehicleNotFoundException:Exception
    {
        public VehicleNotFoundException(string message) : base(message) { }

    }
}
