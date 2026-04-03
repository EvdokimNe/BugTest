using System;
using Test.Code.Features.Timers.Contracts;

namespace Test.Code.Features.Bugs.Runtime
{
    public sealed class BugLifetimeComponent
    {
        private readonly ITimer _timer;

        public bool IsExpired => _timer.IsFinished;

        public BugLifetimeComponent(ITimer timer, float lifetimeSeconds)
        {
            _timer = timer;
            _timer.Setup(lifetimeSeconds);
            _timer.Restart();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void Dispose()
        {
            if (_timer is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
