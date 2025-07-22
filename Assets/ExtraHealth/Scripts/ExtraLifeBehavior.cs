using System;
using DG.Tweening;
using UnityEngine;

namespace ExtraHealth.Scripts
{
    public class ExtraLifeBehavior : MonoBehaviour
    {
        [SerializeField] private float speed = 6f;
        private void Start()
        {
            MovingDown();
        }

        private void Update()
        {
            if (Mathf.Approximately(transform.position.y, -1))
            {
                SelfDestroy();
            }
        }

        private void MovingDown()
        {
            float yPos = -2;
            float xPos = transform.position.x;
            var targetPos = new Vector3(xPos, yPos, 0);
            float distance = Vector3.Distance(transform.position, targetPos);
            float duration = distance / speed;
            transform.DOMove(targetPos, duration).SetEase(Ease.Linear);
        }

        public void SelfDestroy()
        {
            transform.DOKill();
            Destroy(gameObject);
        }
    }
}