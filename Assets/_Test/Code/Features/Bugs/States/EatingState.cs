using _Test.Code.Features.Bugs.Contracts;
using _Test.Code.Features.Bugs.Runtime;
using _Test.Code.Features.ResourceSpawn.Contracts;
using _Test.Code.Features.StateMachine.Runtime;
using _Test.Code.Features.Targeting;
using _Test.Code.Features.Targeting.Contracts;
using _Test.Code.Features.Targeting.Models;
namespace _Test.Code.Features.Bugs.States
{
    public sealed class EatingState : StateBase<BugStateContext>
    {
        private readonly TargetSelectorService _targetSelectorService;
        private readonly IResourceManager _resourceManager;
        private readonly IBugRegistry _bugRegistry;
        private readonly BugConsumeService _bugConsumeService;
        private readonly ITargetSelector _targetSelector;

        private readonly EatingStateContext _stateContext = new();

        public EatingState(
            TargetSelectorService targetSelectorService,
            IResourceManager resourceManager,
            IBugRegistry bugRegistry,
            BugConsumeService bugConsumeService, 
            ITargetSelector targetSelector
            )
        {
            _targetSelectorService = targetSelectorService;
            _resourceManager = resourceManager;
            _bugRegistry = bugRegistry;
            _bugConsumeService = bugConsumeService;
            _targetSelector = targetSelector;
        }

        public override bool ShouldBeActive()
        {
            if (!Context.RuntimeData.IsAlive)
                return false;

            _stateContext.Clear();
            return TryAcquireTarget();
        }

        public override void Update()
        {
            if (!_stateContext.HasTarget)
            {
                RequestExit();
                return;
            }

            if (!IsTargetValid(_stateContext.CurrentTarget))
            {
                RequestExit();
                return;
            }

            var stopDistance = Context.View.Radius + _stateContext.CurrentTarget.Radius;

            if (Context.MovementStrategy.HasReached(Context.View.transform.position, _stateContext.CurrentTarget.Position, stopDistance))
            {
                _bugConsumeService.TryConsume(Context.Owner, _stateContext.CurrentTarget);
                _stateContext.Clear();
                RequestExit();
                return;
            }

            Context.MovementStrategy.MoveTowards(Context.View.transform, _stateContext.CurrentTarget.Position);
        }

        private bool TryAcquireTarget()
        {
            if (!_targetSelectorService.TrySelect(_targetSelector, Context.Owner, out var target))
                return false;

            _stateContext.CurrentTarget = target;
            return true;
        }

        private bool IsTargetValid(TargetInfo target)
        {
            if (target == null)
                return false;

            return target.Kind switch
            {
                TargetKind.Resource => _resourceManager.TryGet(target.Id, out _),
                TargetKind.Bug => _bugRegistry.TryGet(target.Id, out var bug) && bug.RuntimeData.IsAlive,
                _ => false
            };
        }
    }
}
