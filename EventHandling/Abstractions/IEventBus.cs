using System.Threading.Tasks;

namespace EventHandling.Abstractions
{
    public interface IEventBus
    {
        public Task Publish<TEvent>(TEvent Event) where TEvent : AnEvent;
    }
}