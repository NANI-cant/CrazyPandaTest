using UnityEngine;

namespace CodeBase.ShootingSystem {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile: MonoBehaviour {
        [SerializeField][Min(0f)] private float _speed;
        [SerializeField] private float _angularVelocity;
        
        private Rigidbody2D _rigidbody;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start() {
            _rigidbody.velocity = transform.up * _speed;
            _rigidbody.angularVelocity = _angularVelocity;
        }
    }
}