using System;
using System.Collections.Generic;
using System.Text;

namespace files {
    class Person {
        public string Name { get; set; }
        private int age;
        public int Age {
            get {
                return age;
            }
            set {
                if (age < 0) {
                    Console.WriteLine("Age must be greater than 0");
                }else if (age > 150) {
                    Console.WriteLine("Age should be less than 150");
                } else {
                    age = value;
                }
            }
        }
    }
}
