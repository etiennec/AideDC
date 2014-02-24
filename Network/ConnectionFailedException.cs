using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aide_Dilicom3.Network
{
    /// <summary>
    /// Exception occuring when the connection to the Server cannot be done.
    /// </summary>
    public class ConnectionFailedException:NetworkingException
    {
        public ConnectionFailedException():base(){}
        public ConnectionFailedException(string message):base(message){}
        public ConnectionFailedException(string message, Exception e) : base(message, e) { }
    }
}
