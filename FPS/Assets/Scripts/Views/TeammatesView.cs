using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FPS
{
    public class TeammatesView : BaseObjectScene
    {
        private TeammateModel _teammate;

        protected override void Awake()
        {
            base.Awake();
            StartCoroutine(Initialize());
        }

        IEnumerator Initialize()
        {
            yield return new WaitWhile(() => Main.Instance == null);
            _teammate = GetComponentInParent<TeammateModel>();
            TeammatesController.OnGivingOrder += OnGivingOrder;
            IsVisible = false;
        }

        private void OnDestroy()
        {
            TeammatesController.OnGivingOrder -= OnGivingOrder;
        }

        private void OnGivingOrder(TeammateModel teammate)
        {
            IsVisible = teammate == _teammate;
        }
    }
}

