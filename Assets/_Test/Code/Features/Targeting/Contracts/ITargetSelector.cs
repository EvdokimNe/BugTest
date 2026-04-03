using System.Collections.Generic;
namespace _Test.Code.Features.Targeting.Contracts
{
    public interface ITargetSelector
    {
        IReadOnlyList<ITargetCollector> Collectors { get; }
        ITargetSelectionStrategy SelectionStrategy { get; }
    }
}
