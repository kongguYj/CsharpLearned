using System;

namespace myEventTest
{
    public class CarInfoEventArgs : EventArgs
    {
        public string Car { get; private set; }
        public CarInfoEventArgs (string car)
        {
            this.Car = car;
        }
    }
}
