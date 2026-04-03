namespace Test.Code.Features.StateMachine.Contracts
{
    public interface IState
    {
        bool NeedExit { get; }
        void Setup(IStateContext context);
        bool CanExit();
        bool ShouldBeActive();
        void OnEnter();
        void Update();
    }
}
