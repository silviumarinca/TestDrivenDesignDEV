using System;
using System.Collections.Generic;
using System.Text;

namespace SRPDecorator
{
    class ConcreteComponent : IComponent
    {
        public void Something()
        {
            throw new NotImplementedException();
        }
    }

    public class DecoratorComponent : IComponent {
        private readonly IComponent decoratedComponent;

        public DecoratorComponent(IComponent component)
        {
            decoratedComponent = component;
        }

        public void Something()
        {
            SomethingElse();
            decoratedComponent.Something();
        }
        private void SomethingElse(){

        }
    }
}
