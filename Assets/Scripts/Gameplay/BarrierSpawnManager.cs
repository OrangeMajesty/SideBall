using System;
using System.Collections;
using Core;
using Helper;
using Struct;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class BarrierSpawnManager: MonoBehaviour
    {
        [SerializeField]
        private BarrierSpawner[] spawners;
        [SerializeField]
        private int lastSpawner;
        [SerializeField]
        private float waitBeforeSpawn = 2;
        private bool isSpawning;

        private void OnEnable()
        {
            EventManager.StartListening(EventTypes.GameStart, StartSpawn);
            EventManager.StartListening(EventTypes.GameEnd, StopSpawn);
        
        }
        private void OnDisable()
        {
            EventManager.StopListening(EventTypes.GameStart, StartSpawn);
            EventManager.StopListening(EventTypes.GameEnd, StopSpawn);
        }

        private void StartSpawn()
        {
            isSpawning = true;
            ResetLastSpawner();
            StartCoroutine(ScheduleSpawn());
        }

        private void StopSpawn()
        {
            isSpawning = false;
            StopAllCoroutines();
        }

        private void ResetLastSpawner()
        {
            lastSpawner = -1;
        }

        private IEnumerator ScheduleSpawn()
        {
            while (isSpawning)
            {
                Spawn();
                yield return CoroutineHelper.WaitFor(waitBeforeSpawn);
            }
        }

        private void Spawn()
        {
            if (!isSpawning)
                return;
            
            if (lastSpawner == -1)
                lastSpawner = Random.Range(0, spawners.Length);

            var index = (spawners.Length - 1) - lastSpawner;
            spawners[index].Spawn();
            lastSpawner = index;
        }
    }
}