using Test.Code.Features.Bugs.Models;
using Test.Code.Features.Targeting.Contracts;

namespace Test.Code.Features.Targeting.Runtime.Collectors
{
    public sealed class BugTargetCollector : ITargetCollector
    {
        public BugKind TargetKindsMask { get; }

        public BugTargetCollector(BugKind targetKindsMask)
        {
            TargetKindsMask = targetKindsMask;
        }
    }
}
