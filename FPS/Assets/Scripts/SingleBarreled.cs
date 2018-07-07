using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{

    public class SingleBarreled : Weapons
    {
        [SerializeField] private string _bulletID = "HP_bullet";
        [SerializeField] private float _force = 500f;
        [SerializeField] private Transform _firepoint;
        [SerializeField] private float _timeout = 0.5f;

        private float _lastShotTime;

        public AudioClip _rifleShoot;

        public override void Fire()
        {
            if(Time.time - _lastShotTime < _timeout)
                return;

            _lastShotTime = Time.time;

            Bullet bullet = (Bullet)BaseObjectPool.Instance.GetObject(_bulletID);

            if (!bullet)
            {
                return;
            }
            bullet.transform.position = _firepoint.position;
            bullet.transform.rotation = _firepoint.rotation;
            bullet.Intialize(_force);

            AudioSource.PlayClipAtPoint(_rifleShoot, transform.position);
            
        }
    }
}
