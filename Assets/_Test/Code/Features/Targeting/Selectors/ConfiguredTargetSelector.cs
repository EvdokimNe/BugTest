using System.Collections.Generic;
using _Test.Code.Features.Targeting.Contracts;
namespace _Test.Code.Features.Targeting.Selectors
{
    public sealed class ConfiguredTargetSelector : ITargetSelector
    {
        public IReadOnlyList<ITargetCollector> Collectors { get; }
        public ITargetSelectionStrategy SelectionStrategy { get; }

        public ConfiguredTargetSelector(IReadOnlyList<ITargetCollector> collectors, ITargetSelectionStrategy selectionStrategy)
        {
            Collectors = collectors;
            SelectionStrategy = selectionStrategy;
        }
    }
}
