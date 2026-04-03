using Test.Code.Features.Targeting.Models;

namespace Test.Code.Features.Bugs.Runtime
{
    public sealed class EatingStateContext
    {
        public TargetInfo CurrentTarget { get; set; }

        public bool HasTarget => CurrentTarget != null;

        public void Clear()
        {
            CurrentTarget = null;
        }
    }
}
