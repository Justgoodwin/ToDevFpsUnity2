using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPS{
	
	public class InputController : BaseController
	{

		private void Update()
		{
            if (Input.GetButtonDown("SwitchFlashlight"))
                Main.Instance._flashLightController.Switch();
            if (Input.GetButton("Fire1"))
                Main.Instance._weaponController.Fire();
            if (Input.GetButtonDown("SwitchWeapon"))
                Main.Instance._weaponController.ChangeWeapon();
            if (Input.GetButtonDown("GivingOrder"))
                Main.Instance._teammatesController.MoveByCommand();
        }
	}
}