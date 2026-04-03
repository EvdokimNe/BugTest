using System;
using System.Collections.Generic;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Targeting.Contracts;
using _Test.Code.Features.Targeting.Models;
namespace _Test.Code.Features.Targeting
{
    public sealed class TargetSelectorService
    {
        private readonly Dictionary<Type, ITargetCollectorProcessor> _collectorProcessors = new();
        private readonly Dictionary<Type, ITargetSelectionStrategyProcessor> _strategyProcessors = new();
        private readonly List<TargetInfo> _buffer = new(64);

        public TargetSelectorService(
            IEnumerable<ITargetCollectorProcessor> collectorProcessors,
            IEnumerable<ITargetSelectionStrategyProcessor> strategyProcessors)
        {
            foreach (var collectorProcessor in collectorProcessors)
            {
                _collectorProcessors[collectorProcessor.CollectorType] = collectorProcessor;
            }

            foreach (var strategyProcessor in strategyProcessors)
            {
                _strategyProcessors[strategyProcessor.StrategyType] = strategyProcessor;
            }
        }

        public bool TrySelect(ITargetSelector selector, BugAgent requester, out TargetInfo target)
        {
            target = null;
            if (selector == null || selector.SelectionStrategy == null)
                return false;

            _buffer.Clear();

            var collectors = selector.Collectors;
            for (var i = 0; i < collectors.Count; i++)
            {
                var collector = collectors[i];
                if (collector == null)
                    continue;

                if (_collectorProcessors.TryGetValue(collector.GetType(), out var collectorProcessor))
                {
                    collectorProcessor.Collect(collector, requester, _buffer);
                }
            }

            if (!_strategyProcessors.TryGetValue(selector.SelectionStrategy.GetType(), out var strategyProcessor))
                return false;

            return strategyProcessor.TrySelect(selector.SelectionStrategy, requester, _buffer, out target);
        }
    }
}
