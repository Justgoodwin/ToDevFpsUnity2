using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{

    public class SingleBarreled : Weapon
    {
        //[SerializeField] private string _poolID = "bullet";
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _force = 500f;
        [SerializeField] private Transform _firepoint;
        [SerializeField] private float _timeout = 0.5f;

        //public static List<Bullet> Bullets { get; set; }
        //private static Dictionary<string, Queue<IPoolable>> _objectDict = new Dictionary<string, Queue<IPoolable>>();

        private float _lastShotTime;

        public AudioClip _rifleShoot;

        //public SingleBarreled()
        //{
        //    Bullets = new List<Bullet>(10);

        //    Queue<IPoolable> queue = new Queue<IPoolable>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        GameObject a = Instantiate(_bulletPrefab, _firepoint.position, _firepoint.rotation)
        //        queue.Enqueue(a);
        //    }
        //    _objectDict.Add(_poolID, queue);
        //}

        //public static IPoolable GetObject(string poolId)
        //{
        //    if (string.IsNullOrEmpty(poolId))
        //    {
        //        return null;
        //    }
        //    if (!_objectDict.ContainsKey(poolId))
        //    {
        //        return null;
        //    }

        //    Queue<IPoolable> queue = _objectDict[poolId];
        //    IPoolable firstBullet = queue.Dequeue();
        //    _objectDict[poolId].Enqueue(firstBullet);

        //    return firstBullet;
        //}


        public override void Fire()
        {

            if (Time.time - _lastShotTime < _timeout)
                return;

            _lastShotTime = Time.time;

            GameObject bullet = Instantiate(_bulletPrefab, _firepoint.position, _firepoint.rotation);
            //var pool = new BaseObjectPool();
            //IPoolable iPoolable = GetObject(_poolID);
            //if (iPoolable == null)
            //{
            //    Debug.Log(string.Format("Can not find pool {0}", _poolID));
            //}

            //var bullet = (Bullet)iPoolable;

            bullet.GetComponent<Bullet>().Intialize(_force);
            //bullet.AddForce(_firepoint.forward * _force, ForceMode.Impulse);

        }
    }
}
