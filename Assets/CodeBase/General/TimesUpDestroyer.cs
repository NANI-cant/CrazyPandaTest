using CodeBase.TimeProviding;
using UnityEngine;

namespace CodeBase.General {
    [RequireComponent(typeof(ITimeProvider))]
    public class TimesUpDestroyer: MonoBehaviour {
        [SerializeField] [Min(0f)] private float _lifeTime = 1000f;

        private ITimeProvider _timeProvider;
        private float _startTime;

        private void Awake() => _timeProvider = GetComponent<ITimeProvider>();
        private void Start() => _startTime = _timeProvider.Time;

        private void Update() {
            var passedTime = _timeProvider.Time - _startTime;
            if (passedTime >= _lifeTime) Destroy(gameObject);
        }
    }
}