using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcClass
{
    public class Calc
    {

        /// <summary>
        /// Функція складання числа а і b
        /// </summary>
        /// <param name="a">доданок</param>
        /// <param name="b">доданок</param>
        /// <returns>сума</returns>
        public static int Add(long a, long b)
        {
            long res = a + b;

            if (res < int.MinValue || res > int.MaxValue)
            {
                throw new OverflowException();
            }
            return (int)res;

        }

        /// <summary>
        /// функція віднімання чисел а і b
        /// </summary>
        /// <param name="a">зменшуване</param>
        /// <param name="b">від’ємне</param>
        /// <returns>різниця</returns>
        public static int Sub(long a, long b)
        {
            long res = a - b;

            if (res < int.MinValue || res > int.MaxValue)
            {
                throw new OverflowException();
            }
            return (int)res;
        }
        /// <summary>
        /// функція множення чисел а і b
        /// </summary>
        /// <param name="a">множник</param>
        /// <param name="b">множник</param>
        /// <returns>добуток</returns>
        public static int Mult(long a, long b)
        {
            long res = a * b;

            if (res < int.MinValue || res > int.MaxValue)
            {
                throw new OverflowException();
            }
            return (int)res;
        }
        /// <summary>
        /// функція знаходження частки
        /// </summary>
        /// <param name="a">ділене</param>
        /// <param name="b">дільник</param>
        /// <returns>частка</returns>
        public static int Div(long a, long b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }

            long res = a / b;

            if (res < int.MinValue || res > int.MaxValue)
            {
                throw new OverflowException();
            }
            return (int)res;
        }

        /// <summary>
        /// функція ділення по модулю
        /// </summary>
        /// <param name="a">ділене</param>
        /// <param name="b">дільник</param>
        /// <returns>остача</returns>
        public static int Mod(long a, long b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }

            long res = a % b;

            if (res < int.MinValue || res > int.MaxValue)
            {
                throw new OverflowException();
            }
            return (int)res;
        }
        /// <summary>
        /// унарний плюс 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int ABS(long a)
        {
            long res = Convert.ToInt32(Math.Abs(a));
            if (res < int.MinValue || res > int.MaxValue)
            {
                throw new OverflowException();
            }
            return (int)res;
        }
        /// <summary>
        /// унарний мінус 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int IABS(long a)
        {
            long res = Convert.ToInt32(Math.Abs(a));
            if (res < int.MinValue || res > int.MaxValue)
            {
                throw new OverflowException();
            }
            return -(int)res;
        }

    }
}
