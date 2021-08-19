using UnityEngine;

namespace FG
{
    public static class Vector3extension
    {
        public static Vector3 directionto(this Vector3 source, Vector3 destination)
        {
            return (destination - source).normalized;
        }
    }
}