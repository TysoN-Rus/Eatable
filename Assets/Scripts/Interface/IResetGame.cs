using EventBusSystem;

namespace Eatable
{
    internal interface IResetGame: IGlobalSubscriber
    {
        void Reset();
    }
}