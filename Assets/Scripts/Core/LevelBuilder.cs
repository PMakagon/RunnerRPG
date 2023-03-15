using EventHolders;
using SlimeRPG.Core.Level;
using UnityEngine;

namespace SlimeRPG.Core
{
    public class LevelBuilder : MonoBehaviour
    {
        [SerializeField] private LevelBlock levelBlockPrefab;
        private LevelBlock _prevLevelBlock;
        public LevelBlock _currentLevelBlock;
        private LevelBlock _nextLevelBlock;
        private int _levelNumber = 1;

        private void Awake()
        {
            EnemyEventHolder.OnAllEnemiesDead += SpawnNewBlock;
            LevelEventHolder.OnLevelCenter += ReleasePreviousBlock;
            LevelEventHolder.OnLevelExit += SwapCurrentBlock;
        
        }

        private void OnDestroy()
        {
            EnemyEventHolder.OnAllEnemiesDead -= SpawnNewBlock;
            LevelEventHolder.OnLevelCenter -= ReleasePreviousBlock;
            LevelEventHolder.OnLevelExit -= SwapCurrentBlock;
        }

        private void SwapCurrentBlock()
        {
            _prevLevelBlock = _currentLevelBlock;
            _currentLevelBlock = _nextLevelBlock;
            _nextLevelBlock = null;
        }


        private void SpawnNewBlock()
        {
            _nextLevelBlock = Instantiate(levelBlockPrefab, transform);
            _levelNumber++;
            _nextLevelBlock.gameObject.name = "Level" + _levelNumber;
            LevelEventHolder.BroadcastOnNewBlockSpawn();
            AlignBlock(_nextLevelBlock.transform, _nextLevelBlock.StartConnector, _currentLevelBlock.EndConnector);
            LevelEventHolder.BroadcastOnNewBlockReady();
        }

        private void AlignBlock(Transform block, Transform startPoint, Transform endPoint)
        {
            if (!block || !startPoint || !endPoint) return;
            block.rotation = endPoint.rotation *
                             Quaternion.Inverse(Quaternion.Inverse(block.rotation) * startPoint.rotation);
            block.position = endPoint.position + (block.position - startPoint.position);
        }

        private void ReleasePreviousBlock()
        {
            if (_prevLevelBlock == null) return;
            Destroy(_prevLevelBlock.gameObject);
            LevelEventHolder.BroadcastOnBlockDestroyed();
            // Debug.Log("RELEASED");
        }

        public LevelBlock CurrentLevelBlock => _currentLevelBlock;

        public LevelBlock NextLevelBlock => _nextLevelBlock;

        public int LevelNumber => _levelNumber;
    }
}