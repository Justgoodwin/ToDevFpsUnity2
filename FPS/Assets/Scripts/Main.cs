using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPS
{
	
	public class Main : MonoBehaviour
	{
        private GameObject _controllerGameObject;
        public InputController _inputController { get; private set; }
        public FlashLightController _flashLightController { get; private set; }
        public WeaponController _weaponController { get; private set; }
        public ObjectManager _objectManager { get; private set; }
        public TeammatesController _teammatesController { get; private set; }
        public static Main Instance { get; private set; }

		private void Awake()
		{
			if (Instance)
				DestroyImmediate (this);
			else
				Instance = this;
		}

        public enum MouseButon
        {
            LeftButton,RightButtn,CenterButton
        }

		private void Start()
		{
            Instance = this;
            _controllerGameObject = new GameObject { name = "Controllers" };
			_inputController = gameObject.AddComponent<InputController> ();
            _flashLightController = gameObject.AddComponent<FlashLightController>();
            _weaponController = gameObject.AddComponent<WeaponController>();
            _objectManager = gameObject.AddComponent<ObjectManager>();
            _teammatesController = gameObject.AddComponent<TeammatesController>();
        }

        #region Propery
        /// <summary>
        /// get flashlight control
        /// </summary>
        public FlashLightController GetFlashLightController
        {
            get { return _flashLightController; }
        }

        public static object MouseButton { get; internal set; }

        public InputController GetInputController()
        {
            return _inputController;
        }

        public WeaponController GetWeaponController()
        {
            return _weaponController;
        }

        public ObjectManager GetObjectManager()
        {
            return _objectManager;
        }

        #endregion
    }
}
