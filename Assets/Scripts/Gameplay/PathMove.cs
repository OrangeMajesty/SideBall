using System;
using System.Collections;
using Core;
using Struct;
using UnityEngine;

namespace Gameplay
{
    public class PathMove : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private bool isMoving;

        private void Start()
        {
            EventManager.StartListening(EventTypes.GameStart, StartMove);
            EventManager.StartListening(EventTypes.GameEnd, StopMove);
            EventManager.StartListening(EventTypes.GameResetLevel, RestartPosition);
        }

        private void OnDestroy()
        {
            EventManager.StopListening(EventTypes.GameStart, StartMove);
            EventManager.StopListening(EventTypes.GameEnd, StopMove);
            EventManager.StopListening(EventTypes.GameResetLevel, RestartPosition);
        }

        private void StartMove()
        {
            isMoving = true;
            StartCoroutine(Move());
        }

        private void RestartPosition()
        {
            transform.position = Vector3.zero;
        }

        private void StopMove()
        {
            isMoving = false;
            StopAllCoroutines();
        }

        private IEnumerator Move()
        {
            while (isMoving)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
                yield return null;
            }
        }
    }
}
