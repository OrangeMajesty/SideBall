using System;
using UnityEngine;

namespace UI
{
    public class MessagePanelsManager: MonoBehaviour
    {
        [SerializeField]
        private MessagePanelController _lastOpenedPanel;
        private static MessagePanelsManager _instance;

        public static MessagePanelsManager Instance()
        {
            if (_instance == null)
                throw new Exception("Message panel Controller not found");

            return _instance;
        }

        public void Show(MessagePanelController panel)
        {
            // Hide();
            _lastOpenedPanel = panel;
            panel.gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            if (_lastOpenedPanel)
                _lastOpenedPanel.gameObject.SetActive(false);
        }
        
        private void Awake()
        {
            _instance = this;
        }
    }
}