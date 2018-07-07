using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public interface IPoolable
    {
        string PoolId { get; }

        int ObjectCount { get; }
    }
}

