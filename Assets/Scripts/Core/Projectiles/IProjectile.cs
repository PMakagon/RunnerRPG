using SlimeRPG.Core.Enemies;
using UnityEngine;

namespace SlimeRPG.Core.Projectiles
{
    public interface IProjectile
    {
        Transform Target { get; set; }
        Vector3 Origin { get; set; }
        float Velocity { get; set; }
        float FinalDamage { get; set; }


        bool CheckEnemyCollision(Collision collision);
        void OnAfterCollision(Collision collision);
        void Shoot(Transform target, Vector3 origin);
        void TryDamageEnemy(Enemy enemy);
        void DestroyProjectile();
    }
}