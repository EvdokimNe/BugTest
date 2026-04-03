using Test.Code.Features.Movement.Models;
using Test.Code.Features.Bugs.Runtime;
using Test.Code.Features.Targeting.Contracts;

namespace Test.Code.Features.Bugs.Models
{
    public sealed class RuntimeData
    {
        public BugKind Kind { get; }
        public BugSettings Settings { get; }
        public ITargetSelector TargetSelector { get; }

        public int Satiety { get; set; }
        public bool IsAlive { get; set; }

        public RuntimeData(BugKind kind, BugSettings settings, ITargetSelector targetSelector)
        {
            Kind = kind;
            Settings = settings;
            TargetSelector = targetSelector;
            IsAlive = true;
        }
    }
}
