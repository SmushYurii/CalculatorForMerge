using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcExeptionClass
{
    [Serializable]
    public class IncorrectSyntOftheInputException : Exception
    {
        private static string _lastError = "";
        public static string lastError { get { return _lastError; } }
        public IncorrectSyntOftheInputException()
        {
            _lastError = "Incorrect syntactic construction of the input expression.";
        }

        public IncorrectSyntOftheInputException(string message) { }
    }
}
