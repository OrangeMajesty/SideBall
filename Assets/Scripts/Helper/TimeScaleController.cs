using UnityEngine;

namespace Helper
{
    public static class TimeScaleController
    {
        private static bool IsPaused;
        private static float defaultScale;

        public static bool GetStatus()
            => IsPaused;

        public static void SetStatus(bool status)
        {
            if (defaultScale == 0)
                defaultScale = Time.timeScale;
            
            IsPaused = status;
            Time.timeScale = IsPaused ? 0 : defaultScale;
        }
    }
}