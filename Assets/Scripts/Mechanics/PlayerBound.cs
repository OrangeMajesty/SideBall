using Core;
using Struct;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mechanics
{
    public class PlayerBound: MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            EventManager.TriggerEvent(EventTypes.ChangeSide);
        }
    }
}