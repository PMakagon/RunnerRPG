using EventHolders;
using SlimeRPG.Core.Configs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SlimeRPG.Core.Service
{
    public class EnemyService : MonoBehaviour
    {
        [SerializeField] private int enemiesOnLevel = 1;
        [SerializeField] private EnemyConfig enemyConfig;
        [SerializeField] private PlayerConfig playerConfig;
        private EnemyProvider _enemyProvider;
        private LevelBuilder _levelBuilder;
        private GameManager _gameManager;

        private void Awake()
        {
            LevelEventHolder.OnLevelCenter += AdjustEnemySpawn;
        }

        private void Start()
        {
            _enemyProvider = GameManager.Instance.EnemyProvider;
            _levelBuilder = GameManager.Instance.LevelBuilder;
        }

        private void OnDestroy()
        {
            LevelEventHolder.OnLevelCenter -= AdjustEnemySpawn;
        }

        private void AdjustEnemySpawn()
        {
            enemiesOnLevel = Random.Range(_levelBuilder.LevelNumber, _levelBuilder.LevelNumber * 2);
            
        }

        public int EnemiesOnLevel => enemiesOnLevel;
    }
}