using _Test.Code.Features.Targeting.Models;
using _Test.Code.Shared;
namespace _Test.Code.Features.Bugs.Runtime
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
