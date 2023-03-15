using UnityEngine;

namespace SlimeRPG.Core.Level
{
    public class LevelBlock : MonoBehaviour
    {
        [SerializeField] private LevelStartTrigger startTrigger;
        [SerializeField] private LevelBlockTrigger trigger;
        [SerializeField] private Transform startConnector;
        [SerializeField] private Transform endConnector;
        [SerializeField] private Transform enemySpawnPoint;
        [SerializeField] private Transform startPoint;

        public Transform StartPoint => startPoint;
        public LevelStartTrigger StartTrigger => startTrigger;
        public LevelBlockTrigger Trigger => trigger;
        public Transform StartConnector => startConnector;
        public Transform EndConnector => endConnector;
        public Transform EnemySpawnPoint => enemySpawnPoint;
    }
}
