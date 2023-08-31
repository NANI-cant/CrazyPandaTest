using UnityEngine;

namespace CodeBase.ShootingSystem {
    public class ProjectileShooter : MonoBehaviour, IShooter {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _shootPoint;
    
        public void Shoot() => Instantiate(_projectilePrefab, _shootPoint.position, _shootPoint.rotation);
    }
}