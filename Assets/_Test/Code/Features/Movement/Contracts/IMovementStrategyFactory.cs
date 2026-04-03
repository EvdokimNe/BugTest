using Test.Code.Features.Movement.Models;

namespace Test.Code.Features.Movement.Contracts
{
    public interface IMovementStrategyFactory
    {
        IMovementStrategy Create(BaseMoveData moveData);
    }
}
