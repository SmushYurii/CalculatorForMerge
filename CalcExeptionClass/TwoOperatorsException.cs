using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcExeptionClass
{
    [Serializable]
    public class TwoOperatorsException : Exception
    {
        private static string _lastError = "";
        public static string lastError { get { return _lastError; } }
        public TwoOperatorsException()
        {
            _lastError = "Two consecutive operators on the <i> character.";
        }

        public TwoOperatorsException(string message) { }
    }
}
