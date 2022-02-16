using System;
using Core;
using Struct;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class TapToRestart: MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private MessagePanelController panel;
        public void OnPointerClick(PointerEventData eventData)
        {
            Hide();

            EventManager.TriggerEvent(EventTypes.GameResetLevel);
            EventManager.TriggerEvent(EventTypes.GameStart);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}