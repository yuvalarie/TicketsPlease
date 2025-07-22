using System;
using UnityEngine;

namespace Managers.Scripts
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance {get; private set;}
        void Start()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    
        // Event to reset the game
        /**public static event EventHandler OnResetGame;  
    
        public static void ResetGame()
        {
            OnResetGame?.Invoke(null, EventArgs.Empty);
        }**/
    
        // event to update the Health
        public static event EventHandler<HealthUpdateArgs> OnHealthUpdate;
    
        public class HealthUpdateArgs : EventArgs
        {
            public int Health;
        }
    
        public static void HealthUpdate(int health)
        {
            var args = new HealthUpdateArgs {Health = health};
            OnHealthUpdate?.Invoke(null, args);
        }
    
    
        // Event to update the score
        public static event EventHandler<ScoreUpdateArgs> OnScoreUpdate;
    
        public class ScoreUpdateArgs : EventArgs
        {
            public int Score;
        }
    
        public static void ScoreUpdate(int score)
        {
            var args = new ScoreUpdateArgs {Score = score};
            OnScoreUpdate?.Invoke(null, args);
        }
    
        public static event EventHandler OnGameOver;
        
        public static void GameOver()
        {
            OnGameOver?.Invoke(null, EventArgs.Empty);
        }
    
    }
}
