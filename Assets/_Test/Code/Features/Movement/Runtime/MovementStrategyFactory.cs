using Test.Code.Features.Movement.Contracts;
using Test.Code.Features.Movement.Models;

namespace Test.Code.Features.Movement.Runtime
{
    public sealed class MovementStrategyFactory : IMovementStrategyFactory
    {
        public IMovementStrategy Create(BaseMoveData moveData)
        {
            return moveData.Type switch
            {
                MovementType.GroundXZ => new GroundXZMovementStrategy(moveData),
                _ => new GroundXZMovementStrategy(moveData)
            };
        }
    }
}
