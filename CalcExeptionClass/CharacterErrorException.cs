using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcExeptionClass
{
    [Serializable]
    public class CharacterErrorException : Exception
    {
        private static string _lastError = "";
        public static string lastError { get { return _lastError; } }
        public CharacterErrorException()
        {
            _lastError = "Incorrect structure in parentheses, character error.";
        }

        public CharacterErrorException(string message) { }

    }
}
