using System;
using System.Collections.Generic;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Targeting.Models;
namespace _Test.Code.Features.Targeting.Contracts
{
    public interface ITargetSelectionStrategyProcessor
    {
        Type StrategyType { get; }
        bool TrySelect(ITargetSelectionStrategy strategy, BugAgent requester, IReadOnlyList<TargetInfo> candidates, out TargetInfo target);
    }
}
