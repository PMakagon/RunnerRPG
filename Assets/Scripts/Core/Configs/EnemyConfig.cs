using UnityEngine;

namespace SlimeRPG.Core.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/EnemyConfig", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private float health = 25f;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float damage = 5f;
        [SerializeField] private int reward = 2;
        [SerializeField] private float attackCoolDown = 2f;
        [SerializeField] private float attackRange = 2f;

        public float Health
        {
            get => health;
            set => health = value;
        }

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        public float Damage
        {
            get => damage;
            set => damage = value;
        }

        public int Reward
        {
            get => reward;
            set => reward = value;
        }

        public float AttackCoolDown
        {
            get => attackCoolDown;
            set => attackCoolDown = value;
        }

        public float AttackRange
        {
            get => attackRange;
            set => attackRange = value;
        }

    }
}