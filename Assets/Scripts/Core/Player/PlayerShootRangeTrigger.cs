using System;
using SlimeRPG.Core.Enemies;
using UnityEngine;

namespace SlimeRPG.Core.Player
{
    public class PlayerShootRangeTrigger : MonoBehaviour
    {
        public event Action<Enemy> OnEnemyEnteredInRange; 
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Enemy")) return;
            var enemy = other.gameObject.GetComponent<Enemy>();
            enemy.IsPlayerClose = true;
            OnEnemyEnteredInRange?.Invoke(enemy);
            // Debug.Log("ENEMY IN RANGE");
        }
    }
}