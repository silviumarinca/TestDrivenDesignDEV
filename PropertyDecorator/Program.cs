using System;

namespace PropertyDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class ComponentDecorator : IComponent
    {
        private readonly IComponent decoratedComponent;
        public ComponentDecorator(IComponent decoratedComponent)
        {
            this.decoratedComponent = decoratedComponent;
        }
       public string Property {
            get {

                return decoratedComponent.Property;
            }
            set {
                decoratedComponent.Property = value;
            }

        }
    }
    public interface IComponent
    {
          string Property { get; set; }

    }

}
