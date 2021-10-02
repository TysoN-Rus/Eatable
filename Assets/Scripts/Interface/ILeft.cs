using EventBusSystem;

namespace Eatable
{
    internal interface ILeft : IGlobalSubscriber
    {
        void Left();
    }
}