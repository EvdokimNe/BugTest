using _Test.Code.Features.Timers.Contracts;
using VContainer;
namespace _Test.Code.Features.Timers
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
