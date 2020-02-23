using System;
using System.Collections.Generic;
using System.Linq;
/*



LinqBegin6. 
LinqBegin7. 
LinqBegin8. 
LinqBegin9. 
*/
namespace LINQ_Tasks {
    class Program {
        static void Main(string[] args) {
            //Linq1();
            //Linq2();
            //Linq3();
            //Linq4();
            
            Linq5();
            //Linq6();
            //Linq7();
            //Linq8();
            //Linq9();

        }


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

        static List<int> AddNumToList(List<int> list) {
            Random rand = new Random();
            for (int i = 0; i < 15; i++) {
                list.Add(rand.Next(-250, 250));
            }
            return list;
        }

        static void OutputList<T>(List<T> list) {
            Console.Write("List: ");

            foreach (var v in list) {
                Console.Write(v + ", ");
            }

            Console.WriteLine("");
        }

        #endregion

        #region Linq2
        static void Linq2() {
            /* Дана цифра D(однозначное целое число) и
             * целочисленная последовательность A.
             * Вывести первый положительный элемент последовательности A,
             * оканчивающийся цифрой D.
             * Если требуемых элементов в последовательностиA нет, то вывести 0.
             */

            List<int> sequence = new List<int>();

            sequence = AddNumToList(sequence);
            OutputList<int>(sequence);
            int n = Convert.ToInt32(Console.ReadLine());
            Linq2_Inner(sequence, n);
        }
        static void Linq2_Inner(List<int> list, int n) {
            var result = list.FirstOrDefault(i => (i % 10 == n));
            Console.WriteLine(result);
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

            Console.Write("Введите строки через пробелы: ");

            char separator = ' ';
            string[] strArray = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

            List<string> list = new List<string>();

            for (int i = 0; i < strArray.Length; i++) {
                list.Add(strArray[i]);
            }

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
            Console.Write("Введите символ: ");
            char c = Convert.ToChar(Console.ReadLine());

            Console.Write("Введите строки через пробелы: ");

            char separator = ' ';
            string[] strArray = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

            List<string> list = new List<string>();

            for (int i = 0; i < strArray.Length; i++) {
                list.Add(strArray[i]);
            }

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


        }
        #endregion

        #region Linq6

        /*Дана строковая последовательность. 
         * Найти сумму длин всех строк, входящих в данную последовательность.
         */
        static void Linq6() {

        }
        #endregion

        #region Linq7
        /* Дана целочисленная последовательность. 
         * Найти количество ее отрицательных элементов, а также их сумму.
         * Если отрицательные элементы отсутствуют, то дважды вывести 0.
         */

        static void Linq7() {

        }
        #endregion

        #region Linq8
        /* Дана целочисленная последовательность. 
         * Найтиколичество ее положительных двузначных элементов,
         * а также их среднее арифметическое (как вещественное число).
         * Если требуемые элементы отсутствуют, то дважды вывести 0
         * (первый раз как целое, второй — как вещественное).
         */
        static void Linq8() {

        }

        #endregion

        #region Linq9
        /*Дана целочисленная последовательность. 
         * Вывести ее минимальный положительный элемент или число 0,
         * если последовательность не содержит положительных элементов
         */
        static void Linq9() {

        }
        #endregion

    }
}
