using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aide_Dilicom3.Network
{
    /// <summary>
    /// All kinds of Network exception
    /// </summary>
    public class NetworkingException : Exception
    {
        public NetworkingException() : base() { }
        public NetworkingException(string message) : base(message) { }
        public NetworkingException(string message, Exception e) : base(message, e) { }

    }
}
