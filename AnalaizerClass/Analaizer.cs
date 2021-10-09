using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcExeptionClass;
using CalcClass;

namespace AnalaizerClass
{

    public class Analaizer
    {
        /// <summary>
        /// позиція виразу, на якій знайдена синтаксична помилка (у 
        ///  випадку відловлення на рівні виконання - не визначається)
        /// </summary>
        private static int erposition = 0;
        /// <summary>
        /// Вхідний вираз
        /// </summary>
        public static string expression = "";
        /// <summary>
        /// Показує, чи є необхідність у виведенні повідомлень про помилки. 
        /// У разі консольного запуску програми це значення - false.
        /// </summary>
        public static bool ShowMessage = true;
        /// <summary>
        /// Перевірка коректності структури в дужках вхідного виразу 
        /// </summary>
        /// <returns>true - якщо все нормально, false- якщо є 
        ///  помилка</returns>
        /// метод біжить по вхідному виразу, символ за символом аналізуючи 
        ///його, і рахуючи кількість дужок.У разі виникнення
        /// помилки повертає false, а в erposition записує позицію, на 
        ///якій виникла помилка.
        public static bool CheckCurrency()
        {
            //Error 07 — Дуже довгий вираз. Максмальная довжина — 65536 символів.
            if (expression.Length > 65536)
                throw new VeryLongExpressException();


            Stack st = new Stack();

            //перший символ
            if (expression[0] < '0')
                if (expression[0] != '-' && expression[0] != '(')
                {
                    erposition = 0;
                    return false;
                }

            //останній символ
            if (expression[expression.Length - 1] < '0' && expression[expression.Length - 1] != ')')
            {
                erposition = expression.Length - 1;
                //Error 05 — Незавершений вираз
                throw new IncompleteExpresException();
               
                return false;
            }

            //проходимо в циклі по всіх інших символах
            for (int i = 0; i < expression.Length - 1; i++)
            {
                if ((expression[i] >= '0' && expression[i] <= '9') && expression[i + 1] == '(')
                {
                    erposition = i + 1;
                    return false;
                }

                if (expression[i] < '0' && expression[i] >= '*') //перевіряємо оператори
                {
                    if (expression[i + 1] < '0' && expression[i + 1] != '(')//наступне число не може бути знаком якщо це не відкриваюча дужка
                    {
                        erposition = i + 1;
                        //Error 04 at <i> — Два підряд оператори на <i> символі.
                        throw new TwoOperatorsException($"Two consecutive operators on the {erposition} character.");
                        return false;
                    }
                }
                if (expression[i] == '(')//після відкриваючой може бути число або мінус або (
                {
                    if (expression[i + 1] != '-' && expression[i + 1] != '(' && expression[i + 1] <= '0')
                    {
                        erposition = i + 1;
                        //Error 03 — Невірна синтаксична конструкція вхідного виразу.
                        throw new IncorrectSyntOftheInputException();
                        return false;
                    }
                    else
                        st.Push(expression[i]);
                }

                if (expression[i] == ')' && expression[i + 1] >= '0')
                {
                    erposition = i + 1;
                    // Error 03 — Невірна синтаксична конструкція вхідного виразу.
                    throw new IncorrectSyntOftheInputException();
                    return false;
                }

                if (expression[i] == ')' && st.Count == 0 || expression[i] == ')' && Convert.ToChar(st.Peek()) != '(')
                {
                    erposition = i + 1;
                    //Error 03 — Невірна синтаксична конструкція вхідного виразу.
                    throw new IncorrectSyntOftheInputException();
                    return false;
                }

                if (expression[i] == ')' && Convert.ToChar(st.Peek()) == '(')
                    st.Pop();

            }

            if (expression[expression.Length - 1] == ')' && st.Count != 0)
            {
                if (Convert.ToChar(st.Peek()) == '(')
                    st.Pop();
                else
                {
                    erposition = expression.Length - 1;
                    return false;
                }
            }

            if (st.Count == 0)
                return true;
            else
            {
                erposition = expression.IndexOf('(');
                return false;
            }
            return true;
        }

        static private bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
                return true;
            return false;
        }
        /// <summary>
        /// Форматує вхідний вираз, виставляючи між операторами 
        ///   пропуски і видаляючи зайві, а також знаходить нерозпізнані
        ///оператори, стежить за кінцем рядка
        /// а також знаходить помилки в кінці рядка
        /// </summary>
        /// <returns>кінцевий рядок або повідомлення про помилку, що 
        ///починаються з спец.символу &</returns>
        public static string Format()
        {
            string format = "";
            string num = "";

            for (int i = 0; i < expression.Length; i++)
            {
                if (IsOperator(expression[i]))
                {
                    format += expression[i] + " ";
                    continue;
                }
                else
                {
                    while (!IsOperator(expression[i]))
                    {
                        num += expression[i]; //Добавляємо кожну цифру числа в нашу стрiчку
                        i++;

                        if (i == expression.Length)
                            break; //Якщо символ - останній, то виходимо з циклу
                    }
                    format += num + " ";
                    num = "";
                    i--;
                }
            }
            //Error 08 — Сумарна кількість чисел і операторів перевищує 30
            if (format.Count(c => c == ' ') > 30)
                throw new ExccedsNumberOperatorException();

            return format;
        }

        static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                default: return 5;
            }
        }
        /// <summary>
        /// Формує масив, в якому розташовуються оператори і символи 
        ///  представлені в зворотному польському записі(без дужок)
        /// На цьому ж етапі відшукується решта всіх помилок (див. 
        ///код). По суті - це компіляція.
        /// </summary>
        /// <returns>массив зворотнього польського запису</returns>
        public static System.Collections.ArrayList CreateStack()
        {
            string format = Format();
            ArrayList list = new ArrayList();
            Stack stack = new Stack();
            if (format[0] == '&')
                throw new Exception();

            for (int i = 0; i < format.Length; i++)
            {
                int index = format.IndexOf(' ');
                string tmp = format.Substring(0, index);

                int number;
                bool success = int.TryParse(tmp, out number);
                if (success)
                {
                    list.Add(tmp);
                }
                else
                {
                    char op = Convert.ToChar(tmp);
                    if (IsOperator(op))
                    {
                        if (op == '(')
                            stack.Push(tmp);
                        else if (op == ')')
                        {
                            //перекидаємо всі оператори до '(' в наш ліст
                            char s = (char)stack.Pop();

                            while (s != '(')
                            {
                                list.Add(s.ToString());
                                s = Convert.ToChar(stack.Pop());
                            }
                        }
                        else //якщо будь який інший
                        {
                            if (stack.Count > 0)
                            {
                                char s1 = Convert.ToChar(stack.Peek());
                                //якщо оператор менший по значимості або однаковий то додаємо його в ліст
                                if (GetPriority(op) <= GetPriority(s1))
                                    list.Add(stack.Pop().ToString()); //видаляючи з стека
                            }
                            stack.Push(char.Parse(tmp)); //якщо оператор важливіший по приорітету - просто додаємо в стек
                        }
                    }
                }
                format = format.Substring(index + 1);
                i = 0;
            }
            while (stack.Count > 0) //додаємо до стрічки все що лишилося в стеку
                list.Add(stack.Pop());

            return list;
        }

        /// <summary>
        /// Обчислення зворотнього польського запису
        /// </summary>
        ///<returns>результат обчислень,або повідомлення про помилку</returns>
        public static string RunEstimate()
        {
            double result = 0; //Результат
            Stack<double> temp = new Stack<double>(); // стек для розвязання
            ArrayList list = CreateStack();//вхідний стек
            for (int i = 0; i < list.Count; i++)
            {
                string s = Convert.ToString(list[i]);
                double number;
                bool success = double.TryParse(s, out number);
                char ch;
                bool success1 = char.TryParse(s, out ch);

                if (success)//якщо число
                {
                    temp.Push(number); //Записуємо в стек для розвязання
                    continue;
                }
                else if (success1)//якщо оператор
                {
                    if (IsOperator(ch)) //якщо оператор

                    {   //Беремo два останнiх значения iз стека

                        long a = (long)temp.Pop();
                        long b = (long)temp.Pop();
                        try //відловлюю виключення з класу CalcClass
                        {
                            switch (ch)
                            {
                                case '+':
                                    result = Calc.Add(b, a);
                                    break;
                                case '-':
                                    result = Calc.Sub(b, a);
                                    break;
                                case '*':
                                    result = Calc.Mult(b, a);
                                    break;
                                case '/':
                                    result = Calc.Div(b, a);
                                    break;
                            }
                            temp.Push(result); //Результат вычисления записуємо назад в стек
                        }
                        catch (OverflowException ex)
                        {
                            throw ex;
                        }
                        catch (DivideByZeroException ex)
                        {
                            throw ex;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                        
                    }
                }
            }
            //вкінці в нашому стеку обчислень лишиться лише одне число - результат
            return temp.Peek().ToString();
        }

        /// <summary>
        /// Метод, який організовує обчислення. По черзі запускає 
        ///    CheckCorrncy, Format, CreateStack і RunEstimate
        /// </summary>
        /// <returns></returns>
        public static string Estimate()
        {
            //
            string result = "";
           // try
            //{
                bool flag = CheckCurrency();

                if (!flag)
                {
                    ArrayList list = CreateStack();//вхідний стеk
                    result = RunEstimate();
                }
                else
                    throw new Exception($"somethig whrong at position {erposition}");
        //    }
        //    catch(VeryLongExpressException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (ExccedsNumberOperatorException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (IncompleteExpresException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (IncorrectSyntOftheInputException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (TwoOperatorsException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (OverflowException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (DivideByZeroException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
            return result;
        }
    }
}
