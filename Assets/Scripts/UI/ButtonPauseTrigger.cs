using Core;
using Helper;
using Models;
using UnityEngine;

namespace UI
{
    public class ButtonPauseTrigger : ButtonTrigger
    {
        private void Start()
        {
            LoadState();
            onClicked += OnClicked;
            UpdateIcon();
        }
        
        private void LoadState()
        {
            state = TimeScaleController.GetStatus();
        }
        
        private void OnClicked()
        {
            state = !state;
            TimeScaleController.SetStatus(state);
            UpdateIcon();

            var panel = Simulation.GetModel<UIPanels>().pausePanel;
            if (!state)
                panel.Hide();
            else
                MessagePanelsManager.Instance().Show(panel);
        }

        private void UpdateIcon()
        {
            var icon = GetIcon();
            icon.color = state ? new Color(1f, 0.47f, 0.43f) : Color.white;
        }
    }
}