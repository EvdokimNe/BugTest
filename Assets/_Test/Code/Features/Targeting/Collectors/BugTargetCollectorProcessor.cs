using System;
using System.Collections.Generic;
using Test.Code.Features.Bugs.Contracts;
using Test.Code.Features.Bugs.Models;
using Test.Code.Features.Bugs.Runtime;
using Test.Code.Features.Targeting.Contracts;
using Test.Code.Features.Targeting.Models;
using Test.Code.Features.Targeting.Runtime.Collectors;

namespace Test.Code.Features.Bugs.Runtime.Targeting
{
    public sealed class BugTargetCollectorProcessor : ITargetCollectorProcessor
    {
        private readonly IBugRegistry _bugRegistry;

        public Type CollectorType => typeof(BugTargetCollector);

        public BugTargetCollectorProcessor(IBugRegistry bugRegistry)
        {
            _bugRegistry = bugRegistry;
        }

        public void Collect(ITargetCollector collector, BugAgent requester, List<TargetInfo> buffer)
        {
            if (collector is not BugTargetCollector bugCollector || bugCollector.TargetKindsMask == BugKind.None)
                return;

            foreach (var bug in _bugRegistry.Snapshot)
            {
                if (!bug.RuntimeData.IsAlive || bug.Id.Equals(requester.Id))
                    continue;

                if ((bugCollector.TargetKindsMask & bug.RuntimeData.Kind) == 0)
                    continue;

                buffer.Add(TargetInfo.CreateBug(
                    bug.View.transform,
                    bug.View.transform.position,
                    bug.View.Radius,
                    new InternalIntId(bug.Id.Value)));
            }
        }
    }
}
