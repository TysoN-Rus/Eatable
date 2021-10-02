using EventBusSystem;

namespace Eatable
{
    internal interface IGameOver : IGlobalSubscriber
    {
        void GameOver();
    }
}