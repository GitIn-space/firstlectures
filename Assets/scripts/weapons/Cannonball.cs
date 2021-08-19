using System;
using UnityEngine;

namespace FG
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Cannonball : MonoBehaviour
    {
        [SerializeField] private float force = 2f;
        [SerializeField] private int points = 5;

        private Rigidbody2D body;
        private Action<int> _onHitCallback;

        public void Fire(Vector2 direction, Action<int> onHitCallback)
        {
            _onHitCallback = onHitCallback;
            body.AddForce(direction * force, ForceMode2D.Impulse);
        }

        private void Destroybullet()
        {
            _onHitCallback.Invoke(points);
            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }
    }
}