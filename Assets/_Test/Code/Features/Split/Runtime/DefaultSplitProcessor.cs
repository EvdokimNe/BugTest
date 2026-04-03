using System;
using Test.Code.Features.Bugs.Models;
using Test.Code.Features.Bugs.Runtime;

namespace Test.Code.Features.BugLifecycle.Runtime
{
    public sealed class DefaultSplitProcessor : ISplitProcessor
    {
        public Type ConfigType => typeof(DefaultSplit);

        public void Resolve(BugAgent bug, int populationCount, out BugKind firstChildKind, out BugKind secondChildKind)
        {
            firstChildKind = bug.RuntimeData.Kind;
            secondChildKind = bug.RuntimeData.Kind;
        }
    }
}
