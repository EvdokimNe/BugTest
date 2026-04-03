using System;
using R3;
using TMPro;
using UnityEngine;
using VContainer;
namespace _Test.Code.Features.GameStats.BugDeath.View
{
    public sealed class BugDeathCountersActiveView : MonoBehaviour
    {
        private const string WorkerDeathCountTextFormat  = "Worker Death Count {0}";
        private const string PredatorDeathCountTextFormat  = "Predator Death Count {0}";
        
        [SerializeField] private TextMeshProUGUI _deadWorkersText;
        [SerializeField] private TextMeshProUGUI _deadPredatorsText;

        private IDisposable _workersSubscription;
        private IDisposable _predatorsSubscription;

        [Inject]
        public void Construct(BugDeathCountersService countersService)
        {
            _workersSubscription?.Dispose();
            _predatorsSubscription?.Dispose();

            _workersSubscription = countersService.DeadWorkersCount.Subscribe(value =>
            {
                _deadWorkersText.text = string.Format(WorkerDeathCountTextFormat, value.ToString());
            });

            _predatorsSubscription = countersService.DeadPredatorsCount.Subscribe(value =>
            {
                _deadPredatorsText.text = string.Format(PredatorDeathCountTextFormat, value.ToString());
            });
        }

        private void OnDestroy()
        {
            _workersSubscription?.Dispose();
            _predatorsSubscription?.Dispose();
        }
    }
}
