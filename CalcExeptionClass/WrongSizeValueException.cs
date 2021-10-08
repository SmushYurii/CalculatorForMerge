using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcExeptionClass
{
    [Serializable]
    public class WrongSizeValueException : Exception
    {
        private static string _lastError = "";
        public static string lastError { get { return _lastError; } }
        public WrongSizeValueException()
        {
            _lastError = "Very small or very large number value for int.";
        }

        public WrongSizeValueException(string message) { }
    }
}
