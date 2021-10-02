using EventBusSystem;

namespace Eatable
{
    internal interface IStopTimer : IGlobalSubscriber
    {
        void Stop();
    }
}