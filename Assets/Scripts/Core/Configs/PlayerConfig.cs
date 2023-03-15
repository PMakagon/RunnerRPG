using UnityEngine;

namespace SlimeRPG.Core.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/PlayerConfig", order = 1)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float health = 100f;
        [SerializeField] private float damage = 5f;
        [SerializeField] private float attackSpeed = 1;
        [SerializeField] private float moveSpeed = 0.1f;

        public float Health
        {
            get => health;
            set => health = value;
        }

        public float Damage
        {
            get => damage;
            set => damage = value;
        }

        public float AttackSpeed
        {
            get => attackSpeed;
            set => attackSpeed = value;
        }

        public float MoveSpeed
        {
            get => moveSpeed;
            set => moveSpeed = value;
        }

        private void OnEnable()
        {
            ResetData();
        }

        public void ResetData()
        {
            health = 100f;
            damage = 5f;
            attackSpeed = 1f;
            moveSpeed = 0.1f;
        }
    }
}