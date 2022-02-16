using Core;
using Struct;
using UnityEngine;

namespace Gameplay
{
    public class BarrierPoolController: PoolObject
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerSideGravity _))
            {
                ReturnToPool();
                // EventManager.TriggerEvent(EventTypes.BarrierHide);
            }
        }
    }
}