using Test.Code.Features.Timers.Contracts;
using Test.Code.Features.Timers.Runtime;
using VContainer;

namespace Test.Code.Features.Timers
{
    public sealed class TimerInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<TimerRunner>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<Timer>(Lifetime.Transient).As<ITimer>();
        }
    }
}
