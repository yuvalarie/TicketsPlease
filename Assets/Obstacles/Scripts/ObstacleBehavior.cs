using System;
using UnityEngine;
using DG.Tweening;
using Managers.Scripts;
using UnityEngine.Serialization;

namespace Obstacles.Scripts
{
    public class ObstacleBehavior : MonoBehaviour
    {
        [SerializeField] private float initialTravelTime = 1f;
        [SerializeField] private float speed = 6f;
        
        private Vector3 _startPosition;
        private bool _isMovingDown = false;
        private ObstaclePool _obstaclePool;
        [SerializeField] private CapsuleCollider2D capsuleCollider2D;

        public void Init(Vector3 startPos, ObstaclePool pool)
        {
            _startPosition = startPos;
            _obstaclePool = pool;
            
            capsuleCollider2D.enabled = false;
            transform.DOMove(_startPosition, initialTravelTime).SetEase(Ease.Linear).SetRecyclable();
        }

        private void OnEnable()
        {
            _isMovingDown = false;
        }
        
        private void OnDisable()
        {
            transform.DOKill();
        }

        private void Update()
        {
            
            if (Mathf.Approximately(transform.position.y, _startPosition.y)
                && Mathf.Approximately(transform.position.x, _startPosition.x)
                && !_isMovingDown)
            {
                _isMovingDown = true;
                MovingDown();
            }

            if (Mathf.Approximately(transform.position.y, -1))
            {
                GameManager.IncreaseScore();
                SelfDestroy();
            }
        }

        private void MovingDown()
        {
            capsuleCollider2D.enabled = true;
            float yPos = -1;
            float xPos = _startPosition.x;
            var targetPos = new Vector3(xPos, yPos, 0);
            float distance = Vector3.Distance(transform.position, targetPos);
            float duration = distance / speed;
            transform.DOMove(targetPos, duration).SetEase(Ease.Linear).SetRecyclable();
        }

        public void SelfDestroy()
        {
            transform.DOKill();
            _obstaclePool.ReturnToPool(gameObject);
        }
        
        
    }
}