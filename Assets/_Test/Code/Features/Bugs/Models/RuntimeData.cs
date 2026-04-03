namespace _Test.Code.Features.Bugs.Models
{
    public sealed class RuntimeData
    {
        public int Satiety { get; set; }
        public bool IsAlive { get; set; }

        public RuntimeData()
        {
            IsAlive = true;
        }
    }
}
