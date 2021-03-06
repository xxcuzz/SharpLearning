﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CodeBlog_Tasks {
    class Program {
        public delegate void delMethod();
        static void Main(string[] args) {

            T t = new T();
            string input;
            using var sr = new StreamReader("Tasks.txt");
            string res = sr.ReadToEnd();

            do {
                Console.Clear();
                do {
                    Console.WriteLine(res);
                    Console.WriteLine();
                    Console.Write("Введите номер задания: ");
                    input = Console.ReadLine();
                    Console.Clear();
                } while (!TaskNumberVaildation(res, input));

                OutputTaskText(res, Convert.ToInt32(input));

                CreateTask();

                Console.Write("Ещё задания: \"Y\". Для выхода введите любой символ:");
            } while (Console.ReadLine() == "Y");

            void CreateTask() {
                delMethod method;
                string methodName = "Task" + input;
                Type typeOfTClass = t.GetType();
                foreach (var m in typeOfTClass.GetMethods()) {
                    if (m.Name == methodName) {
                        MethodInfo mi = typeof(T).GetMethod(m.Name);
                        Delegate test = Delegate.CreateDelegate(typeof(delMethod), t, mi);
                        method = (delMethod)test;
                        method?.Invoke();
                    }
                }
            }

            void OutputTaskText(string fileText, int s) {
                Console.Clear();
                int firstIndex = fileText.IndexOf("Task " + s);

                string nextTask = "Task " + ++s;
                int secondIndex = fileText.IndexOf(nextTask);

                if (secondIndex == -1) {
                    Console.WriteLine(fileText.Substring(firstIndex));
                } else {
                    Console.WriteLine(fileText.Substring(firstIndex, secondIndex - firstIndex));
                }
            }

            bool TaskNumberVaildation(string fileText, string userInput) {
                int num;

                if (!Int32.TryParse(userInput, out num)) {
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
        }
    }

    class T {
        public void Task1() {
            void MaxNodCalculate(int na, int n, out int f, out int s) {
                s = 0;
                for (f = 0; f < n / 2; f++) {
                    f = n - na;
                    s = n - f;
                    if (Nod(f, s) == na) {
                        Console.WriteLine($"Первое число: {f}, второе число: {s}");
                    }
                }
            }
            int Nod(int a, int b) {
                for (int i = a; i > 0; i--) {
                    if (a % i == 0) {
                        if (b % i == 0) {
                            return i;
                        }
                    }
                }
                return -1;
            }
            List<int> NodArrayCalculate(int n, List<int> NodArray) {
                for (int i = n / 2; i > 0; i--) {
                    if (n % i == 0)
                        NodArray.Add(i);
                }
                return NodArray;
            }


            List<int> NodArray = new List<int>();
            int n = NumberInput();

            if (n == 1) {
                Console.WriteLine("Число 1 нельзя))");
                return;
            }

            NodArray = NodArrayCalculate(n, NodArray);
            MaxNodCalculate(NodArray[0], n, out _, out _);
        }

        public void Task2() {
            List<int> DivisibilityBySeven(List<int> list) {
                List<int> DividedBySeven = new List<int>();
                int seven = 7;
                foreach (var l in list) {
                    if (Convert.ToInt32(Convert.ToString(l), 2) % seven == 0) {
                        DividedBySeven.Add(l);
                    }
                }
                return DividedBySeven;

            }


            List<int> list = new List<int>();

            Console.WriteLine("Введите массив бит(n-стоп): ");

            list = InputList(list);     //ввод двоичного списка

            OutputList(list);

            OutputList(DivisibilityBySeven(list));
        }

        public void Task3() {

            int first;
            int second;
            int sequenceNumber;

            int result;
            static int Calculate(int f, int s, int num) {
                int difference = s - f;

                if (f < 0) {
                    return difference * num - (difference + Math.Abs(f));
                } else {
                    return difference * num - (difference - f);
                }
            }

            Console.WriteLine("Введите первый элемент арифметической прогрессии:");
            first = NumberInput();
            Console.WriteLine("Введите второй элемент арифметической прогрессии:");
            second = NumberInput();

            Console.WriteLine("Введите номер элемента:");
            do {
                sequenceNumber = NumberInput();
            } while (sequenceNumber < 1);

            result = Calculate(first, second, sequenceNumber);
            Console.WriteLine("Число: " + result);   
        }


        protected List<int> InputList(List<int> list) {
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
        protected bool IsBinary(string s) {
            return s.All(c => c == '1' || c == '0');
        }
        protected int NumberInput() {
            int num;
            while (!Int32.TryParse(Console.ReadLine(), out num)) {
                string input = Console.ReadLine();
            }
            return num;
        }
        protected void OutputList(List<int> list) {
            Console.Write("List: ");
            foreach (var l in list) {
                Console.Write(l + " ");
            }
            Console.WriteLine("");
        }
    }
}
