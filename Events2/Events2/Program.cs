using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events2
{
    //define delegate
    delegate void EventHandler(object sender, EventArgs e);

    

    //Publisher Class
    class MyArrayList : System.Collections.ArrayList {
        //Event
        public event EventHandler Added;

       
        private void OnAdded()
        {
            if (Added != null)
            {
                
                Added(this, EventArgs.Empty);
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

            list.Add(2);
            list.Add("some data");
            list.Add(3.45);


            //Registering the event Handler
            list.Added += list_Added;

            list.Added += delegate(object sender, EventArgs e)
            {
                Console.WriteLine("method");
            };

            list.Added += (object sender, EventArgs e) => {
                Console.WriteLine("Lambda Statement");
            };
            list.Add(1);

        }
        //Event Handler
        static void list_Added(object sender, EventArgs e)
        {
            Console.WriteLine("Item Added to List");
        }
    }
}
