using UnityEngine;
namespace FPS
{
	
	public class Main : MonoBehaviour
	{
        public static Main Instance { get; private set; }
        private GameObject _controllerGameObject;
        public InputController InputController { get; private set; }
        public WeaponController WeaponController { get; private set; }
        public FlashLightController GetFlashLightController { get; private set; }
        public TeammatesController TeammatesController { get; private set; }
        public Bullet Ammunition { get; private set; }
        public TeammateModel _teammateModel { get; private set; }
        public TeammatesView _teammateView { get; private set; }

        private void Awake()
		{
			if (Instance)
				DestroyImmediate (this);
			else
				Instance = this;
		}        

		private void Start()
		{
            Instance = this;
            _controllerGameObject = new GameObject { name = "Controllers" };
			InputController = gameObject.AddComponent<InputController> ();
            GetFlashLightController = gameObject.AddComponent<FlashLightController>();
            WeaponController = gameObject.AddComponent<WeaponController>();
            TeammatesController = gameObject.AddComponent<TeammatesController>();
            Ammunition = Resources.Load<Bullet>("bullet");
        }
    }
}
