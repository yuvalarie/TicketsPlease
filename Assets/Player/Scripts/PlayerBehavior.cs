using System;
using ExtraHealth.Scripts;
using Managers.Scripts;
using Obstacles.Scripts;
using UnityEngine;

namespace Player.Scripts
{
    public class PlayerBehavior : MonoBehaviour
    {
        private const float LeftBound = -3;
        private const float RightBound = 3;
        [SerializeField] private int health = 3;

        private void Reset(object sender, EventArgs e)
        {
            health = 3;
            transform.position = new Vector3(0, 0, 0);
        }
        
        private void Update()
        {
            ManageMovement();
        }
        
        private void ManageMovement()
        {
            var xPos = transform.position.x;
            var yPos = transform.position.y;
            
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft(xPos, yPos);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight(xPos, yPos);
            }
        }
        
        private void MoveLeft(float xPos,float yPos)
        {
            var targetX = Math.Max(xPos - 3, LeftBound);
            transform.position = new Vector3(targetX, yPos, 0);
        }
        
        private void MoveRight(float xPos,float yPos)
        {
            var targetX = Math.Min(xPos + 3, RightBound);
            transform.position = new Vector3(targetX, yPos, 0);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.TryGetComponent<ObstacleBehavior>(out var obstacle))
            {
                health--;
                obstacle.SelfDestroy();
                EventManager.HealthUpdate(health);
            }
            
            if (health <= 0)
            {
                Debug.Log("Game Over");
                EventManager.GameOver();
            }

            if (other.TryGetComponent<ExtraLifeBehavior>(out var extraLife))
            {
                health++;
                EventManager.HealthUpdate(health);
                extraLife.SelfDestroy();
            }
        }
    }
}