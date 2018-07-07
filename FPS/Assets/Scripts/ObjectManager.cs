using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPS
{

    public class ObjectManager : MonoBehaviour
    {
        [SerializeField] private Ammunition[] _ammunitionsList = new Ammunition[5];

        [SerializeField] private Weapons[] _weaponsList = new Weapons[5];

        public Weapons[] GetWeaponsList
        {
            get { return _weaponsList; }
        }

        public Ammunition[] GetAmmunitionsList
        {
            get { return _ammunitionsList; }
        }
    }
}