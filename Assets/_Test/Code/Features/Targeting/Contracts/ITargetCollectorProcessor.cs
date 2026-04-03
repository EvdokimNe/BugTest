using System;
using System.Collections.Generic;
using Test.Code.Features.Bugs.Runtime;
using Test.Code.Features.Targeting.Models;

namespace Test.Code.Features.Targeting.Contracts
{
    public interface ITargetCollectorProcessor
    {
        Type CollectorType { get; }
        void Collect(ITargetCollector collector, BugAgent requester, List<TargetInfo> buffer);
    }
}
