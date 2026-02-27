using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OCP
{
    internal interface IMessage
    {
        public void send(string message); //service.
        public void Validation();

    }
}
