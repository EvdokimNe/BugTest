using Test.Code.Features.Bugs.Models;
using Test.Code.Features.Targeting.Models;

namespace Test.Code.Features.Bugs.Runtime
{
    public sealed class BugIdProvider
    {
        private int _nextId = 1;

        public InternalIntId Create()
        {
            return new InternalIntId(_nextId++);
        }
    }
}
