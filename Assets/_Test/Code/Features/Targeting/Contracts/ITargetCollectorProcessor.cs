using System;
using System.Collections.Generic;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Targeting.Models;
namespace _Test.Code.Features.Targeting.Contracts
{
    public interface ITargetCollectorProcessor
    {
        Type CollectorType { get; }
        void Collect(ITargetCollector collector, BugAgent requester, List<TargetInfo> buffer);
    }
}
