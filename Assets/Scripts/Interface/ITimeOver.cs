using EventBusSystem;

namespace Eatable
{
    internal interface ITimeOver : IGlobalSubscriber
    {
        void TimeOver();
    }
}