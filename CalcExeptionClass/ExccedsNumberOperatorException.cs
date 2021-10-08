using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcExeptionClass
{
    [Serializable]
    public class ExccedsNumberOperatorException : Exception
    {
        private static string _lastError = "";
        public static string lastError { get { return _lastError; } }
        public ExccedsNumberOperatorException()
        {
            _lastError = "The total number of numbers and operators exceeds 30.";
        }

        public ExccedsNumberOperatorException(string message) { }
    }
}
