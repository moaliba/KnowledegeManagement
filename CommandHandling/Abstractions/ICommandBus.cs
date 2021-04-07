using System.Threading.Tasks;

namespace CommandHandling.Abstractions
{
    interface ICommandBus
    {
        public Task Send<Tcommand>(Tcommand command) where Tcommand : Acommand;
    }
}
