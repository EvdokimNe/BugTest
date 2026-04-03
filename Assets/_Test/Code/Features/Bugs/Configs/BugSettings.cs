using Test.Code.Features.Movement.Models;

namespace Test.Code.Features.Bugs.Runtime
{
    public sealed class BugSettings
    {
        public BaseMoveData MoveData { get; }
        public int SplitSatiety { get; }
        public float LifetimeSeconds { get; }
        public ISplitBehavior SplitBehavior { get; }

        public BugSettings(
            BaseMoveData moveData,
            int splitSatiety,
            float lifetimeSeconds,
            ISplitBehavior splitBehavior)
        {
            MoveData = moveData;
            SplitSatiety = splitSatiety;
            LifetimeSeconds = lifetimeSeconds;
            SplitBehavior = splitBehavior;
        }
    }
}
