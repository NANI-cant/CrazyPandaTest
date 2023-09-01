using System;

namespace CodeBase.TimeProviding.Impl {
    public class UnityTimeProvider: ITimeProvider {
        public float TimeScale => UnityEngine.Time.timeScale;
        public float Time => UnityEngine.Time.time;
        public float DeltaTime => UnityEngine.Time.deltaTime;
        public float UnscaledTime => UnityEngine.Time.unscaledTime;
        public float UnscaledDeltaTime => UnityEngine.Time.unscaledDeltaTime;
        
        public event Action ScaleChanged;

        public void SlowDown(float factor) {
            UnityEngine.Time.timeScale /= factor;
            ScaleChanged?.Invoke();
        }

        public void SpeedUp(float factor) {
            UnityEngine.Time.timeScale *= factor;
            ScaleChanged?.Invoke();
        }
    }
}