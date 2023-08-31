using UnityEngine;

namespace CodeBase.TemporalSystem {
    [RequireComponent(typeof(Collider2D))]
    public class TemporalAnomaly: MonoBehaviour {
        [SerializeField][Min(1f)] private float _slowDownFactor = 2;

        private void Awake() {
            Collider2D trigger = GetComponent<Collider2D>();
            trigger.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
            => other.GetComponent<PersonalTimeProvider>()?.SlowDown(_slowDownFactor);

        private void OnTriggerExit2D(Collider2D other) 
            => other.GetComponent<PersonalTimeProvider>()?.SpeedUp(_slowDownFactor);
    }
}
