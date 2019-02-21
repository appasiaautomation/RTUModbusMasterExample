using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTUModbusMasterExample
{
    class SerialPortNotOpenedException : Exception
    {
        private string p;

        public SerialPortNotOpenedException(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }
    }
}
