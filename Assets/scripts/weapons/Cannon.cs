using System;
using System.Collections;
using UnityEngine;

namespace FG
{
    public class Cannon : MonoBehaviour, Iweapon
    {
        [SerializeField] private GameObject bulletprefab;
        [SerializeField] private float roundsperminute = 60f;

        private float timebetweenshots;
        private float timeoflastshot;
        private Coroutine shootingroutine;

        private Transform _transform;

        private const float secondsperminute = 60f;

        public bool isshooting { get; private set; } = false;

        public void Startshooting(Action<int> onHitCallback)
        {
            if (isshooting)
                return;

            shootingroutine = StartCoroutine(Shooting(Mathf.Max(0f, timeoflastshot + timebetweenshots - Time.time), onHitCallback));
        }

        public void Stopshooting()
        {
            StopCoroutine(shootingroutine);
            isshooting = false;
        }

        private IEnumerator Shooting(float startdelay, Action<int> onHitCallback)
        {
            if(startdelay > 0f)
            {
                yield return new WaitForSeconds(startdelay);
            }

            while(true)
            {
                Fireshot(onHitCallback);
                timeoflastshot = Time.time;
                yield return new WaitForSeconds(timebetweenshots);
            }
        }

        private void Fireshot(Action<int> onHitCallback)
        {
            Vector2 direction = _transform.root.position.directionto(_transform.position);
            Instantiate(bulletprefab, _transform.position, Quaternion.identity)?.GetComponent<Cannonball>()?.Fire(direction, onHitCallback);
        }

        private void Awake()
        {
            _transform = transform;
            timebetweenshots = secondsperminute / roundsperminute;
        }
    }
}