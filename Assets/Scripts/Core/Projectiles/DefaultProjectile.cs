using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SlimeRPG.Core.Projectiles
{
    public class DefaultProjectile : ProjectileBase
    {
        [SerializeField] private float angle = 5f;
        private Vector3 _targetCachedPosition;

        public override void Shoot(Transform target,Vector3 origin,float speed)
        {
            Target = target;
            Origin = origin;
            Velocity = speed;
            _targetCachedPosition = target.position;
            StartCoroutine(ReachTarget());
        }

        private async UniTask ReachTargetAsync()
        {
            float time = 0;
            while (time < 1)
            {
                if (Target!=null)
                {
                    _targetCachedPosition = Target.position;
                }
                transform.position = MathUtils.Parabola(Origin,Target? Target.position : _targetCachedPosition,angle,time);
                time += Time.deltaTime * Velocity;
                await UniTask.NextFrame();
            }
        }
        private IEnumerator ReachTarget()
        {
            float time = 0;
            while (time < 1)
            {
                if (Target!=null)
                {
                    _targetCachedPosition = Target.position;
                }
                transform.position = MathUtils.Parabola(Origin,Target? Target.position : _targetCachedPosition,angle,time);
                time += Time.deltaTime * Velocity;
                yield return null;
            }
        }

    }
}