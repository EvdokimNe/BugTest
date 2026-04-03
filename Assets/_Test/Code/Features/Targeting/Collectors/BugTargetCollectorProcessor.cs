using System;
using System.Collections.Generic;
using _Test.Code.Features.Bugs.Contracts;
using _Test.Code.Features.Bugs.Models;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Targeting.Contracts;
using _Test.Code.Features.Targeting.Models;
using _Test.Code.Shared;
namespace _Test.Code.Features.Targeting.Collectors
{
    public sealed class BugTargetCollectorProcessor : ITargetCollectorProcessor
    {
        private readonly IBugRegistry _bugRegistry;

        public Type CollectorType => typeof(BugTargetCollector);

        public BugTargetCollectorProcessor(IBugRegistry bugRegistry)
        {
            _bugRegistry = bugRegistry;
        }

        public void Collect(ITargetCollector collector, BugAgentContainer requester, List<TargetInfo> buffer)
        {
            if (collector is not BugTargetCollector bugCollector || bugCollector.TargetKindsMask == BugKind.None)
                return;

            foreach (var bug in _bugRegistry.Snapshot)
            {
                if (!bug.RuntimeData.IsAlive || bug.Id.Equals(requester.Id))
                    continue;

                if ((bugCollector.TargetKindsMask & bug.Kind) == 0)
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
