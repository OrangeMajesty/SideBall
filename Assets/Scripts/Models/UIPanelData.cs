using Core;
using UnityEngine;

namespace Models
{
    public class UIPanelData: MonoBehaviour
    {
        public UIPanels Panels = Simulation.GetModel<UIPanels>();
    }
}