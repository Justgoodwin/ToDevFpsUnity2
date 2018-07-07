using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace FPS
{
	public class FlashlightModel : MonoBehaviour
	{
        public static UnityAction<float> OnFillAmountChangerd;
        public float FillAmount { get; private set; }

		private Light _light;

        [SerializeField]
        private float _leakMult = 3f;

        [SerializeField]
        private float _rechargeTime = 7f;


		public bool IsOn
		{
            get
            {
                if (_light == null)
                {
                    return false;
                }
                return _light.enabled;
            }
		}
		private void Awake ()
		{
            _light = GetComponent<Light>();
            FillAmount = 1f;
		}

        private void OnEnable()
        {
            StartCoroutine(ChangeFill());
        }

        private void OnDisable()
        {
            StopCoroutine(ChangeFill());
        }

        public void On()
        {
            if (FillAmount < 0.3f)
            {
                return;
            }
            _light.enabled = true;
        }
        public void Off()
        {
            _light.enabled = false;
        }

        public void Switch()
        {
            if (IsOn)
                Off();
            else
                On();
        }

        private IEnumerator WaitAfterTimeIsLeaked()
        {
            yield return new WaitForSeconds(5000f);
        }
        private IEnumerator ChangeFill()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                if (IsOn)
                {
                    FillAmount = Mathf.Clamp01(FillAmount - (1f / (_rechargeTime * _leakMult) * 0.5f));
                    if (FillAmount <= 0f)
                    {
                        Off();
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
                else
                {
                    FillAmount = Mathf.Clamp01(FillAmount + (1f / _rechargeTime * 0.5f));
                }

                if (OnFillAmountChangerd != null)
                {
                    OnFillAmountChangerd(FillAmount);
                }
            }
        }
	}	
}