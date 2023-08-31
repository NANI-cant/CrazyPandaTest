using CodeBase.TimeProviding;
using CodeBase.TimeProviding.Impl;
using UnityEngine;

namespace CodeBase.TemporalSystem {
    public class PersonalTimeProvider: MonoBehaviour, ITimeProvider {
        private ITimeProvider _decoratedTimeProvider;
        
        public float TimeScale { get; private set; } = 1;
        public float Time { get; private set; }
        public float DeltaTime => _decoratedTimeProvider.DeltaTime * TimeScale;
        public float UnscaledTime => _decoratedTimeProvider.UnscaledTime;
        public float UnscaledDeltaTime => _decoratedTimeProvider.UnscaledDeltaTime;

        private void Awake() {
            _decoratedTimeProvider = new UnityTimeProvider();
            Time = _decoratedTimeProvider.Time;
        }

        public void SlowDown(float factor) => TimeScale /= factor;
        public void SpeedUp(float factor) => TimeScale *= factor;

        private void Update() => Time += DeltaTime;
    }
}