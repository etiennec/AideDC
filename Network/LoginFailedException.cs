using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aide_Dilicom3.Network
{
    /// <summary>
    /// Exception occuring when the username and/or password are invalid.
    /// </summary>
    public class LoginFailedException : NetworkingException
    {
        public LoginFailedException() : base() { }
        public LoginFailedException(string message) : base(message) { }
        public LoginFailedException(string message, Exception e) : base(message, e) { }

    }
}
