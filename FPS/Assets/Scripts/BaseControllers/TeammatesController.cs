using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace FPS
{
    public class TeammatesController : MonoBehaviour
    {
        public static UnityAction<TeammateModel> OnGivingOrder;
        private TeammateModel _currenTeammate;


        public void MoveByCommand()
        {
            RaycastHit selectedTeammate;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out selectedTeammate))
            {
                TeammateModel teammate = selectedTeammate.collider.GetComponent<TeammateModel>();
                if (teammate)
                {
                    GivingOrders(teammate);
                }
                else if (_currenTeammate)
                {
                    _currenTeammate.SetMovingPoint(selectedTeammate.point);
                }
            }
        }
        public void GivingOrders(TeammateModel teammate)
        {
            _currenTeammate = teammate;
            if (OnGivingOrder != null)
            {
                OnGivingOrder(teammate);
            }
        }
    }
}

