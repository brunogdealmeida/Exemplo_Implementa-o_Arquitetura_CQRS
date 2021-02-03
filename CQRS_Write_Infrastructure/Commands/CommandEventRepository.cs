using CQRS_Write_Domain;
using CQRS_Write_Domain.Commands;
using CQRS_Write_Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Write_Infrastructure.Commands
{
    public class CommandEventRepository : ICommandEventRepository
    {
        private IEventPublisher eventPublisher;
        private Dictionary<object, List<IEvent>> aggregateEventDictionary = new Dictionary<object, List<IEvent>>();
        
        public CommandEventRepository(IEventPublisher eventPublisher)
        {
            this.eventPublisher = eventPublisher;
        }

        public T GetByCommandId<T>(object aggregateId) where T : IAggregateRoot
        {
            T aggregate = (T)Activator.CreateInstance(typeof(T));

            List<IEvent> aggregateEvents;

            if (aggregateEventDictionary.TryGetValue(aggregateId, out aggregateEvents))
            {
                aggregate.LoadFromHistory(aggregateEvents);
                return aggregate;
            }

            return default(T);
        }

        public IEnumerable<IEvent> GetEvents(object AggregateId)
        {
            List<IEvent> aggregateEvents;
            if (aggregateEventDictionary.TryGetValue(AggregateId, out aggregateEvents))
            {
                return aggregateEvents;
            }

            return new List<IEvent>();
        }

        public void Save(IAggregateRoot aggregate)
        {
            List<IEvent> aggregateEvents;
            if (!aggregateEventDictionary.TryGetValue(aggregate.GetId(), out aggregateEvents))
            {
                aggregateEvents = new List<IEvent>();
                aggregateEventDictionary.Add(aggregate.GetId(), aggregateEvents);
            }

            foreach (var @event in aggregate.GetUncommitedChanges())
            {
                aggregateEvents.Add(@event);
                this.eventPublisher.Publish(@event);
            }

            aggregate.MarkChangesAsCommited();
        }
    }
}
