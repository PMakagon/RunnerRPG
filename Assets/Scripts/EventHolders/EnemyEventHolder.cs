using System;
using SlimeRPG.Core.Enemies;
using UnityEngine;

namespace EventHolders
{
    public static class EnemyEventHolder
    {
        public static event Action<Enemy> OnEnemySpawned;
        public static event Action<Enemy> OnEnemyDied;
        public static event Action<float> OnEnemyAttack;
        public static event Action<float> OnEnemyHit;
        public static event Action OnAllEnemiesDead;

        public static void BroadcastOnEnemyAttack(float damage)
        {
            OnEnemyAttack?.Invoke(damage);
            // Debug.Log("ENEMY ATTACKS. Damage: " + damage);
        }
        
        public static void BroadcastOnEnemyDied(Enemy deadEnemy)
        {
            OnEnemyDied?.Invoke(deadEnemy);
            // Debug.Log("ENEMY DIED");
        }
        
        public static void BroadcastOnEnemySpawned(Enemy newEnemy)
        {
            OnEnemySpawned?.Invoke(newEnemy);
        }
        
        public static void BroadcastOnEnemyHit(float damageToEnemy)
        {
            OnEnemyHit?.Invoke(damageToEnemy);
        }
        
        public static void BroadcastOnAllEnemiesDead()
        {
            OnAllEnemiesDead?.Invoke();
            Debug.Log("ALL ENEMIES DIED");
        }
    }
}