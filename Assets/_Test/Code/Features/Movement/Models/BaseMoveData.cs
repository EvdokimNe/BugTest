namespace Test.Code.Features.Movement.Models
{
    public class BaseMoveData
    {
        public MovementType Type { get; }
        public float Speed { get; }

        public BaseMoveData(MovementType type, float speed)
        {
            Type = type;
            Speed = speed;
        }
    }
}
