using System;
using UnityEngine;

namespace Managers.Scripts
{
    public class GameSceneManager : MonoBehaviour
    {
        public static GameSceneManager Instance {get; private set;}
        void Awake()
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

        private void OnEnable()
        {
            EventManager.OnGameOver += GameOver;
        }

        private void OnDisable()
        {
            EventManager.OnGameOver -= GameOver;
        }

        public void LoadScene(SceneFactory.Scene scene)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneFactory.LoadScene(scene));
        }
        
        public void LoadGameScene()
        {
            LoadScene(SceneFactory.Scene.GameScene);
        }
        
        public void ResetGameButton()
        {
            LoadScene(SceneFactory.Scene.OpeningScene);
        }
        
        public void GameOver(object sender, EventArgs e)
        {
            GameManager.SetFinalScore();
            LoadScene(SceneFactory.Scene.GameOverScene);
        }
    }
}