﻿using EventHandling.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace DomainModel
{
    public abstract class AggregateRoot
    {

        public Guid Id { get; }
        public AggregateRoot(Guid id)
        => Id = id;

        [Obsolete("For EF use")]
        protected AggregateRoot() { }

        List<AnEvent> events = new();
        public IEnumerable<AnEvent> Events => events;

        protected void RecordThat(AnEvent @event)
        {
            events.Add(@event);
            On(@event);
        }
        void On(AnEvent @event)
        {
            var method = GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                            .FirstOrDefault(m => m.Name == "On"
                            && m.GetParameters().Length == 1
                            && m.GetParameters()[0].ParameterType == @event.GetType());
            if (method == null)
                return;
            //    throw new InvalidOperationException($"the handler On({@event.GetType().Name}) is not found in {this.GetType().Name}");
            //else
            method.Invoke(this, new object[] { @event });
        }

        public void ClearEvents()
            => events = new();

    }
}
