using System;
using System.IO;

namespace files {
    class Program {
        static void Main(string[] args) {


            Person person = new Person();

            Console.WriteLine("Enter your age: ");

            person.Age = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter your name: ");
            person.Name = Console.ReadLine();

            using (var sw = new StreamWriter("person.txt",true)) {
                sw.WriteLine($"Username: {person.Name}, Age: {person.Age}");
            }

            using (var sr = new StreamReader("person.txt")) {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
    }
}
