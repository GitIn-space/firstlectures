using UnityEngine;

namespace FG
{
    [RequireComponent(typeof(Shiprotator), typeof(Thruster))]
    public class Playercontroller : MonoBehaviour
    {
        private Thruster thruster;
        private Shiprotator _shiprotator;

        #region unity event functions

        private void Update()
        {
            thruster.thrust = Input.GetAxis("Accelerate");
            _shiprotator.targetpositioninscreespace = Input.mousePosition;
        }

        private void Awake()
        {
            thruster = GetComponent<Thruster>();
            _shiprotator = GetComponent<Shiprotator>();
        }

        #endregion unity event functions
    }
}
