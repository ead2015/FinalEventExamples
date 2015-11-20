using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace EventArrayListExample
{
  
        delegate void MyEventHandler();

        class MyArrayList : ArrayList
        {
            public event MyEventHandler Added;

            private void OnAdded()
            {
                if (Added != null)
                {
                    Added();
                }
            }
            public override int Add(object value)
            {
                OnAdded();
                return base.Add(value);
            }


        }
        class Program
        {
            static void Main(string[] args)
            {
                MyArrayList list = new MyArrayList();
                list.Added += () => Console.WriteLine("Added Event Fired");
                list.Add(1);
            }
        }
    }


