using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.Scripts
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Image[] strikeImages;

        [SerializeField] private Sprite offSprite;
        [SerializeField] private Sprite onSprite;
        //[SerializeField] private TextMeshProUGUI healthText;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            scoreText.text = "0";
            foreach (var img in strikeImages)
            {
                img.sprite = offSprite;
            }
        }

        private void OnEnable()
        {
            EventManager.OnHealthUpdate += HealthUpdate;
            //EventManager.OnResetGame += ResetUI;
            EventManager.OnScoreUpdate += ScoreUpdate;
        }

        private void OnDisable()
        {
            EventManager.OnHealthUpdate -= HealthUpdate;
            //EventManager.OnResetGame -= ResetUI;
            EventManager.OnScoreUpdate -= ScoreUpdate;
        }

        private void ScoreUpdate(object sender, EventArgs e)
        {
            if (e == null)
            {
                return;
            }
            var args = e as EventManager.ScoreUpdateArgs;
            scoreText.text = $"{args.Score}";
        }

        private void HealthUpdate(object sender, EventArgs e)
        {
            if (e == null)
            {
                return;
            }
            var args = e as EventManager.HealthUpdateArgs;
            for (int i = 0; i < strikeImages.Length; i++)
            {
                strikeImages[i].sprite = i < (3 - args.Health) ? onSprite : offSprite;
            }
        }

        public static UIManager Instance {get; private set;}
    }
}
