using UnityEngine;

namespace CodeBase.TimeProviding.Impl {
    public class UnityTimeProviderAccess: MonoBehaviour, ITimeProvider {
        private UnityTimeProvider _unityTimeProvider;

        public float TimeScale => _unityTimeProvider.TimeScale;
        public float Time => _unityTimeProvider.Time;
        public float DeltaTime => _unityTimeProvider.DeltaTime;
        public float UnscaledTime => _unityTimeProvider.UnscaledTime;
        public float UnscaledDeltaTime => _unityTimeProvider.UnscaledDeltaTime;

        private void Awake() => _unityTimeProvider = new UnityTimeProvider();

        public void SlowDown(float factor) => _unityTimeProvider.SlowDown(factor);
        public void SpeedUp(float factor) => _unityTimeProvider.SpeedUp(factor);
    }
}