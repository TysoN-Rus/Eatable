using EventBusSystem;

namespace Eatable
{
    internal interface IResetTimer : IGlobalSubscriber
    {
        void Reset();
    }
}