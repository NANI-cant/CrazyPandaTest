using UnityEngine;

namespace CodeBase.TemporalSystem {
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PersonalTimeProvider))]
    public class TimeScalableRigidbody2D : MonoBehaviour {
        private Rigidbody2D _body;
        private PersonalTimeProvider _timeProvider;
        private TimeScaledBodyData _timeScaledBodyData;

        private void Awake() {
            _body = GetComponent<Rigidbody2D>();
            _timeProvider = GetComponent<PersonalTimeProvider>();
        }

        private void Start() {
            _timeScaledBodyData = new TimeScaledBodyData() {
                UnscaledMass = _body.mass,
                UnscaledGravity = _body.gravityScale,

                UnscaledLinearVelocity = _body.velocity,
                UnscaledAngularVelocity = _body.angularVelocity,

                LastLinearVelocity = _body.velocity * _timeProvider.TimeScale,
                LastAngularVelocity = _body.angularVelocity * _timeProvider.TimeScale,        
            };

            UpdateRigidbody();
        }

        private void FixedUpdate() {
            Vector2 linearAcceleration = _body.velocity - _timeScaledBodyData.LastLinearVelocity;
            _timeScaledBodyData.UnscaledLinearVelocity += linearAcceleration;
            _timeScaledBodyData.LastLinearVelocity = _timeScaledBodyData.UnscaledLinearVelocity * _timeProvider.TimeScale;

            float angularAcceleration = _body.angularVelocity - _timeScaledBodyData.LastAngularVelocity;
            _timeScaledBodyData.UnscaledAngularVelocity += angularAcceleration;
            _timeScaledBodyData.LastAngularVelocity = _timeScaledBodyData.UnscaledAngularVelocity * _timeProvider.TimeScale;
            
            UpdateRigidbody();
        }

        private void UpdateRigidbody() {
            _body.mass = _timeScaledBodyData.UnscaledMass / _timeProvider.TimeScale;
            _body.gravityScale = _timeScaledBodyData.UnscaledGravity * _timeProvider.TimeScale;
            _body.velocity = _timeScaledBodyData.LastLinearVelocity;
            _body.angularVelocity = _timeScaledBodyData.LastAngularVelocity;
        }
    }
}