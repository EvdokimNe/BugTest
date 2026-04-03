namespace Test.Code.Features.Timers.Contracts
{
    public interface ITimer
    {
        bool IsFinished { get; }

        void Setup(float maxTimeSeconds);
        void Restart();
        void Pause();
        void Stop();
    }
}
