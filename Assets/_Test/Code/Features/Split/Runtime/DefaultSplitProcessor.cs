using System;
using _Test.Code.Features.Bugs.Configs;
using _Test.Code.Features.Bugs.Models;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Split.Contracts;
namespace _Test.Code.Features.Split.Runtime
{
    public sealed class DefaultSplitProcessor : ISplitProcessor
    {
        public Type ConfigType => typeof(DefaultSplit);

        public void Resolve(BugAgentContainer bug, int populationCount, out BugKind firstChildKind, out BugKind secondChildKind)
        {
            firstChildKind = bug.RuntimeData.Kind;
            secondChildKind = bug.RuntimeData.Kind;
        }
    }
}
