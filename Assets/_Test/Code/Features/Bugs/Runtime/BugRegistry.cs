using System.Collections.Generic;
using Test.Code.Features.Bugs.Contracts;
using Test.Code.Features.Bugs.Models;
using Test.Code.Features.Targeting.Models;

namespace Test.Code.Features.Bugs.Runtime
{
    public sealed class BugRegistry : IBugRegistry
    {
        private readonly Dictionary<InternalIntId, BugAgent> _bugs = new Dictionary<InternalIntId, BugAgent>(64);
        private readonly List<BugAgent> _snapshot = new(64);

        public int Count => _bugs.Count;
        public IReadOnlyCollection<BugAgent> Bugs => _bugs.Values;
        public IReadOnlyList<BugAgent> Snapshot => _snapshot;

        public void BuildSnapshot()
        {
            _snapshot.Clear();

            foreach (var bug in _bugs.Values)
            {
                _snapshot.Add(bug);
            }
        }

        public void Add(BugAgent bug)
        {
            _bugs[bug.Id] = bug;
        }

        public bool TryGet(InternalIntId bugId, out BugAgent bug)
        {
            return _bugs.TryGetValue(bugId, out bug);
        }

        public void Remove(InternalIntId bugId)
        {
            _bugs.Remove(bugId);
        }
    }
}
