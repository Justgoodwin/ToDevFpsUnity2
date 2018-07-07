using System;
using System.Collections;
using System.Collections.Generic;
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

        [SerializeField] private int _objctCount = 10;
        public int ObjectCount
        {
            get { return _objctCount; }
        }
    }
}
