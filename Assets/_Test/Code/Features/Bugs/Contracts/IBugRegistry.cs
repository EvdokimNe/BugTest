using System.Collections.Generic;
using Test.Code.Features.Bugs.Models;
using Test.Code.Features.Bugs.Runtime;
using Test.Code.Features.Targeting.Models;

namespace Test.Code.Features.Bugs.Contracts
{
    public interface IBugRegistry
    {
        int Count { get; }
        IReadOnlyCollection<BugAgent> Bugs { get; }
        IReadOnlyList<BugAgent> Snapshot { get; }

        void BuildSnapshot();
        void Add(BugAgent bug);
        bool TryGet(InternalIntId bugId, out BugAgent bug);
        void Remove(InternalIntId bugId);
    }
}
