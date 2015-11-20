using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExITO
{
    delegate void MyDelegate();
    class Celebrity //Subject or Broadcaster or Publisher
    {
        public event MyDelegate fansToNotify;

        //Event
        public void Suicide()
        {
            Console.WriteLine("I am Dead");
            fansToNotify();
        }
    }
    class HappyFan //Observer or Receiver or Listener
    {
        public void Register(Celebrity c)
        {
            c.fansToNotify += Laugh;
        }
        public void Laugh()
        {
            Console.WriteLine("Very Happy");

        }
       
    }

    class SadFan //Observer or Receiver or Listener
    {
        public void Register(Celebrity c)
        {
            c.fansToNotify += Weep;
        }
        public void Weep()
        {
            Console.WriteLine("So Sad");

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //A celebrity
            Celebrity tomCruise = new Celebrity();

            //some fans
            HappyFan fan1 = new HappyFan();
            HappyFan fan2 = new HappyFan();
            SadFan fan3 = new SadFan();
            SadFan fan4 = new SadFan();

          

            //fans registering against an event in celebrity life so that they can be notified when that event occurs
            fan1.Register(tomCruise);
            fan2.Register(tomCruise);
            fan3.Register(tomCruise);
            fan4.Register(tomCruise);
            
            //triggering the event
            tomCruise.Suicide();

           
        }
    }
}
