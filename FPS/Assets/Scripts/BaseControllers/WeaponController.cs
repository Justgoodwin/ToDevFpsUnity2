using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
namespace FPS
{
    public class WeaponController : BaseController
    {
        private Weapons[] _weapons;
        private int _currentWeapon;

        private void Awake()
        {
            _weapons = FindObjectOfType<RigidbodyFirstPersonController>().GetComponentsInChildren<Weapons>(true);
            for (int i = 1; i < _weapons.Length; i++)
                _weapons[i].IsVisible = i == 1;
        }

        public void ChangeWeapon()
        {
            _weapons[_currentWeapon].IsVisible = false;
            _currentWeapon++;
            if (_currentWeapon >= _weapons.Length)
                _currentWeapon = 1;
            _weapons[_currentWeapon].IsVisible = true;
        }

        public void Fire()
        {
            if (_weapons.Length > _currentWeapon && _weapons[_currentWeapon])
                _weapons[_currentWeapon].Fire();
        }
    }
}