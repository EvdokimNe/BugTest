using _Test.Code.Features.Bugs.Configs;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.Timers.Contracts;
using VContainer;
namespace _Test.Code.Features.Bugs.Factories
{
    public class AttachOptionalComponentsHelper
    {
        private readonly IObjectResolver _objectResolver;
        
        public AttachOptionalComponentsHelper(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }
        
        public void AttachOptionalComponents(BugAgentContainer agentContainer, BugSettings settings)
        {
            TryAttachLifeTimeComponent(agentContainer, settings);
        }
        
        private void TryAttachLifeTimeComponent(BugAgentContainer agentContainer, BugSettings settings)
        {
            if (settings.LifetimeSeconds <= 0f)
                return;

            var timer = _objectResolver.Resolve<ITimer>();
            var lifetimeComponent = new BugLifetimeComponent(timer, settings.LifetimeSeconds);
            agentContainer.AttachLifetime(lifetimeComponent);
        }
    }
}
