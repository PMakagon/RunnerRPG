using SlimeRPG.Core.Configs;
using SlimeRPG.Core.Data;
using SlimeRPG.Core.Player;
using SlimeRPG.Core.Service;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private LevelBuilder levelBuilder;
        [SerializeField] private EnemyProvider enemyProvider;
        [SerializeField] private EnemyService enemyService;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private CoinsData coinsData;
        [SerializeField] private PriceData priceData;
        private PlayerController _player;

        private static GameManager GameManagerInstance;

        [Inject]
        private void Construct(PlayerController player)
        {
            _player = player;
        }
        private void Awake()
        {
            if (GameManagerInstance==null)
            {
                GameManagerInstance = this;
            }
            playerConfig.ResetData();
            coinsData.ResetData();
            priceData.ResetData();
        }

        public PlayerController Player => _player;
        public LevelBuilder LevelBuilder => levelBuilder;
        public EnemyProvider EnemyProvider => enemyProvider;
        public EnemyService EnemyService => enemyService;
        public static GameManager Instance => GameManagerInstance;
    }
}
