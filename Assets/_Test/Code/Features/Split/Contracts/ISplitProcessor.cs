using System;
using Test.Code.Features.Bugs.Models;
using Test.Code.Features.Bugs.Runtime;

namespace Test.Code.Features.BugLifecycle.Runtime
{
    public interface ISplitProcessor
    {
        Type ConfigType { get; }
        void Resolve(BugAgent bug, int populationCount, out BugKind firstChildKind, out BugKind secondChildKind);
    }
}
