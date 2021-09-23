using UnityEngine;

namespace FG
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int points = 5;

        /// Return amount of points
        public int Hit()
        {
            Destroy(gameObject);
            return points;
        }
    }
}
