using System;
using System.Collections;
using Core;
using Struct;
using UnityEngine;

namespace Gameplay
{
    public class PlayerSideGravity: MonoBehaviour
    {
        [SerializeField]
        private float gravityScale;
        [SerializeField]
        private LayerMask raycastFilter;
        private Vector3 gravityDirection = Vector3.forward;
        private bool isGravityEnable;
        private bool isGround;

        private void OnEnable()
        {
            EventManager.StartListening(EventTypes.ChangeSide, OnChangeSide);
            EventManager.StartListening(EventTypes.GameStart, StartGravity);
            EventManager.StartListening(EventTypes.GameEnd, StopGravity);
        }
        
        private void OnDisable()
        {
            EventManager.StopListening(EventTypes.ChangeSide, OnChangeSide);
            EventManager.StopListening(EventTypes.GameStart, StartGravity);
            EventManager.StopListening(EventTypes.GameEnd, StopGravity);
        }

        private void OnChangeSide()
        {
            if (!isGround)
                return;
            
            gravityDirection = gravityDirection == Vector3.forward ? Vector3.back : Vector3.forward;
            isGround = false;
        }

        private void StartGravity()
        {
            isGravityEnable = true;
            RestartPosition();
            StartCoroutine(Gravity());
        }

        private void RestartPosition()
        {
            transform.position = Vector3.zero;
        }

        private void StopGravity()
        {
            isGravityEnable = false;
            StopAllCoroutines();
        }

        private IEnumerator Gravity()
        {
            var ray = new Ray(transform.position + (Vector3.left * 0.2f), gravityDirection);
            RaycastHit[] hits = new RaycastHit[1];
            while (isGravityEnable)
            {
                Debug.Log("Gravity");
                ray.direction = gravityDirection;
                if (Physics.RaycastNonAlloc(ray, hits, 0.5f, raycastFilter) == 0)
                {
                    transform.Translate((gravityDirection * gravityScale) * Time.deltaTime);
                    ray.origin = transform.position + (Vector3.left * 0.2f);
                }
                else
                {
                    isGround = true;
                }

                yield return null;
            }
        }
    }
}