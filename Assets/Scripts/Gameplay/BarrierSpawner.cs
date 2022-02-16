using Core;
using Models;
using UnityEngine;

namespace Gameplay
{
    public class BarrierSpawner: MonoBehaviour
    {
        public void Spawn()
        {
            var barrier = BarrierPool.Instance().GetObject();
            barrier.transform.position = transform.position;
            var xScale = Random.Range(3, 10);
            barrier.transform.localScale = new Vector3(xScale, 1, 1);
        }
    }
}