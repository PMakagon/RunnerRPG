using EventHolders;
using SlimeRPG.Core.Configs;
using SlimeRPG.Core.Data;
using SlimeRPG.Core.Enemies;
using UnityEngine;

namespace SlimeRPG.Core.Service
{
    public class StoreService : MonoBehaviour
    {
        [SerializeField] private CoinsData coinsData;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private PriceData priceData;

        private void Awake()
        {
            EnemyEventHolder.OnEnemyDied += GetCoinsFromEnemy;
        }

        private void OnDestroy()
        {
            EnemyEventHolder.OnEnemyDied -= GetCoinsFromEnemy;
        }

        public void UpgradeHealth()
        {
            if (coinsData.GetCoins() < priceData.healthUpgradePrice) return;
            coinsData.RemoveCoins((int)priceData.healthUpgradePrice);
            playerConfig.Health += playerConfig.Health / 3;
            priceData.healthUpgradePrice *= 2;
            StoreEventHolder.BroadcastOnHealthUpgraded(playerConfig.Health);

        }
        
        public void UpgradeDamage()
        {
            if (coinsData.GetCoins() < priceData.damageUpgradePrice) return;
            coinsData.RemoveCoins((int)priceData.damageUpgradePrice);
            playerConfig.Damage += playerConfig.Damage / 2;
            priceData.damageUpgradePrice *= 2;
            StoreEventHolder.BroadcastOnDamageUpgraded(playerConfig.Damage);
            
        }
        
        public void UpgradeAttackSpeed()
        {
            if (coinsData.GetCoins() < priceData.attackSpeedUpgradePrice) return;
            coinsData.RemoveCoins((int)priceData.attackSpeedUpgradePrice);
            playerConfig.AttackSpeed += 0.1f;
            priceData.attackSpeedUpgradePrice *= 2;
            StoreEventHolder.BroadcastOnAttackSpeedUpgraded(playerConfig.AttackSpeed);
            
        }

        private void GetCoinsFromEnemy(Enemy enemy)
        {
           coinsData.AddCoins(enemy.EnemyConfig.Reward); 
        }
        
    }
}