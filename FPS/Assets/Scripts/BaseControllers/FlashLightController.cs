using UnityEngine;
namespace FPS
{

    public class FlashLightController : BaseController
    {
        private FlashlightModel _model;
        private Light _light;

        private void Awake()
        {
            _model = FindObjectOfType<FlashlightModel>();
            _light = GameObject.Find("Flashlight").GetComponent<Light>();
            Off();
        }
        public void Start()
        {
            SetActiveFlashlight(false);
        }

        public void Update()
        {
            if (!enabled)
            {
                return;
            }
        }

        private void SetActiveFlashlight(bool value)
        {
            _light.enabled = value;
        }

        public override void On()
        {
            if (!IsEnabled)
            {
                base.On();
                _model.On();
            }
            SetActiveFlashlight(true);
        }
        public override void Off()
        {
            if (IsEnabled)
            {
                base.Off();
                _model.Off();
            }
                
            SetActiveFlashlight(false);
        }

        public void Switch()
        {
            if (!IsEnabled)
            {
                On();
            }
            else
                Off();
        }
    }
}

