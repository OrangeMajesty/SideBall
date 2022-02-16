using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PoolManager<T> : PoolObject where T : MonoBehaviour
    {
        [SerializeField] private float count;
        [SerializeField] private T prefab;
        private List<T> _objects;

        private static PoolManager<T> _instance;

        public static PoolManager<T> Instance()
        {
            if (_instance == null)
                throw new Exception("PoolManager not found");
            return _instance;
        }

        public T GetObject(bool activate = true)
        {
            foreach (var poolObject in _objects)
            {
                if (!poolObject.gameObject.activeInHierarchy)
                {
                    if (activate)
                        poolObject.gameObject.SetActive(true);
                    return poolObject;
                }
            }

            var newPoolObject = Instantiate(prefab, transform, true);
            if (activate)
                newPoolObject.gameObject.SetActive(true);
            _objects.Add(newPoolObject);
            return newPoolObject;
        }

        private void Awake()
        {
            _instance = this;
            GenerateObjects();
        }

        private void GenerateObjects()
        {
            _objects = new List<T>();
            for (int i = 0; i < count; i++)
            {
                var poolObject = Instantiate(prefab, transform, true);
                poolObject.gameObject.SetActive(false);
                _objects.Add(poolObject);
            }
        }
    }
}