using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcExeptionClass
{
    [Serializable]
    public class IncompleteExpresException : Exception
    {
        private static string _lastError = "";
        public static string lastError { get { return _lastError; } }
        public IncompleteExpresException()
        {
            _lastError = "Incomplete expression.";
        }

        public IncompleteExpresException(string message) { }
    }
}
