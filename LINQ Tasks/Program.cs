using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Tasks {
    class Program {
        static void Main(string[] args) {
            //Linq1();
            //Linq2();
            //Linq3();
            //Linq4();
            //Linq5();
            //Linq6();
            //Linq7();
            //Linq8();
            //Linq9();
        }

        #region someMethods

        static int EnterDigit() {
            int num;
            string input;
            do {
                Console.WriteLine("Введите цифру");
                input = Console.ReadLine();
            } while ((!Int32.TryParse(input, out num) && num < 10 && num > -1));
            return num;
        }
        static int NumberInput() {
            int num;
            string input;
            while (!Int32.TryParse(Console.ReadLine(), out num)) {
                Console.WriteLine("Введите число");
                input = Console.ReadLine();
            }
            return num;
        }

        static List<int> AddNumToList(List<int> list) {
            Random rand = new Random();
            for (int i = 0; i < 15; i++) {
                list.Add(rand.Next(-250, 250));
            }
            return list;
        }

        static void OutputList<T>(List<T> list) {

            if (IsListEmpty(list))
                return;

            string str = null;

            foreach (var v in list) {
                str += v + ", ";
            }

            Console.WriteLine("List: " + str.Substring(0, str.Length - 2));
        }

        static List<string> EnterStringSequence() {
            List<string> list = new List<string>();
            char separator = ' ';
            string[] strArray;
            do {
                Console.Write("Введите строки через пробелы: ");
   
                strArray = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
             
                for (int i = 0; i < strArray.Length; i++) {
                    list.Add(strArray[i]);
                }
            } while (IsListEmpty(list));
            
            return list;
        }

        static char EnterSymbol() {
            char c;
            string str;
            do {
                Console.Write("Введите символ: ");
                str = Console.ReadLine();
            } while (str.Length > 1 && str.Length < 1);

            c = Convert.ToChar(str);

            return c;
        }

        static bool IsListEmpty<T>(List<T> list) {
            if(list.Count == 0) {
                return true;
            } else {
                return false;
            }
            
        }
        #endregion

        #region Linq1
        static void Linq1() {
            /* Дана целочисленная последовательность,
             * содержащая как положительные, так и отрицательные числа.
             * Вывести ее первый положительный элемент и
             * последний отрицательный элемент.
             */

            List<int> sequence = new List<int>();

            sequence = AddNumToList(sequence);
            OutputList<int>(sequence);
            Console.WriteLine("first positive: {0}, last nagative: {1}", sequence.First(i => i > 0), sequence.Last(i => i < 0));
        }
        #endregion

        #region Linq2
        static void Linq2() {
            /* Дана цифра D(однозначное целое число) и целочисленная последовательность A.
             * Вывести первый положительный элемент последовательности A,
             * оканчивающийся цифрой D.
             * Если требуемых элементов в последовательности A нет, то вывести 0.
             */

            List<int> sequence = new List<int>();

            sequence = AddNumToList(sequence);

            OutputList<int>(sequence);
            
            int n = EnterDigit();
            Console.WriteLine(sequence.FirstOrDefault(i => (i % 10 == n)));
        }
        #endregion

        #region Linq3
        static void Linq3() {
            /* Дано целое число L(> 0) и строковая последовательность A.
             * Вывести последнюю строку из A, начинающуюся с цифры и имеющую длину L.
             * Если требуемых строк в последовательности A нет,
             * то вывести строку «Not found».
             * Указание.Для обработки ситуации, связанной с отсутствием
             * требуемых строк, использовать операцию ??.
             */
            Console.Write("Введите целое число больше ноля: ");
            int n = Convert.ToInt32(Console.ReadLine());

            List<string> list = EnterStringSequence();

            string result = list.LastOrDefault(s => s.Length == n && IsDigit(s[0]));


            Console.WriteLine(result ?? "Not found.");

            static bool IsDigit(char c) {

                for (char a = '0'; a <= '9'; a++) {
                    if (c == a)
                        return true;
                }

                return false;
            }

        }
        #endregion

        #region Linq4

        /* Дан символ С и строковая последовательность A.
         * Если A содержит единственный элемент, оканчивающийся символом C, 
         * то вывести этот элемент; если требуемых строкв A нет, 
         * то вывести пустую строку; если требуемых строк больше одной,
         * то вывести строку «Error».
         * Указание. Использовать try-блок для перехвата возможного исключения.
         */


        static void Linq4() {
            char c = EnterSymbol();

            List<string> list = EnterStringSequence();

            try {
                string result = list.SingleOrDefault(s => s.EndsWith(c));
                Console.WriteLine(result ?? "*пустая строка*");
            } catch (InvalidOperationException) {
                Console.WriteLine("Error");
            }
        }

        #endregion

        #region Linq5
        /* Дан символ С и строковая последовательность A.
         * Найти количество элементов A, которые содержат более одного символа
         * и при этом начинаются и оканчиваются символом C.
         */
        static void Linq5() {
            char c = EnterSymbol();

            List<string> list = EnterStringSequence();

            int result = list.Where(s => s.Length > 1 && s.EndsWith(c)).Count();

            Console.WriteLine(result);

        }
        #endregion

        #region Linq6

        /*Дана строковая последовательность. 
         * Найти сумму длин всех строк, входящих в данную последовательность.
         */
        static void Linq6() {
            List<string> list = EnterStringSequence();

            string concat = list.Aggregate((s, ss) => s + ss);
            int fullLength = list.Sum(s => s.Length);

            Console.WriteLine("Сумма как конкатенация: {0}\n" +
                "Сумма как общая длина строк: {1}", concat, fullLength);
        }
        #endregion

        #region Linq7
        /* Дана целочисленная последовательность. 
         * Найти количество ее отрицательных элементов, а также их сумму.
         * Если отрицательные элементы отсутствуют, то дважды вывести 0.
         */

        static void Linq7() {
            List<int> sequence = new List<int>();

            sequence = AddNumToList(sequence);
            //sequence.Add(10);

            OutputList(sequence);

            int resCount = sequence.Where(i => i < 0).Count();
            int resSum = sequence.Where(i => i < 0).Sum();
            if (resCount == 0) {
                Console.WriteLine("0");
                Console.WriteLine("0");
            } else {
                Console.WriteLine("Отрицательные элементы. Количество: {0}, Сумма: {1}", resCount, resSum);
            }
        }
        #endregion

        #region Linq8
        /* Дана целочисленная последовательность. 
         * Найти количество ее положительных двузначных элементов,
         * а также их среднее арифметическое (как вещественное число).
         * Если требуемые элементы отсутствуют, то дважды вывести 0
         * (первый раз как целое, второй — как вещественное).
         */
        static void Linq8() {
            List<int> sequence = new List<int>();

            sequence = AddNumToList(sequence);
            //sequence.Add(-100);
            //sequence.Add(0);
            OutputList(sequence);

            int resCount;
            double resAvg;

            resCount = sequence.Where(i => i > 0 && i / 10 < 10 && i / 10 > 0).Count();
            if (resCount == 0) {
                Console.WriteLine(0);
                Console.WriteLine((double)0);
            } else {
                resAvg = sequence.Where(i => i > 0 && i / 10 < 10 && i / 10 > 0).Average();

                Console.WriteLine("Положительные двузначеные.\n" +
                    "Количество: {0}\n" +
                    "Среднее арфметическое: {1}", resCount, resAvg);
            }
        }

        #endregion

        #region Linq9
        /*Дана целочисленная последовательность. 
         * Вывести ее минимальный положительный элемент или число 0,
         * если последовательность не содержит положительных элементов
         */
        static void Linq9() {
            List<int> sequence = new List<int>();

            sequence = AddNumToList(sequence);
            
            OutputList(sequence);

            try {
                Console.WriteLine(sequence.Where(i => i > 0).Min());
            } catch (Exception) {
                Console.WriteLine(0);
            }

        }
        #endregion

    }
}
