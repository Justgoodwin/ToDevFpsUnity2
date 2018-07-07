using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{

    public class FlashlightViews : MonoBehaviour
    {
        private Image _image;

        private FlashlightModel _model;

        private void Awake()
        {
            _model = FindObjectOfType<FlashlightModel>();
            _image = GetComponent<Image>();

        }

        private void Update()
        {
            if (Mathf.Abs(_image.fillAmount - _model.FillAmount) > 0.02f)
                _image.fillAmount = _model.FillAmount;
        }
    }
}
