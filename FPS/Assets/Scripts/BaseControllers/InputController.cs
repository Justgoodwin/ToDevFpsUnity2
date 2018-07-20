using UnityEngine;
namespace FPS
{

    public class InputController : BaseController
	{

		private void Update()
		{
            if (Input.GetButtonDown("SwitchFlashlight"))
                Main.Instance.GetFlashLightController.Switch();
            if (Input.GetButton("Fire1"))
                Main.Instance.WeaponController.Fire();
            if (Input.GetButtonDown("SwitchWeapon"))
                Main.Instance.WeaponController.ChangeWeapon();
            if (Input.GetButtonDown("GivingOrder"))
                Main.Instance.TeammatesController.MoveByCommand();
        }
	}
}