using System.Collections.Generic;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Targeting.Models;
namespace _Test.Code.Features.Bugs.Contracts
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
