using _Test.Code.Features.Targeting.Models;
namespace _Test.Code.Features.Bugs.States
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
