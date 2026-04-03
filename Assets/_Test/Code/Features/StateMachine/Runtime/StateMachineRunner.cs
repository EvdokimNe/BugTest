using System.Collections.Generic;
using _Test.Code.Features.StateMachine.Contracts;
namespace _Test.Code.Features.StateMachine.Runtime
{
    public sealed class StateMachineRunner
    {
        private readonly IReadOnlyList<IState> _states;
        private readonly IStateContext _context;
        private readonly IStateAccessor _stateAccessor;

        public StateMachineRunner(IReadOnlyList<IState> states, IStateContext context, IStateAccessor stateAccessor)
        {
            _states = states;
            _context = context;
            _stateAccessor = stateAccessor;

            for (var i = 0; i < _states.Count; i++)
            {
                _states[i].Setup(_context);
            }
        }

        public void Tick()
        {
            if (_stateAccessor.CurrentState == null)
            {
                TrySelectState(skipCurrentState: false);
            }

            _stateAccessor.CurrentState?.Update();
            TryHandleTransitionRequest();
        }

        private void TryHandleTransitionRequest()
        {
            var currentState = _stateAccessor.CurrentState;
            if (currentState == null || !currentState.CanExit())
                return;

            var hasExternalRequest = _context.HasTransitionRequest;
            if (!hasExternalRequest && !currentState.NeedExit)
                return;

            if (hasExternalRequest)
            {
                _context.ConsumeTransitionRequest();
            }

            TrySelectState(skipCurrentState: true);
        }

        private bool TrySelectState(bool skipCurrentState)
        {
            var currentState = _stateAccessor.CurrentState;
            _stateAccessor.NextState = currentState;

            for (var i = 0; i < _states.Count; i++)
            {
                var candidateState = _states[i];

                if (skipCurrentState && candidateState == currentState)
                    continue;

                if (!candidateState.ShouldBeActive())
                    continue;

                _stateAccessor.NextState = candidateState;
                if (candidateState == currentState)
                    return false;

                _stateAccessor.BeforeState = currentState;
                _stateAccessor.CurrentState = candidateState;
                _stateAccessor.CurrentState.OnEnter();
                return true;
            }

            return false;
        }
    }

    public interface IStateAccessor
    {
        IState BeforeState { get; set; }
        IState CurrentState { get; set; }
        IState NextState { get; set; }
    }
}
