using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace FPS
{
    public class MakeRadarObject : MonoBehaviour
    {
        public Image pointOnRadar;

        private void Start()
        {
            Radar.RegisterRadarObjects(gameObject, pointOnRadar);
        }

        private void OnDestroy()
        {
            Radar.RemoveRadarObjects(gameObject);
        }
    }
}

