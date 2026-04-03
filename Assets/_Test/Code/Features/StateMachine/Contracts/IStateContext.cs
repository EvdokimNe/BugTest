namespace _Test.Code.Features.StateMachine.Contracts
{
    public interface IStateContext
    {
        bool HasTransitionRequest { get; }
        void ConsumeTransitionRequest();
    }
}
