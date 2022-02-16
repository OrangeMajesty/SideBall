using System.Collections;
using UnityEngine;

namespace Core
{
    public class PoolObject: MonoBehaviour
    {
        public IEnumerator Release(float during)
        {
            if (during > 0)
            {
                for (float time = 0; time < during;)
                {
                    time += Time.deltaTime;
                    yield return null;
                }
            }
            yield return null;
            ReturnToPool();
        }

        public void SetActive()
        {
            gameObject.SetActive(true);
        }
        
        public void ReturnToPool() {
            gameObject.SetActive(false);
        }
    }
}