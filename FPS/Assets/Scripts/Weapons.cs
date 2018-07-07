using UnityEngine;
namespace FPS
{

    public abstract class Weapons : MonoBehaviour
    {
        #region Serialize Veriable
        //Bullet start point
        [SerializeField] protected Transform _gun;
        //Delay time
        [SerializeField] protected float _rechargeTime = 0.2f;

        public bool IsVisible { get; internal set; }
        #endregion


        #region Abstract Function
        //Fire call function, important for all children classes
        public abstract void Fire();
        #endregion
    }
}
