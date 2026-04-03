using System;
using System.Collections.Generic;
using Test.Code.Features.Bugs.Runtime;
using Test.Code.Features.Targeting.Models;

namespace Test.Code.Features.Targeting.Contracts
{
    public interface ITargetSelectionStrategyProcessor
    {
        Type StrategyType { get; }
        bool TrySelect(ITargetSelectionStrategy strategy, BugAgent requester, IReadOnlyList<TargetInfo> candidates, out TargetInfo target);
    }
}
