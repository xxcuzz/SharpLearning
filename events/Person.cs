using System;
using System.Collections.Generic;
using System.Text;

namespace events {
    class Person {
        public event Action GoToSleep;
        public event EventHandler DoWork;

        public string Name { get; set; }

        public void TakeTime(DateTime now) {
            if(now.Hour <= 8) {
                GoToSleep?.Invoke(); //we notify all subscribers that an event has occurred
            } else {
                var args = new EventArgs();
                DoWork?.Invoke(this, args);
            }
        }
    }
}
