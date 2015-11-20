using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    delegate void MyEventHandler();
    
    //Publisher Class
    class Button {
        //An event always belongs to some class
        public event MyEventHandler click;

        public void OnClick()
        {
            if (click != null)
            {
                click();
            }
        }


    }
    class HandlerClass
    {

        public void EventHandlerFunction()
        {
            Console.WriteLine("Event Handler get called");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Button b = new Button();
            //registering the event handler
            b.click += delegate
            {
                Console.WriteLine("Event occured");
            };
            //registering the event handler
            b.click += () => Console.WriteLine("Event Occured and we are in lambda handler");
            
            HandlerClass o = new HandlerClass();
            //registering the event handler
            b.click += o.EventHandlerFunction;
            //firing the event
            b.OnClick();
        }
    }
}
