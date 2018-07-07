using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FPS
{
    public abstract class BaseObjectScene : MonoBehaviour
    {
        protected int _layer;
        protected Color _color;
        protected Material _material;
        protected Transform _myTransform;
        protected Vector3 _position;
        protected Quaternion _rotation;
        protected Vector3 _scale;
        protected GameObject _instanceObject;
        protected Rigidbody _rigitbody;
        protected string _name;
        protected bool _isVisible;


        #region UnityFunction

        protected virtual void Awake()
        {
            _instanceObject = gameObject;
            _name = _instanceObject.name;
            if (GetComponent<Renderer>())
            {
                _material = GetComponent<Renderer>().material;
            }

            _rigitbody = _instanceObject.GetComponent<Rigidbody>();
            _myTransform = _instanceObject.transform;
        }

        #endregion

        #region Property

        /// <summary>
        ///позволяет назначать имя
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                InstanceObject.name = _name;
            }
        }
        /// <summary>
        /// слой обьекта
        /// </summary>
        public int Layers
        {
            get { return _layer; }
            set
            {
                _layer = value;
                if(InstanceObject != null)
                {
                    _instanceObject.layer = _layer;
                }
                if (InstanceObject != null)
                {
                    AskLayer(GetTransform, value);
                }
            }
        }
        /// <summary>
        /// Задаём цвет обьекта
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                if (_material != null)
                {
                    _material.color = _color;
                }
                AskColor(GetTransform, _color);
            }
        }


        public Material GetMaterial
        {
            get { return _material; }
        }

        /// <summary>
        /// Object position
        /// </summary>
        public Vector3 Position
        {
            get
            {
                if (InstanceObject != null)
                {
                    _position = GetTransform.position;
                }
                return _position;
            }

            set
            {
                _position = value;
                if (InstanceObject != null)
                {
                    GetTransform.position = _position;
                }
            }
        }
        /// <summary>
        /// Size of the object
        /// </summary>
        public Vector3 Scale
        {
            get
            {
                if (InstanceObject != null)
                {
                    _scale = GetTransform.localScale;
                }
                return _scale;
            }
        }
        /// <summary>
        /// setup rotation
        /// </summary>
        public Quaternion Rotation
        {
            get
            {
                if (InstanceObject != null)
                {
                    _rotation = GetTransform.rotation;
                }
                return _rotation;
            }

            set
            {
                _rotation = value;
                if (InstanceObject != null)
                {
                    GetTransform.rotation = _rotation;
                }
            }
        }
        /// <summary>
        /// Get phisical properties of object
        /// </summary>
        public Rigidbody GetRigidbody
        {
            get { return _rigitbody; }
        }


        /// <summary>
        /// Get link on a object
        /// </summary>
        public GameObject InstanceObject
        {
            get { return _instanceObject; }
        }


        /// <summary>
        /// Hide/Show object
        /// </summary>
        public bool IsVisible
        {
            get { return _isVisible; }

            set
            {
                _isVisible = value;
                if (_instanceObject.GetComponent<MeshRenderer>())
                {
                    _instanceObject.GetComponent<MeshRenderer>().enabled = _isVisible;
                }
                if (_instanceObject.GetComponent<SkinnedMeshRenderer>())
                {
                    _instanceObject.GetComponent<SkinnedMeshRenderer>().enabled = _isVisible;
                }
            }
        }

        /// <summary>
        /// Get object Transform
        /// </summary>
        public Transform GetTransform
        {
            get { return _myTransform; }
        }

        #endregion

        #region PrivateFunction
        /// <summary>
        /// setting layer for each objects
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="lvl"></param>
        private void AskLayer(Transform obj, int lvl)
        {
            obj.gameObject.layer = lvl;
            if (obj.childCount > 0)
            {
                foreach (Transform item in obj)
                {
                    item.gameObject.layer = lvl;
                }
            }
        }

        private void AskColor(Transform obj, Color color)
        {
            obj.gameObject.GetComponent<Renderer>().material.color = color;
            if (obj.childCount > 0)
            {
                foreach (Transform item in obj)
                {
                    obj.gameObject.GetComponent<Renderer>().material.color = color;
                }
            }
        }

        #endregion
    }


}
