using UnityEngine;

namespace GameSample.Core
{
    public static class Extensions
    {
        public static (float x, float y) Deconstruct(this Vector2 vector2)
        {
            return (vector2.x, vector2.y);
        }
    }
}
