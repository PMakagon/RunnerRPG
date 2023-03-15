using System;
using System.Collections.Generic;
using EventHolders;
using SlimeRPG.Core.Enemies;
using SlimeRPG.Core.Projectiles;
using SlimeRPG.Core.Service;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SlimeRPG.Core.Player
{
    public class PlayerShootingController : MonoBehaviour
    {
        [SerializeField] private PlayerShootRangeTrigger shootRangeTrigger;
        [SerializeField] private ProjectileConfig defaultProjectileConfig;
        [SerializeField]public List<ProjectileConfig> _replaceTypes = new List<ProjectileConfig>();
        [SerializeField]public List<ProjectileConfig> _additionTypes = new List<ProjectileConfig>();
        private GameData _gameData;
        private Queue<Enemy> _enemiesInRange;
        private bool _isEnemyInRange;

        [Inject]
        private void Construct(GameData gameData)
        {
            _gameData = gameData;
        }

        private void Awake()
        {
            _enemiesInRange = new Queue<Enemy>();
            shootRangeTrigger.OnEnemyEnteredInRange += AddEnemyInQueue;
            EnemyEventHolder.OnEnemyDied += DequeueDeadEnemy;
        }

        private void OnDestroy()
        {
            shootRangeTrigger.OnEnemyEnteredInRange -= AddEnemyInQueue;
            EnemyEventHolder.OnEnemyDied -= DequeueDeadEnemy;
        }

        private void AddEnemyInQueue(Enemy enemy)
        {
            if (_enemiesInRange.Contains(enemy)) return;
            _enemiesInRange.Enqueue(enemy);
            _isEnemyInRange = true;
            // Debug.Log("ENEMY ADDED " + _enemiesInRange.Count);
        }

        private void DequeueDeadEnemy(Enemy deadEnemy)
        {
            _enemiesInRange.Dequeue();
            if (_enemiesInRange.Count == 0) _isEnemyInRange = false;
            // Debug.Log("DEQUEUE " + _enemiesInRange.Count);
        }

        public void AddProjectile(ProjectileConfig projectile)
        {
            switch (projectile.ShootType)
            {
                case ProjectileShootType.Replace:
                    _replaceTypes.Add(projectile);
                    return;
                case ProjectileShootType.Addition:
                    _additionTypes.Add(projectile);
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void RemoveProjectile(ProjectileConfig projectile)
        {
        }

        public void Shoot()
        {
            if (_isEnemyInRange)
            {
                ShootProjectiles(_enemiesInRange.Peek());
            }
        }

        private void ShootProjectiles(Enemy enemy)
        {
            var random = Random.value;
            var enemyTransform = enemy.transform;
            ProjectileBase mainProjectile = null;
            ProjectileBase extraProjectile = null;
            var parent = GameManager.Instance.LevelBuilder.CurrentLevelBlock.transform;
            foreach (var projectileConfig in _replaceTypes)
            {
                if (projectileConfig.BaseChance >= random)
                {
                    mainProjectile = Instantiate(projectileConfig.Prefab, parent,true);
                    mainProjectile.FinalDamage = _gameData.PlayerConfig.Damage + projectileConfig.BaseDamage;
                }
            }
            
            foreach (var projectileConfig in _additionTypes)
            {
                if (projectileConfig.BaseChance >= random)
                {
                    extraProjectile = Instantiate(projectileConfig.Prefab,parent, true);
                    extraProjectile.FinalDamage = _gameData.PlayerConfig.Damage + projectileConfig.BaseDamage;
                }
            }
            
            if (mainProjectile == null)
            {
                mainProjectile = Instantiate(defaultProjectileConfig.Prefab,parent, true);
                mainProjectile.FinalDamage = _gameData.PlayerConfig.Damage + defaultProjectileConfig.BaseDamage;
            }

            if (extraProjectile!=null)
            {
                extraProjectile.Shoot(enemyTransform, transform.position, _gameData.PlayerConfig.AttackSpeed);
            }
            mainProjectile.Shoot(enemyTransform, transform.position, _gameData.PlayerConfig.AttackSpeed);
        }

        public bool IsEnemyInRange => _isEnemyInRange;
    }
}