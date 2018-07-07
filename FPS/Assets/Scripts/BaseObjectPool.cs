using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class BaseObjectPool : MonoBehaviour
    {
        public static BaseObjectPool Instance { get; private set; }

        [SerializeField] private GameObject[] _objects;

        private Dictionary<string, Queue<IPoolable>> _objectDict = new Dictionary<string, Queue<IPoolable>>();

        private void Awake()
        {
            if (Instance)
                DestroyImmediate(this);
            else
                Instance = this;
        }

        private void Start()
        {
            foreach (var item in _objects)
            {
                IPoolable poolObj = item.GetComponent<IPoolable>();
                if (poolObj == null)
                    continue;

                Queue<IPoolable> queue = new Queue<IPoolable>();
                for (int i = 0; i < poolObj.ObjectCount; i++)
                {
                    GameObject go = Instantiate(item);
                    go.SetActive(false);
                    queue.Enqueue(go.GetComponent<IPoolable>());
                }
                _objectDict.Add(poolObj.PoolId, queue);
            }
        }
        /// <summary>
        /// for reciveing the object
        /// </summary>
        /// <param name="poolId"></param>
        /// <returns></returns>
        public IPoolable GetObject(string poolId)
        {
            if (string.IsNullOrEmpty(poolId))
            {
                return null;
            }
            if (!_objectDict.ContainsKey(poolId))
            {
                return null;
            }

            IPoolable firstBullet = _objectDict[poolId].Dequeue();
            _objectDict[poolId].Enqueue(firstBullet);

            return firstBullet;
        }

    }
}

