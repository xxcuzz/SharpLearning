using System;

namespace sharpLearning {
    public delegate void MyDelegate();
    class delegates {

        public delegate int ValueDelegate(int i);

        static void Main(string[] args) {
            //1 way
            MyDelegate myDelegate = Method1;
            myDelegate += Method4;
            myDelegate();

            //2 way
            MyDelegate myDelegate1 = new MyDelegate(Method4);
            myDelegate1.Invoke();

            MyDelegate myDelegate3 = new MyDelegate(myDelegate + myDelegate1);
            //myDelegate3.Invoke();


            var valueDelegate = new ValueDelegate(MethodValue);
            valueDelegate += MethodValue;
            valueDelegate += MethodValue;
            valueDelegate += MethodValue;
            valueDelegate += MethodValue; //вызовится много раз, но возвратит последнее

            valueDelegate((new Random().Next(10, 50)));



            //шаблонные делегаты
            Action action = Method1; //ничего не возвращает, принимает от 0 до 16и аргументов
            action();

            Predicate<int> predicate;
            predicate = Method2;

            Func<int, string> func; //public delegate int Func(string value)

        }

        public static int MethodValue(int i) {
            Console.WriteLine(i);
            return 0;
        }

        public static void Method1() {
            Console.WriteLine("Method1");
        }

        public static bool Method2(int i) {
            Console.WriteLine("Method1");
            return true;
        }
        public static void Method3(int i) {
            Console.WriteLine("Method3");
        }
        public static void Method4() {
            Console.WriteLine("Method4");
        }

    }
}
