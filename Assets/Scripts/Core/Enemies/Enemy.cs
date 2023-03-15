using System.Collections;
using DG.Tweening;
using EventHolders;
using SlimeRPG.Core.Configs;
using UI;
using UnityEngine;

namespace SlimeRPG.Core.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyConfig enemyConfig;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private HitPopup hitPopupPrefab;
        private float _currentHealth;
        private bool _isPlayerClose;
        private bool _isReachedPlayer;
        private bool _isAttacking;
        private bool _isDead;
        private GameManager _gameManager;
        private float _distanceToPlayer;
        
        private void Awake()
        {
            _currentHealth = enemyConfig.Health;
            healthBar.UpdateHealthBar((int)enemyConfig.Health, (int)_currentHealth);
            _gameManager = GameManager.Instance;
        }

        private void Start()
        {
            CheckRange();
            StartCoroutine(nameof(MoveToPlayer));
        }

        private void OnDestroy()
        {
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player")) _isReachedPlayer = true;
        }


        void Update()
        {
            CheckRange();
        }

        private void CheckRange()
        {
            _distanceToPlayer = Vector3.Distance(transform.position, _gameManager.Player.transform.position);
            if (_isReachedPlayer) return;
            if (enemyConfig.AttackRange>=_distanceToPlayer)
            {
                _isReachedPlayer = true;
                StopCoroutine(nameof(MoveToPlayer));
                AttackPlayer();
            }
        }

        private void AttackPlayer()
        {
            _isAttacking = true;
            StartCoroutine(nameof(DamagePlayer));
        }

        private IEnumerator DamagePlayer()
        {
            while (_isAttacking)
            {
                EnemyEventHolder.BroadcastOnEnemyAttack(enemyConfig.Damage);
                yield return new WaitForSeconds(enemyConfig.AttackCoolDown);
            }
        }

        private void HandleDeath()
        {
            _isDead = true;
            _isAttacking = false;
            EnemyEventHolder.BroadcastOnEnemyDied(this);
            StopAllCoroutines();
        }

        public void TakeDamage(float damageToEnemy)
        {
            _currentHealth -= damageToEnemy;
            if (_currentHealth<=0) HandleDeath();
            healthBar.UpdateHealthBar((int)enemyConfig.Health, (int)_currentHealth);
            SpawnHitPopup((int)damageToEnemy);
        }

        private void SpawnHitPopup(int points)
        {
            var popup = Instantiate(hitPopupPrefab, transform.position,Quaternion.identity);
            popup.SetHitPoints(points);
            var mytween = popup.transform.DOMove(popup.transform.position+Vector3.up*2, 5f).SetSpeedBased(true).SetAutoKill(true);
            mytween.OnKill(popup.DestroyPopup);
        }


        private IEnumerator MoveToPlayer()
        {
            var remainDistance = _distanceToPlayer;
            while (remainDistance > 0)
            {
                transform.position = Vector3.Lerp(transform.position,_gameManager.Player.transform.position,1 - remainDistance / _distanceToPlayer);
                remainDistance -= enemyConfig.Speed * Time.deltaTime;
                yield return null;
            }
        
        }

        public EnemyConfig EnemyConfig => enemyConfig;

        public bool IsPlayerClose
        {
            get => _isPlayerClose;
            set => _isPlayerClose = value;
        }

        public bool IsAttacking => _isAttacking;

        public bool IsDead => _isDead;
    }
}
