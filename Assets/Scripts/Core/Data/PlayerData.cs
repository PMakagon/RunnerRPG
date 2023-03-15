using SlimeRPG.Core.Configs;
using UnityEngine;

namespace SlimeRPG.Core.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData", order = 1)]
    public class PlayerData : ScriptableObject
    {
        public float CurrentHealth { get; set; }

        public float CurrentDamage { get; set; }

        public float CurrentAttackSpeed { get; set; }

        public void SetData(PlayerConfig config)
        {
            CurrentHealth = config.Health;
            CurrentDamage = config.Damage;
            CurrentAttackSpeed = config.AttackSpeed;
        }
    }
}