using _Test.Code.Features.Movement.Contracts;
using _Test.Code.Features.Movement.Models;
using UnityEngine;
namespace _Test.Code.Features.Movement.Runtime
{
    public sealed class GroundXZMovementStrategy : IMovementStrategy
    {
        private readonly BaseMoveData _moveData;

        public GroundXZMovementStrategy(BaseMoveData moveData)
        {
            _moveData = moveData;
        }

        public void MoveTowards(Transform body, Vector3 targetPosition)
        {
            var currentPosition = body.position;
            var destination = new Vector3(targetPosition.x, currentPosition.y, targetPosition.z);
            var nextPosition = Vector3.MoveTowards(currentPosition, destination, _moveData.Speed * Time.deltaTime);
            var moveDirection = nextPosition - currentPosition;

            body.position = nextPosition;

            if (moveDirection.sqrMagnitude > 0.0001f)
            {
                body.rotation = Quaternion.LookRotation(moveDirection.normalized, Vector3.up);
            }
        }

        public bool HasReached(Vector3 currentPosition, Vector3 targetPosition, float stopDistance)
        {
            var currentXZ = new Vector2(currentPosition.x, currentPosition.z);
            var targetXZ = new Vector2(targetPosition.x, targetPosition.z);
            return Vector2.Distance(currentXZ, targetXZ) <= stopDistance;
        }
    }
}
