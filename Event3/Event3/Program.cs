using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event3
{
    class MyEventArgs : EventArgs {

        //Auto Implemented Property
        public int Count { get; set; }
    }
    //define delegate
    delegate void EventHandler(object sender, MyEventArgs e);

    //Publisher Class
    class MyArrayList : System.Collections.ArrayList
    {
        //Event
        public event EventHandler Added;

        private int cnt = 1;
        private void OnAdded()
        {
            if (Added != null)
            {
                MyEventArgs e = new MyEventArgs();
                e.Count = cnt++;
                Added(this, e);
            }
        }

        public override int Add(object value)
        {
            OnAdded();
            return base.Add(value);
        }

    }
    //Listener/ Subscriber Class
    class Program
    {
        static void Main(string[] args)
        {
            MyArrayList list = new MyArrayList();

            //Registering the event Handler
            list.Added += list_Added;

            //Registering the event Handler
            list.Added += delegate(object sender, MyEventArgs e)
            {
                Console.WriteLine("I am in Anonymous Method and Item Added to List and Event Count  =" + e.Count);
            };

            list.Added += (object sender, MyEventArgs e) => {
                Console.WriteLine("I am in Lambda Statement and Item Added to List and Event Count  =" + e.Count);
            };

            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Add(1);

        }
        //Event Handler
        static void list_Added(object sender, MyEventArgs e)
        {
            Console.WriteLine("Item Added to List and Event Count  ="+ e.Count );
        }
    }
}
