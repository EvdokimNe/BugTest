using System.Collections.Generic;
using Test.Code.Features.Targeting.Contracts;

namespace Test.Code.Features.Targeting.Runtime.Selectors
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
