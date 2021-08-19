using UnityEngine;

namespace FG
{
    [RequireComponent(typeof(Shiprotator), typeof(Thruster))]
    public class Playercontroller : MonoBehaviour
    {
        private Thruster thruster;
        private Shiprotator _shiprotator;

        private Iweapon[] weapons;
        private int currentweaponindex = 0;

        public void Stepweapon(float direction)
        {
            if(weapons[currentweaponindex].isshooting)
                weapons[currentweaponindex].Stopshooting();

            if(direction > 0f)
            {
                currentweaponindex = (currentweaponindex + 1) % weapons.Length;
            }
            else if(direction < 0f)
            {
                currentweaponindex = (currentweaponindex + weapons.Length - 1) % weapons.Length;
            }
        }

        private void Onfirehit(int points)
        {

        }

        #region unity event functions

        private void Update()
        {
            thruster.thrust = Input.GetAxis("Accelerate");
            _shiprotator.targetpositioninscreespace = Input.mousePosition;

            if(Input.GetButtonDown("Fire"))
            {
                weapons[currentweaponindex].Startshooting(Onfirehit);
            }
            else if(Input.GetButtonUp("Fire"))
            {
                weapons[currentweaponindex].Stopshooting();
            }

            if(!Mathf.Approximately(Input.GetAxis("Mouse ScrollWheel"), 0f))
            {
                Stepweapon(Input.GetAxis("Mouse ScrollWheel"));
            }
        }

        private void Awake()
        {
            thruster = GetComponent<Thruster>();
            _shiprotator = GetComponent<Shiprotator>();

            Setupweapons();

            void Setupweapons()
            {
                Transform weaponstransform = transform.Find("weapons");
                weapons = new Iweapon[weaponstransform.childCount];
                //weapons = weaponstransform.GetComponentsInChildren<Iweapon>();

                for (int c = 0; c < weaponstransform.childCount; c++)
                {
                    weapons[c] = weaponstransform.GetChild(c).GetComponent<Iweapon>();
                }
            }
        }

        #endregion unity event functions
    }
}
