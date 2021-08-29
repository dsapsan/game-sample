using UnityEngine;

namespace GameSample.Core
{
    public sealed class InputActionStub : IInputAction
    {
        public static readonly InputActionStub Instance = new InputActionStub();

        public bool Active => false;
        public bool Triggered => false;
        public Vector2 Value => Vector2.zero;
    }
}
