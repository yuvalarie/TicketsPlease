using UnityEngine;

namespace Managers.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private int _score;
        public static int FinalScore { get; private set; }

    
        public static GameManager Instance {get; private set;}
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

        public static void IncreaseScore()
        {
            Instance._score++;
            EventManager.ScoreUpdate(Instance._score);
        }
        
        public static void SetFinalScore()
        {
            FinalScore = Instance._score;
        }
    }
}
