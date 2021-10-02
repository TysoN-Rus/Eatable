using EventBusSystem;

namespace Eatable
{
    internal interface IFailSelect : IGlobalSubscriber
    {
        void FailSelect();
    }
}