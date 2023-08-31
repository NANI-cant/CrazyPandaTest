using CodeBase.TimeProviding;
using UnityEngine;

namespace CodeBase.ShootingSystem {
    [RequireComponent(typeof(IShooter))]
    [RequireComponent(typeof(ITimeProvider))]
    public class AutomaticShooter : MonoBehaviour {
        [SerializeField][Min(0f)] private float _speed;

        private float _lastShootTime = float.NegativeInfinity;
        private IShooter _shooter;
        private ITimeProvider _timeProvider;
        private bool CooldownPassed => (_timeProvider.Time - _lastShootTime) > 1 / _speed;

        private void Awake() {
            _shooter = GetComponent<IShooter>();
            _timeProvider = GetComponent<ITimeProvider>();
        }

        private void Update() {
            if(!CooldownPassed) return;
            
            _shooter.Shoot();
            _lastShootTime = _timeProvider.Time;
        }
    }
}