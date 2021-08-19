using System;
using UnityEngine;

namespace FG
{
    public class Cannon : MonoBehaviour, Iweapon
    {
        [SerializeField] private GameObject bulletprefab;
        [SerializeField] private float roundsperminute = 60f;

        private float timebetweenshots;
        private float timesincelastshot;
        private Coroutine shootingroutine;

        private Transform _transform;

        public bool isshooting { get; private set; } = false;

        public void Startshooting(Action<int> onhitcallback)
        {
            
        }

        public void Stopshooting()
        {
            
        }
    }
}