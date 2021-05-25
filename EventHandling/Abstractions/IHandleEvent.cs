using System.Threading.Tasks;

namespace EventHandling.Abstractions
{
    public interface IHandleEvent<in TEvent> where TEvent : AnEvent
    {
        Task Handle(TEvent e);
    }
}