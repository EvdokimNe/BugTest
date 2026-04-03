using System;
using System.Collections.Generic;
using Test.Code.Features.Bugs.Runtime;
using Test.Code.Features.Targeting.Contracts;
using Test.Code.Features.Targeting.Models;
using Random = UnityEngine.Random;

namespace Test.Code.Features.Targeting.Runtime
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
