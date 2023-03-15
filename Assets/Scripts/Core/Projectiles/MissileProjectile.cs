using System.Collections;
using UnityEngine;

namespace SlimeRPG.Core.Projectiles
{
    public class MissileProjectile : ProjectileBase
    {
        [SerializeField] private float _flyingTime = 5;
        [SerializeField] private float _rotateSpeed = 95;
        [SerializeField] private float _maxDistancePredict = 100;
        [SerializeField] private float _minDistancePredict = 5;
        [SerializeField] private float _maxTimePrediction = 5;
        [SerializeField] private float _deviationAmount = 50;
        [SerializeField] private float _deviationSpeed = 2;
        private Vector3 _standardPrediction, _deviatedPrediction;
        private Rigidbody _rb;
        private Vector3 _targetCachedPosition;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
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
                transform.position = MathUtils.Parabola(Origin,Target? Target.position : _targetCachedPosition,5,time);
                time += Time.deltaTime * Velocity;
                yield return null;
            }
        }

        protected override void OnAfterCollision(Collision collision)
        {
            if (collision.transform.TryGetComponent<Rigidbody>(out var rb));
            rb.AddExplosionForce(5,transform.position,2,2,ForceMode.Impulse);
            Debug.Log("EXPLODE");
        }

        public override void Shoot(Transform target, Vector3 origin, float speed)
        {
            Target = target;
            Origin = origin;
            Velocity = speed*10;
            StartCoroutine(ReachTarget());
        }

        protected override void DestroyProjectile()
        {
            StopAllCoroutines();
            base.DestroyProjectile();
        }

        private void PredictMovement(float leadTimePercentage)
        {
            var predictionTime = Mathf.Lerp(0, _maxTimePrediction, leadTimePercentage);

            _standardPrediction = Target.position * predictionTime;
        }

        private void AddDeviation(float leadTimePercentage)
        {
            var deviation = new Vector3(Mathf.Cos(Time.time * _deviationSpeed), 0, 0);

            var predictionOffset = transform.TransformDirection(deviation) * _deviationAmount * leadTimePercentage;

            _deviatedPrediction = _standardPrediction + predictionOffset;
        }

        private void RotateRocket()
        {
            var heading = _deviatedPrediction - transform.position;

            var rotation = Quaternion.LookRotation(heading);
            _rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime));
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, _standardPrediction);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_standardPrediction, _deviatedPrediction);
        }
    }
}