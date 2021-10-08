using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcExeptionClass
{
    [Serializable]
    public class VeryLongExpressException : Exception
    {
        private static string _lastError = "";
        public static string lastError { get { return _lastError; } }
        public VeryLongExpressException()
        {
            _lastError = "A very long expression. The maximum length is 65,536 characters.";
        }

        public VeryLongExpressException(string message) { }
    }
}
