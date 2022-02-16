using System;
using Core;
using Struct;
using UnityEngine;

namespace Gameplay
{
    public class FirstBarrier: MonoBehaviour
    {
        private void Start()
        {
            EventManager.StartListening(EventTypes.GameStart, Show);
        }

        private void OnDestroy()
        {
            EventManager.StopListening(EventTypes.GameStart, Show);
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }
    }
}