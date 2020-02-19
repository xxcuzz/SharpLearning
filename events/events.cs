using System;

namespace events {
    class events {
        //public event Action action;

        //public event EventHandler DoWork;
        static void Main(string[] args) {

            Person p = new Person();
            p.Name = "vasya";


            //subscribed to the event that the person went to work
            p.DoWork += P_DoWork;


            //subscribed to the event that the person went to sleep
            p.GoToSleep += P_GoToSleep;

            p.TakeTime(DateTime.Parse("15.02.2020 16:46:00"));

            p.TakeTime(DateTime.Parse("15.02.2020 6:46:00"));

        }

        private static void P_DoWork(object sender, EventArgs e) {

            if (sender is Person) {
                Console.WriteLine($"{((Person)sender).Name} работает работу");
            }
        }

        //event handler
        private static void P_GoToSleep() {
            Console.WriteLine("person go to sleep");
        }
    }
}
