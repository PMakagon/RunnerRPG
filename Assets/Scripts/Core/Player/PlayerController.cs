using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using EventHolders;
using SlimeRPG.Core.Configs;
using SlimeRPG.Core.Data;
using SlimeRPG.Core.Enemies;
using SlimeRPG.Core.Projectiles;
using SlimeRPG.Core.Service;
using UI;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Core.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private HitPopup hitPopupPrefab;
        private PlayerShootingController _shootingController;
        private PlayerData _playerData;
        private GameData _gameData;
        
        private bool _isInputDisabled;

        [Inject]
        private void Construct(GameData gameData)
        {
            _playerData = gameData.PlayerData;
            _gameData = gameData;
        }
        private void Awake()
        {
            _shootingController = GetComponent<PlayerShootingController>();
            EnemyEventHolder.OnEnemyAttack += TakeDamage;
            LevelEventHolder.OnNewBlockReady += HandleMovement;
            LevelEventHolder.OnLevelEnter += EnableInput;
            StoreEventHolder.OnHealthUpgraded += UpdateHealth;
        }

        private void Start()
        {
            EnableInput();
            UpdateHealth(_playerData.CurrentHealth);
        }

        private void OnDestroy()
        {
            EnemyEventHolder.OnEnemyAttack -= TakeDamage;
            LevelEventHolder.OnNewBlockReady -= HandleMovement;
            LevelEventHolder.OnLevelEnter -= EnableInput;
            StoreEventHolder.OnHealthUpgraded -= UpdateHealth;
        }
        
        public void Attack()
        {
            if (_isInputDisabled) return;
            _shootingController.Shoot();
        }

        private void EnableInput()
        {
            _isInputDisabled = false;
        }

        private void DisableInput()
        {
            _isInputDisabled = true;
        }

        private void HandleMovement()
        {
            StartCoroutine(nameof(MoveToNextLevel));
            DisableInput();
        }

        private IEnumerator MoveToNextLevel()
        {
            Vector3 nextLevelPos = GameManager.Instance.LevelBuilder.NextLevelBlock.StartPoint.position;
            float time = 0;
            while (time < 1)
            {
                transform.position = Vector3.Lerp(transform.position, nextLevelPos, time);
                time += Time.deltaTime *_gameData.PlayerConfig.MoveSpeed;
                yield return null;
            }
        }

        private void TakeDamage(float damage)
        {
            _playerData.CurrentHealth -= damage;
            SpawnHitPopup((int)damage);
            healthBar.UpdateHealthBar((int) _gameData.PlayerConfig.Health, (int)_playerData.CurrentHealth);
            PlayerEventHolder.BroadcastOnDamageTaken(damage);
            if ( _playerData.CurrentHealth <= 0)
            {
                PlayerEventHolder.BroadcastOnPlayerDied();
            }
        }

        private void SpawnHitPopup(int points)
        {
            var popup = Instantiate(hitPopupPrefab, transform.position, Quaternion.identity);
            popup.SetHitPoints(points);
            var mytween = popup.transform.DOMove(popup.transform.position+Vector3.up*2, 5f).SetSpeedBased(true).SetAutoKill(true);
            mytween.OnComplete(popup.DestroyPopup);
        }

        private void UpdateHealth(float newHealth)
        {
            healthBar.UpdateHealthBar((int)_gameData.PlayerConfig.Health, (int) _playerData.CurrentHealth);
        }
        
    }
}