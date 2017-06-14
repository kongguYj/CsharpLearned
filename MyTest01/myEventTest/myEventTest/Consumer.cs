using System;
using System.Windows;

namespace myEventTest
{
    public class Consumer:IWeakEventListener
    {
        private string name;

        public Consumer (string name)
        {
            this.name = name;
        }

        public void NewCarIsHere(object sender,CarInfoEventArgs e)
        {
            Console.WriteLine("{0}: {1} 是新车", name, e.Car);
        }

        bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            NewCarIsHere(sender, e as CarInfoEventArgs);
            return true;
        }
    }
}
