using UnityEngine;
namespace FPS
{
    public abstract class Ammunition : BaseObjectScene, IPoolable
    {
        [SerializeField] public float _hpBulletDamage = 20f;
        [SerializeField] private string _poolId;
        public string PoolId
        {
            get { return _poolId; }
        }

        [SerializeField] private int _objectCount;
        public int ObjectCount
        {
            get { return _objectCount; }
        }
    }
}
