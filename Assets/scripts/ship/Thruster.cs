using System;
using UnityEngine;

namespace FG
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Thruster : MonoBehaviour
    {
        [Header("Force")]
        [SerializeField] private float thrustmultiplier = 2f;
        [SerializeField] private float maxthrust = 2f;

        [Header("Fuel")]
        [SerializeField] private float maxfuel = 100f;
        [SerializeField] private float fuelconsumptionpersecond = 1f;
        [SerializeField] private float startfuel = 50f;

        [Header("Events")]
        [SerializeField] private Floatevent onfuelchanged;

        [NonSerialized] public float thrust;

        private float currentfuel;

        private Transform _transform;
        private Rigidbody2D body;

        public float Maxfuel => maxfuel;

        public float Currentfuel
        {
            get => currentfuel;
            set
            {
                currentfuel = Mathf.Clamp(value, 0f, maxfuel);
                onfuelchanged.Invoke(currentfuel);
            }
        }

        private void Updateforce()
        {
            body.AddForce(transform.up * (thrust * thrustmultiplier), ForceMode2D.Impulse);
            body.velocity = Vector2.ClampMagnitude(body.velocity, maxthrust);
            body.angularVelocity = 0f;
        }

        private void FixedUpdate()
        {
            if(thrust <= 0f || currentfuel <= 0f)
                return;

            Updateforce();

            currentfuel -= fuelconsumptionpersecond * Time.fixedDeltaTime;
        }

        private void Awake()
        {
            _transform = transform;
            body = GetComponent<Rigidbody2D>();
            currentfuel = startfuel;
        }
    }
}