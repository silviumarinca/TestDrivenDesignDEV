using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationPrinciple.EventSubscribers
{
    public interface IEventPublisher
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
    public interface IEventSubscriber 
    {

        void Subscribe<TEvent>(TEvent @event) where TEvent : IEvent;
    
    }


    public interface IEvent  {
          string Name { get; set; }

    }


}
