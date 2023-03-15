using System.Collections.Generic;
using EventHolders;
using SlimeRPG.Core.Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SlimeRPG.Core
{
    public class EnemyProvider : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;
        private GameManager _gameManager;
        private List<Enemy> _enemies;
    
        private void Awake()
        {
            _enemies = new List<Enemy>();
            LevelEventHolder.OnLevelEnter += Spawn;
            EnemyEventHolder.OnEnemyDied += DisposeEnemy;
        }

        private void OnDestroy()
        {
            LevelEventHolder.OnLevelEnter -= Spawn;
            EnemyEventHolder.OnEnemyDied -= DisposeEnemy;
        }

        private void Start()
        {
            _gameManager = GameManager.Instance;
            Spawn();
        }

        private void DisposeEnemy(Enemy deadEnemy)
        {
            _enemies.Remove(deadEnemy);
            Destroy(deadEnemy.gameObject);
            if (_enemies.Count==0) EnemyEventHolder.BroadcastOnAllEnemiesDead();
        }

        private void Spawn()
        {
            SpawnEnemies(_gameManager.EnemyService.EnemiesOnLevel);
        }

        private void SpawnEnemies(int amount)
        {
            var spawnCenter = _gameManager.LevelBuilder.CurrentLevelBlock.EnemySpawnPoint.position;
            for (int i = 0; i < amount; i++)
            {
                var newEnemy = Instantiate(enemyPrefab,spawnCenter + (Vector3)(2 * Random.insideUnitCircle),Quaternion.identity,transform);
                newEnemy.gameObject.name = "Enemy " + i++;
                EnemyEventHolder.BroadcastOnEnemySpawned(newEnemy);
                _enemies.Add(newEnemy);
            }

            // Debug.Log("ENEMIES SPAWNED");
        }
    
    }
}
