using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace FPS
{
    public class TeammateModel : MonoBehaviour
    {
        private NavMeshAgent _teammateAgent;

        public ThirdPersonCharacter _teammateCharacter;

        private void Start()
        {
            _teammateAgent = GetComponent<NavMeshAgent>();
            _teammateCharacter = GetComponent<ThirdPersonCharacter>();

            _teammateAgent.updatePosition = false;
            _teammateAgent.updateRotation = false;
        }

        private void Update()
        {
            if (_teammateAgent.remainingDistance > _teammateAgent.stoppingDistance)
            {
                _teammateCharacter.Move(_teammateAgent.desiredVelocity, false,false);
            }
            else
            {
                _teammateCharacter.Move(Vector3.zero, false, false);
            }
        }

        public void SetMovingPoint(Vector3 pos)
        {
            _teammateAgent.SetDestination(pos);
        }
    }
}

