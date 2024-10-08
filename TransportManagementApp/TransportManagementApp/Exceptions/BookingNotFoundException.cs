using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementApp.Exceptions
{
    public class BookingNotFoundException:Exception
    {
        public BookingNotFoundException(string message) : base(message) { }

    }
}
