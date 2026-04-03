using System.Collections.Generic;

namespace Test.Code.Features.Targeting.Contracts
{
    public interface ITargetSelector
    {
        IReadOnlyList<ITargetCollector> Collectors { get; }
        ITargetSelectionStrategy SelectionStrategy { get; }
    }
}
