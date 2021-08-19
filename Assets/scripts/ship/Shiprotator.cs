using System;
using UnityEngine;

namespace FG
{
    public class Shiprotator : MonoBehaviour
    {
        [SerializeField] private float rotationspeed = 3f;
        [SerializeField] private float anglemodifier = 0f;

        [NonSerialized] public Vector2 targetpositioninscreespace;

        private Transform _transform = null;
        private Camera _camera;

        private void FixedUpdate()
        {
            Vector2 direction = _camera.ScreenToWorldPoint(targetpositioninscreespace).directionto(_transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + anglemodifier;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, Time.fixedDeltaTime * rotationspeed);
        }

        private void Awake()
        {
            _transform = transform;
            _camera = Camera.main;

            //Debug.Log(_camera);
        }
    }
}