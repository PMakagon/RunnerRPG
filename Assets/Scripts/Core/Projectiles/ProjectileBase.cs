using SlimeRPG.Core.Enemies;
using UnityEngine;

namespace SlimeRPG.Core.Projectiles
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        public Transform Target { get; set; }
        public Vector3 Origin { get; set; }
        public float Velocity { get; set; }
        public float FinalDamage { get; set; }
        

        private void OnCollisionEnter(Collision collision)
        {
            if (CheckEnemyCollision(collision))
            {
                OnAfterCollision(collision);
            }
            DestroyProjectile();
        }

        public virtual void Shoot(Transform target,Vector3 origin,float speed)
        {
            Target = target;
            Origin = origin;
            Velocity = speed;
        }

        protected virtual bool CheckEnemyCollision(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                var enemy = collision.gameObject.GetComponent<Enemy>();
                TryDamageEnemy(enemy);
                return true;
            }
            return false;
        }

        protected virtual void TryDamageEnemy(Enemy enemy)
        {
            if (!enemy.IsDead)
            {
                enemy.TakeDamage(FinalDamage);
            }
        }
        
        protected virtual void OnAfterCollision(Collision collision)
        {
            
        }

        protected virtual void DestroyProjectile()
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
        
    }

    
}