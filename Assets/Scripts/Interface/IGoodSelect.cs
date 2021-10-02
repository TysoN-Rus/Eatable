using EventBusSystem;

namespace Eatable
{
    internal interface IGoodSelect: IGlobalSubscriber
    {
        void GoodSelect();
    }
}