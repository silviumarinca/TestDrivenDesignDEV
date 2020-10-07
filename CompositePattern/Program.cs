using System;
using System.Collections.Generic;

namespace CompositePattern
{
    class Program
    {
        static IComponent component;
        static void Main(string[] args)
        {
            var composite = new CompositeComponent();
            composite.AddComponent(new Leaf());
            composite.AddComponent(new SecondLeaf());
            composite.AddComponent(new ThirdLeaf()); 

        

            component = composite;

            component.Something();

        }
    }

    public interface IComponent {

        void Something();
    }

    public class Leaf : IComponent
    {
        public void Something()
        {
            Console.WriteLine("Leaf");
        }
    }
    public class SecondLeaf : IComponent
    {
        public void Something()
        {
            Console.WriteLine("Leaf 2");
        }
    }

    public class ThirdLeaf : IComponent
    {
        public void Something()
        {
            Console.WriteLine("Leaf 3");
        }
    }
    public class CompositeComponent:IComponent {
        private List<IComponent> children;
        public CompositeComponent()
        {
            children = new List<IComponent>();
        }
        public void AddComponent(IComponent component)
        {
            children.Add(component);

        }
        public void RemoveComponent(IComponent component) {
            children.Remove(component);

        }

        public void Something()
        {
            foreach (var child in children) {

                child.Something();
            }
        }
    }
}
