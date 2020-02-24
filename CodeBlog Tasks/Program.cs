using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeBlog_Tasks {
    class Program {
        static void Main(string[] args) {
            
            string input;
            using var sr = new StreamReader("Tasks.txt");
            string res = sr.ReadToEnd();
            do {
                Console.WriteLine(res);
                Console.WriteLine();
                Console.Write("Введите номер задания: ");
                input = Console.ReadLine();
                Console.Clear();
            } while (!TaskNumberVaildation(res, input));

            NewTask(res, input);   
        }
        static void NewTask(string fileText, string s) {
            Console.Clear();
            int firstIndex = fileText.IndexOf("Task " + s);

            int nextTask = Convert.ToInt32(s) + 1;
            string next = fileText.Substring(fileText.IndexOf("Task " + nextTask));
            int secondIndex = fileText.IndexOf(next);
            Console.WriteLine(fileText.Substring(firstIndex, secondIndex));
        }

        static bool TaskNumberVaildation(string fileText, string userInput) {
            int num;

            if(!Int32.TryParse(userInput, out num)) {
                Console.WriteLine("Ошибка. Введите число!");
                Console.WriteLine("-----------------------------");
                return false;
            }

            if (!fileText.Contains("Task " + userInput)) {
                Console.WriteLine("Ошибка. Такого задания нет");
                Console.WriteLine("-----------------------------");
                return false;
            }

            return true;
        }
        static int NumberInput() {
            int num;
            while (!Int32.TryParse(Console.ReadLine(), out num)) {
                string input = Console.ReadLine();
            }
            return num;
        }

        static void OutputList(List<int> list) {
            Console.Write("List: ");
            foreach (var l in list) {
                Console.Write(l + " ");
            }
            Console.WriteLine("");
        }

        #region Task1_Completed
        static void Task1() {
            List<int> NodArray = new List<int>();
            
            int n = PositiveInteger();
           
            NodArray = NodArrayCalculate(n, NodArray);
            MaxNodCalculate(NodArray[0], n, out _, out _);     
        }

        static void MaxNodCalculate(int na, int n, out int f, out int s) {
            s = 0;
            for(f=0; f<n/2; f++) { 
                f = n - na;
                s = n - f;
                if (Nod(f, s) == na) {
                    Console.WriteLine($"First number: {f}, second number: {s}");
                }
            }
        }

        static int Nod(int a, int b) {
            for (int i = a; i > 0; i--) {
                if (a % i == 0) {
                    if (b % i == 0) {
                        return i;
                    }
                }
            }
            return -1;
        }
        static List<int> NodArrayCalculate(int n, List<int> NodArray) {
            for(int i = n/2; i > 0; i--) {
                if (n % i == 0)
                    NodArray.Add(i);
            }
            return NodArray;
        }
        
        static int PositiveInteger() {
            int n;
           
            do {
                Console.WriteLine("Введите натуральное число: ");
                n = NumberInput();
            } while (n <= 0);

            return n;
        }
        #endregion

        #region Task2_Completed
        static void Task2() {
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
            foreach (var l in list) {
                if (Convert.ToInt32(Convert.ToString(l), 2) % seven == 0) {
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

        #endregion

        #region Task3_Completed
        static void Task3() {
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
            Console.WriteLine(Task3_Inner(first, second, sequenceNumber));
        }

        static int Task3_Inner(int first, int second, int sequenceNumber) {
            int difference = second - first;
            int result = difference * sequenceNumber - (difference + Math.Abs(first));

            return result;
        }
        #endregion
    }
}
