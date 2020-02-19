using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodeBlog_Tasks {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter task number(--info): ");

            //int taskNumber = NumberInput();
            //string methodName = "Task" + taskNumber + "()";
            //MethodInfo mi = GetMethod(methodName);
            //mi?.Invoke();
            Console.WriteLine("Task 314 316");
        //Task314();
        //Task316();
    }

        static int NumberInput() {
            int num;
            while (!Int32.TryParse(Console.ReadLine(), out num)) {
                string input = Console.ReadLine();
            }
            return num;
        }


        #region Task309
        static void Task309() {
            /*Дано натуральное число N. Представить его в виде суммы двух
             * натуральных чисел таких, что  НОД этих чисел - максимален
             */


        }
        #endregion

        #region Task310
        static void Task310() {
            /*Из шахматной доски по границам клеток выпилили связную
             * (не распадающуюся на части) фигуру без дыр
             * Найти её периметр
             */


        }
        #endregion

        #region Task312
        static void Task312() {
            //Найти все целые X, удовлетворяющие уравнению
            //A*X^3 + B*X^2 + C*X + D = 0
            //где A B C D - заданные целые коэффициенты


        }
        #endregion

        #region Task314_Completed
        static void Task314() {
            //Определить делимость на 7 ряда целых чисел,
            //записанных в двоичной системе счисления
            Console.WriteLine("Определить делимость на 7 ряда целых чисел,\n записанных в двоичной системе счисления");

            List<int> list = new List<int>();

            Console.WriteLine("Enter array of numbers in bin(n-stop): ");

            list = InputList(list);     //ввод двоичного списка

            OutputList(list);

            OutputList(DivisibilityBySeven(list));
        }

        static List<int> DivisibilityBySeven(List<int> list) {
            List<int> DividedBySeven = new List<int>();
            int seven = 7;
            foreach(var l in list) {
                if(Convert.ToInt32(Convert.ToString(l),2) % seven == 0) {
                    DividedBySeven.Add(l);
                }
            }          
            return DividedBySeven;

        }
        static List<int> InputList(List<int> list) {
            string input;

            while (true) {
                input = Console.ReadLine();

                if (input == "n" && list.Any())
                    return list;

                if (Int32.TryParse(input, out int num) && IsBinary(input)) {
                    list.Add(num);
                }   
            }
        }

        static bool IsBinary(string s) {
            return s.All(c => c == '1' || c == '0');
        }

        static void OutputList(List<int> list) {
            Console.Write("List: ");
            foreach (var l in list) {
                Console.Write(l + " ");
            }
            Console.WriteLine("");
        }

        #endregion

        #region Task316_Completed
        static void Task316() {
            //Заданы первый и второй элементы арифметической прогрессии. 
            //Требуется написать программу, которая вычислит элемент прогрессии по её номеру
            Console.WriteLine("Заданы первый и второй элементы арифметической прогрессии.\nТребуется написать программу, которая вычислит элемент прогрессии по её номеру");
            int first;
            int second;
            int sequenceNumber;
            do {
                Console.WriteLine("Enter first number of arithmetic progression:");
                first = NumberInput();
                Console.WriteLine("Enter second number of arithmetic progression:");
                second = NumberInput();
            } while (second <= first);

            Console.WriteLine("Enter number in arithmetic progression:");
            do {
                sequenceNumber = NumberInput();
            } while (sequenceNumber < 1);
            Console.WriteLine(Task316_Inner(first, second, sequenceNumber));
        }

        static int Task316_Inner(int first, int second, int sequenceNumber) {
            int difference = second - first;
            int result = difference * sequenceNumber - (difference + Math.Abs(first));

            return result;
        }
        #endregion


    }
}
