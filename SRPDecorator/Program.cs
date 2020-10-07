using System;

namespace SRPDecorator
{
    class Program
    {
        static IComponent component;
        static void Main(string[] args)
        {
            component = new DecoratorComponent(new ConcreteComponent());
            component.Something();
        }
    }
}
