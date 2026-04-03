using _Test.Code.Features.Bugs.Models;
using UnityEngine;
namespace _Test.Code.Features.Bugs.Scene
{
    public sealed class BugView : MonoBehaviour
    {
        [SerializeField] private float _radius = 0.45f;

        public BugKind Kind { get; private set; }
        public float Radius => _radius;
    }
}
