using System;

namespace Test.Code.Features.Bugs.Models
{
    [Flags]
    public enum BugKind
    {
        None = 0,
        Worker = 1 << 0,
        Predator = 1 << 1,
        All = Worker | Predator
    }
}
