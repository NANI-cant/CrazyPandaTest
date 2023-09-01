using UnityEngine;

namespace CodeBase.TemporalSystem {
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PersonalTimeProvider))]
    public class TimeScalableRigidbody2D : MonoBehaviour {
        private Rigidbody2D _body;
        private PersonalTimeProvider _timeProvider;
        private float _lastTimeScale = 1;

        private void Awake() {
            _body = GetComponent<Rigidbody2D>();
            _timeProvider = GetComponent<PersonalTimeProvider>();
            _timeProvider.ScaleChanged += AdaptForNewScale;
        }

        private void Start() => AdaptForNewScale();
        private void OnDestroy() => _timeProvider.ScaleChanged -= AdaptForNewScale;

        private void AdaptForNewScale() {
            _body.velocity *= _timeProvider.TimeScale/_lastTimeScale;
            _body.angularVelocity *= _timeProvider.TimeScale/_lastTimeScale;
            _body.gravityScale *= Mathf.Pow(_timeProvider.TimeScale, 2) / Mathf.Pow(_lastTimeScale, 2);

            _lastTimeScale = _timeProvider.TimeScale;
        }
    }
}