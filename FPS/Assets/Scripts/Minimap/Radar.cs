using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace FPS
{
    public class Radar : MonoBehaviour
    {
        private Transform _playerPos;
        private readonly float _mapScale = 2;
        public static List<RadarObject> RadObject = new List<RadarObject>();

        private void Start()
        {
            _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public static void RegisterRadarObjects(GameObject _radarObject, Image _objectImage)
        {
            Image radarImage = Instantiate(_objectImage);
            RadObject.Add(new RadarObject { Owner = _radarObject, Icon = radarImage });
        }

        public static void RemoveRadarObjects(GameObject _radarObject)
        {
            List<RadarObject> newRadObjects = new List<RadarObject>();
            foreach (RadarObject pointOnRadar in RadObject)
            {
                if (pointOnRadar.Owner == _radarObject)
                {
                    Destroy(pointOnRadar.Icon);
                    continue;

                }
                newRadObjects.Add(pointOnRadar);

            }
            RadObject.RemoveRange(0, RadObject.Count);
            RadObject.AddRange(newRadObjects);
        }

        private void DrawRadarPoints()
        {
            foreach (RadarObject pointOnRadar in RadObject)
            {
                Vector3 radarPos = (pointOnRadar.Owner.transform.position - _playerPos.position);

                float distanceToObject = Vector3.Distance(_playerPos.position, pointOnRadar.Owner.transform.position) * _mapScale;

                float deltaY = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - _playerPos.eulerAngles.y;

                radarPos.x = distanceToObject * Mathf.Cos(deltaY * Mathf.Deg2Rad) * -1;
                radarPos.z = distanceToObject * Mathf.Sin(deltaY * Mathf.Deg2Rad);

                pointOnRadar.Icon.transform.SetParent(transform);
                pointOnRadar.Icon.transform.position = new Vector3(radarPos.x, radarPos.z, 0) + transform.position;
            }
        }

        private void Update()
        {
            if (Time.frameCount % 3 == 0)
            {
                DrawRadarPoints();
            }
        }
    }

    

    public class RadarObject
    {
        public Image Icon;
        public GameObject Owner;
    }
}

