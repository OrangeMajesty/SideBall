using System;
using Core;
using Struct;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class TapToPlay: MonoBehaviour, IPointerClickHandler
    {
        private void OnEnable()
        {
            Debug.Log("TapToPlay OnEnable");
        }

        [SerializeField]
        private MessagePanelController panel;
        public void OnPointerClick(PointerEventData eventData)
        {
            Hide();
            EventManager.TriggerEvent(EventTypes.GameStart);
        }

        private void Hide()
        {
            // if (panel)
            //     panel.Hide();
            // else
                gameObject.SetActive(false);
        }
        
    }
}