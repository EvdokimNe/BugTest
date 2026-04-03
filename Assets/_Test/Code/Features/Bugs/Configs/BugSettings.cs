using _Test.Code.Features.Movement.Models;
using _Test.Code.Features.Split.Contracts;
namespace _Test.Code.Features.Bugs.Configs
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
