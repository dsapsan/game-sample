using UnityEngine;

namespace GameSample.Core
{
    public interface IInputAction
    {
        bool Active { get; }
        bool Triggered { get; }
        Vector2 Value { get; }
    }
}
