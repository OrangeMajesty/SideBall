using Core;
using Models;
using Struct;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class LoseBarrierTrigger: MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerSideGravity _))
            {
                EventManager.TriggerEvent(EventTypes.GameEnd);
                var panel = Simulation.GetModel<UIPanels>().losePanel;
                if (panel)
                    MessagePanelsManager.Instance().Show(panel);
            }
        }
    }
}