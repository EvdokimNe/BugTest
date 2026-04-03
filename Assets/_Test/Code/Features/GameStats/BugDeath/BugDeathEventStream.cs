using Test.Code.Features.Bugs.Models;
using R3;

namespace Test.Code.Features.Bugs.Runtime
{
    public sealed class BugDeathEventStream
    {
        public Subject<BugKind> BugDied { get; } = new();
    }
}
