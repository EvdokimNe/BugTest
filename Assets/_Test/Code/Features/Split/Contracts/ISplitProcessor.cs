using System;
using _Test.Code.Features.Bugs.Models;
using _Test.Code.Features.Bugs.Runtime;
namespace _Test.Code.Features.Split.Contracts
{
    public interface ISplitProcessor
    {
        Type ConfigType { get; }
        void Resolve(BugAgentContainer bug, int populationCount, out BugKind firstChildKind, out BugKind secondChildKind);
    }
}
