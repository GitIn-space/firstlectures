using System.Collections;
using UnityEngine;

namespace FG
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private AnimationCurve distribution;
        [SerializeField] private GameObject[] objectstospawn;

        [Header("Time")]
        [SerializeField, Tooltip("In seconds")] private float timebeforefirstspawn;
        [SerializeField] private float timebetweenspawns;

        private Transform _transform;
        private Coroutine spawnroutine;

        private IEnumerator Spawnobjects()
        {
            yield return new WaitForSeconds(timebeforefirstspawn);

            while(true)
            {
                Createobject();
                yield return new WaitForSeconds(timebetweenspawns);
            }

            void Createobject()
            {
                GameObject go = objectstospawn[(int) distribution.Evaluate(Random.value)];
                Instantiate(go, _transform.position, Quaternion.Euler(0f, 0f, Random.Range(0, 360f)));
            }
        }

        private void OnEnable()
        {
            spawnroutine = StartCoroutine(Spawnobjects());
        }

        private void OnDisable()
        {
            StopCoroutine(spawnroutine);
        }

        private void Awake()
        {
            _transform = transform;
        }
    }
}