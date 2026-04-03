using UnityEngine;
namespace _Test.Code.Features.Movement.Contracts
{
    public interface IMovementStrategy
    {
        void MoveTowards(Transform body, Vector3 targetPosition);
        bool HasReached(Vector3 currentPosition, Vector3 targetPosition, float stopDistance);
    }
}
