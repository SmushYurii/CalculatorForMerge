using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcExeptionClass
{
    [Serializable]
    public class UnknownOperatorException : Exception
    {
        private static string _lastError = "";
        public static string lastError { get { return _lastError; } }
        public UnknownOperatorException()
        {
            _lastError = "Unknown operator on <i> character.";
        }

        public UnknownOperatorException(string message) { }
    }
}
