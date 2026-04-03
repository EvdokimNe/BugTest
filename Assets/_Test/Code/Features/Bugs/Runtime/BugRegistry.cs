using System.Collections.Generic;
using _Test.Code.Features.Bugs.Contracts;
using _Test.Code.Features.Targeting.Models;
namespace _Test.Code.Features.Bugs.Runtime
{
    public sealed class BugRegistry : IBugRegistry
    {
        private readonly Dictionary<InternalIntId, BugAgentContainer> _bugs = new Dictionary<InternalIntId, BugAgentContainer>(64);
        private readonly List<BugAgentContainer> _snapshot = new(64);

        public int Count => _bugs.Count;
        public IReadOnlyCollection<BugAgentContainer> Bugs => _bugs.Values;
        public IReadOnlyList<BugAgentContainer> Snapshot => _snapshot;

        public void BuildSnapshot()
        {
            _snapshot.Clear();

            foreach (var bug in _bugs.Values)
            {
                _snapshot.Add(bug);
            }
        }

        public void Add(BugAgentContainer bug)
        {
            _bugs[bug.Id] = bug;
        }

        public bool TryGet(InternalIntId bugId, out BugAgentContainer bug)
        {
            return _bugs.TryGetValue(bugId, out bug);
        }

        public void Remove(InternalIntId bugId)
        {
            _bugs.Remove(bugId);
        }
    }
}
