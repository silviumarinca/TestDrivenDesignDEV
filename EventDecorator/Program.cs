using System;

namespace EventDecorator
{
    class Program
    {
        public class X {
            public int nr;
        }
        static void Main(string[] args)
        {   
            X a = new X {nr = 2 };
            a = null;
            var x = a as X;
            Console.WriteLine("Hello World! {0}",x.nr);
        }
    }

    public interface IComponent {

        event EventHandler Event;

    }


    public class ComponentDecorator : IComponent
    {
        private readonly IComponent componentDecorator;
        public ComponentDecorator(IComponent cmponentDecorator)
        {
            this.componentDecorator = cmponentDecorator;

        }


        public event EventHandler Event {

            add { componentDecorator.Event += value; }
            remove { componentDecorator.Event -= value; }

        }
    }
}
