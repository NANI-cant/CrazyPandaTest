using System;
using UnityEngine;

namespace CodeBase.TimeProviding.Impl {
    public class UnityTimeProviderAccess: MonoBehaviour, ITimeProvider {
        private UnityTimeProvider _unityTimeProvider;

        public float TimeScale => _unityTimeProvider.TimeScale;
        public float Time => _unityTimeProvider.Time;
        public float DeltaTime => _unityTimeProvider.DeltaTime;
        public float UnscaledTime => _unityTimeProvider.UnscaledTime;
        public float UnscaledDeltaTime => _unityTimeProvider.UnscaledDeltaTime;
        
        public event Action ScaleChanged;

        private void Awake() {
            _unityTimeProvider = new UnityTimeProvider();
            _unityTimeProvider.ScaleChanged += OnScaleChanged;
        }
        
        private void OnDestroy() => _unityTimeProvider.ScaleChanged -= OnScaleChanged;
        
        public void SlowDown(float factor) => _unityTimeProvider.SlowDown(factor);
        public void SpeedUp(float factor) => _unityTimeProvider.SpeedUp(factor);
        
        private void OnScaleChanged() => ScaleChanged?.Invoke();
    }
}