using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
namespace FPS
{
    public class WeaponController : BaseController
    {
        [SerializeField] private List<Weapon> _weaponsList;
        [SerializeField] private List<Ammunition> _ammunitionsList;
        private Weapon _currentWeapon;

        private void Awake()
        {
            _currentWeapon = FindObjectOfType<FirstPersonController>().GetComponentInChildren<Weapon>(true);
        }

        public void ChangeWeapon()
        {
            int currentWeaponIndex = _weaponsList.IndexOf(_currentWeapon);
            if (currentWeaponIndex == -1)
            {
                Debug.LogError("Can not find current weapon in WeaponList.");
            }

            if (currentWeaponIndex >= _weaponsList.Count - 1)
            {
                Debug.LogWarning("Can not find current weapon in WeaponList.");
            }

            _weaponsList[currentWeaponIndex].IsVisible = false;
            currentWeaponIndex++;
            
            _weaponsList[currentWeaponIndex].IsVisible = true;
        }

        public void Fire()
        {
            _currentWeapon.Fire();
        }
    }
}