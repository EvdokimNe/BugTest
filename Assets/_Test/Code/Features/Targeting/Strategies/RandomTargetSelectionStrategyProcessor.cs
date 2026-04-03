using System;
using System.Collections.Generic;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Targeting.Contracts;
using _Test.Code.Features.Targeting.Models;
using Random = UnityEngine.Random;

namespace _Test.Code.Features.Targeting.Strategies
{
    public sealed class RandomTargetSelectionStrategyProcessor : ITargetSelectionStrategyProcessor
    {
        public Type StrategyType => typeof(RandomTargetSelectionStrategy);

        public bool TrySelect(ITargetSelectionStrategy strategy, BugAgent requester, IReadOnlyList<TargetInfo> candidates, out TargetInfo target)
        {
            if (candidates == null || candidates.Count == 0)
            {
                target = null;
                return false;
            }

            target = candidates[Random.Range(0, candidates.Count)];
            return true;
        }
    }
}
