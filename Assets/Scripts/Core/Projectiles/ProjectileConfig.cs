using UnityEngine;

namespace SlimeRPG.Core.Projectiles
{
    [CreateAssetMenu(fileName = "ProjectileConfig", menuName = "Config/ProjectileConfig", order = 2)]
    public class ProjectileConfig : ScriptableObject
    {
        [SerializeField] private ProjectileBase prefab;
        [SerializeField] private string projectileName;
        [SerializeField] private ProjectileShootType shootType;
        [SerializeField] private float baseChance;
        [SerializeField] private float baseDamage;

        public ProjectileBase Prefab => prefab;

        public string ProjectileName => projectileName;

        public ProjectileShootType ShootType => shootType;

        public float BaseChance => baseChance;

        public float BaseDamage => baseDamage;
    }
}