using System;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class MessagePanelController: MonoBehaviour
    {
        public UnityAction OnClosed;

        public void Hide()
        {
            MessagePanelsManager.Instance().Hide();
        }
        private void OnDisable()
        {
            OnClosed?.Invoke();
        }
    }
}