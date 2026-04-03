using _Test.Code.Features.Bugs.Models;
using _Test.Code.Features.Targeting.Contracts;
namespace _Test.Code.Features.Targeting.Collectors
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
