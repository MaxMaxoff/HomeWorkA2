using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Библиотека для упрощения работы с консолью.
// https://github.com/MaxMaxoff/SupportLibrary
using SupportLibrary;

/// <summary>
/// Максим Торопов
/// Ярославль
/// https://github.com/MaxMaxoff
/// 
/// Домашняя работа "Алгоритмы и структуры данных"
/// 2 урок
/// </summary>
namespace HomeWorkA2
{
    class Program
    {
        /// <summary>
        /// 1. Реализовать функцию перевода из 10 системы в двоичную используя рекурсию.
        /// </summary>
        static void Task1()
        {
            SupportMethods.PrepareConsoleForHomeTask("1. Реализовать функцию перевода из 10 системы в двоичную используя рекурсию.\n");

            int number = SupportMethods.RequestIntValue("Please type decimal number to convert: ");

            Console.Write("Converted to binary: ");

            // if number is negative print "-" and convert to positive
            if (number < 0)
            {
                Console.Write("-");
                number *= -1;                
            }
                        
            Converter(number);
            SupportMethods.Pause();
        }

        /// <summary>
        /// Method converter to binary
        /// </summary>
        /// <param name="number">incoming number in decimal</param>
        static void Converter(int number)
        {
            if (number / 2 > 0) Converter(number / 2);
            Console.Write(number % 2);
        }

        /// <summary>
        /// 2. Реализовать функцию возведения числа a в степень b:
        /// a.без рекурсии;
        /// b.рекурсивно;
        /// c. * рекурсивно, используя свойство чётности степени.
        /// </summary>
        static void Task2()
        {
            SupportMethods.PrepareConsoleForHomeTask("2. Реализовать функцию возведения числа a в степень b:\n");

            int a = SupportMethods.RequestIntValue("Please type a: ");
            int b = SupportMethods.RequestIntValue("Please type b: ");

            // a.без рекурсии;
            SupportMethods.PrepareConsoleForHomeTask("2. Реализовать функцию возведения числа a в степень b:\n" +
                "a.без рекурсии;\n");

            if (b > 0)
            {
                SupportMethods.Pause($"{a} raise to a Power {b} equals {raisePower(a, b)}");
            } else if (b < 0)
            {
                SupportMethods.Pause($"{a} raise to a Power {b} equals 1/{raisePower(a, b * (-1))}");
            } else
            {
                SupportMethods.Pause($"{a} raise to a Power {b} equals 1");
            }

            // b.рекурсивно;
            SupportMethods.PrepareConsoleForHomeTask("2. Реализовать функцию возведения числа a в степень b:\n" +
                "b.рекурсивно;\n");

            if (b > 0)
            {
                SupportMethods.Pause($"{a} raise to a Power {b} equals {raisePowerRecursion(a, b)}");
            }
            else if (b < 0)
            {
                SupportMethods.Pause($"{a} raise to a Power {b} equals 1/{raisePowerRecursion(a, b * (-1))}");
            }
            else
            {
                SupportMethods.Pause($"{a} raise to a Power {b} equals 1");
            }

            // c. * рекурсивно, используя свойство чётности степени.
            SupportMethods.PrepareConsoleForHomeTask("2. Реализовать функцию возведения числа a в степень b:\n" +
                "c. * рекурсивно, используя свойство чётности степени.\n");

            if (b > 0)
            {
                SupportMethods.Pause($"{a} raise to a Power {b} equals {raiseEVENPowerRecursion(a, b)}");
            }
            else if (b < 0)
            {
                SupportMethods.Pause($"{a} raise to a Power {b} equals 1/{raiseEVENPowerRecursion(a, b * (-1))}");
            }
            else
            {
                SupportMethods.Pause($"{a} raise to a Power {b} equals 1");
            }


        }

        /// <summary>
        /// Method Raise to Power 
        /// </summary>
        /// <param name="a">base</param>
        /// <param name="b">power</param>
        /// <returns>raise a to power b</returns>
        static long raisePower(int a, int b)
        {
            long result = 1;

            for (int i = 1; i <= b; i++)
            {
                result = result * a;
            }

            return result;
        }

        /// <summary>
        /// Method Raise to Power Recursion
        /// </summary>
        /// <param name="a">base</param>
        /// <param name="b">power</param>
        /// <returns>raise a to power b</returns>
        static long raisePowerRecursion(int a, int b)
        {
            if (b != 1)
            {
                return a * raisePowerRecursion(a, b - 1);
            }

            return a;
        }

        /// <summary>
        /// Method Raise to Power Recursion using EVEN property of Power
        /// </summary>
        /// <param name="a">base</param>
        /// <param name="b">power</param>
        /// <returns>raise a to power b using EVEN property of power</returns>
        static long raiseEVENPowerRecursion(int a, int b)
        {
            if (b != 1)
            {
                if (b % 2 == 0)
                {
                    return raiseEVENPowerRecursion(a, b / 2) * raiseEVENPowerRecursion(a, b / 2);
                }
                else
                {
                    return a * raiseEVENPowerRecursion(a, b - 1);
                }
            }

            return a;
        }

        /// <summary>
        /// 3. Исполнитель Калькулятор преобразует целое число, записанное на экране.
        /// У исполнителя две команды, каждой команде присвоен номер:
        /// 1. Прибавь 1
        /// 2. Умножь на 2
        /// Первая команда увеличивает число на экране на 1, вторая увеличивает это число в 2 раза.
        /// Сколько существует программ, которые число 3 преобразуют в число 20?
        /// а) с использованием массива;
        /// б) с использованием рекурсии.
        /// </summary>
        static void Task3()
        {
            SupportMethods.PrepareConsoleForHomeTask("3. Исполнитель Калькулятор преобразует целое число, записанное на экране.\n" +
                "У исполнителя две команды, каждой команде присвоен номер:\n" +
                "1. Прибавь 1\n" +
                "2. Умножь на 2\n" +
                "Первая команда увеличивает число на экране на 1, вторая увеличивает это число в 2 раза.\n" +
                "Сколько существует программ, которые число 3 преобразуют в число 20?\n");

            int a = SupportMethods.RequestIntValue("Please type a: ");
            int b = SupportMethods.RequestIntValue("Please type b: ");

            if (a > 0 && b > 0 && a < b)
            {
                // а) с использованием массива;
                SupportMethods.PrepareConsoleForHomeTask("3. Исполнитель Калькулятор преобразует целое число, записанное на экране.\n" +
                    "У исполнителя две команды, каждой команде присвоен номер:\n" +
                    "1. Прибавь 1\n" +
                    "2. Умножь на 2\n" +
                    "Первая команда увеличивает число на экране на 1, вторая увеличивает это число в 2 раза.\n" +
                    "Сколько существует программ, которые число 3 преобразуют в число 20?\n" +
                    "а) с использованием массива;\n");

                SupportMethods.Pause($"Qty of programs: {CalcArray(a, b)}");

                // б) с использованием рекурсии.
                SupportMethods.PrepareConsoleForHomeTask("3. Исполнитель Калькулятор преобразует целое число, записанное на экране.\n" +
                    "У исполнителя две команды, каждой команде присвоен номер:\n" +
                    "1. Прибавь 1\n" +
                    "2. Умножь на 2\n" +
                    "Первая команда увеличивает число на экране на 1, вторая увеличивает это число в 2 раза.\n" +
                    "Сколько существует программ, которые число 3 преобразуют в число 20?\n" +
                    "б) с использованием рекурсии.\n");

                SupportMethods.Pause($"Qty of programs: {CalcRecursion(a, b)}");
            }
            else if ((a > 0 && a > b) || (a == 0 && b < 0))
                SupportMethods.Pause($"Qty of programs: 0");
            else if (a <= 0 && b > 0)
                SupportMethods.Pause($"Qty of programs: {CalcRecursion(1, b)}, Infinity qty of programs.");
            // SupportMethods.Pause($"Qty of programs: {CalcArray(1, b)}, Infinity qty of programs.");
            else if ((a == 0 && b >= 0) || (a < 0 && b <= 0))
                SupportMethods.Pause($"Infinity qty of programs.");
            else if (a == b)
                SupportMethods.Pause($"Qty of programs: 1");
        }

        static int CalcArray(int a, int b)
        {
            //int[] arr = new int[b];
            ////arr[a - 1] = 0;
            ////arr[a] = 1;

            //for (int i = 1; i < b; i++)
            //{
            //    if (i % 2 != 0) arr[i] = arr[i - 1];
            //    else arr[i] = arr[i - 1] + 1;
            //}

            //for (int i = 0; i < b; i++)
            //    Console.Write($"{arr[i]} ");

            //return arr[b - 1];
        }

        /// <summary>
        /// Method Caclucator Recursion
        /// </summary>
        /// <param name="a">from</param>
        /// <param name="b">to</param>
        /// <returns>qty programs</returns>
        static int CalcRecursion(int a, int b)
        {
            if (a < b)
                return CalcRecursion(a + 1, b) + CalcRecursion(a * 2, b);
            else if (a == b) return 1;
            else return 0;
        }

        static void Main(string[] args)
        {
            do
            {
                SupportMethods.PrepareConsoleForHomeTask("1 - Task 1\n" +
                  "2 - Task 2\n" +
                  "3 - Task 3\n" +
                  "0 (Esc) - Exit\n");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Task1();
                        break;
                    case ConsoleKey.D2:
                        Task2();
                        break;
                    case ConsoleKey.D3:
                        Task3();
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
