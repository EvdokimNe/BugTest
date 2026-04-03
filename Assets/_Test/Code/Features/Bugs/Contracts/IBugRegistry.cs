using System.Collections.Generic;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Targeting.Models;
namespace _Test.Code.Features.Bugs.Contracts
{
    public interface IBugRegistry
    {
        int Count { get; }
        IReadOnlyCollection<BugAgentContainer> Bugs { get; }
        IReadOnlyList<BugAgentContainer> Snapshot { get; }

        void BuildSnapshot();
        void Add(BugAgentContainer bug);
        bool TryGet(InternalIntId bugId, out BugAgentContainer bug);
        void Remove(InternalIntId bugId);
    }
}
