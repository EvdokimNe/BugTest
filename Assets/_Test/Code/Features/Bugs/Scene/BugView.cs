using Test.Code.Features.Bugs.Models;
using Test.Code.Features.Targeting.Models;
using UnityEngine;

namespace Test.Code.Features.Bugs.Scene
{
    public sealed class BugView : MonoBehaviour
    {
        [SerializeField] private float _radius = 0.45f;

        public BugKind Kind { get; private set; }
        public float Radius => _radius;
    }
}
