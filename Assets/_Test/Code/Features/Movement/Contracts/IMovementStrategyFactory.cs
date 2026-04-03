using _Test.Code.Features.Movement.Models;
namespace _Test.Code.Features.Movement.Contracts
{
    public interface IMovementStrategyFactory
    {
        IMovementStrategy Create(BaseMoveData moveData);
    }
}
