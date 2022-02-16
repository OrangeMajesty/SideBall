using System.Collections;
using UnityEngine;

namespace Helper
{
    public static class CoroutineHelper
    {
        public static IEnumerator WaitFor(float sec)
        {
            var second = Mathf.Abs(sec);
            for (float waited = 0; waited < second; waited += Time.deltaTime)
                yield return null;
        }
    }
}