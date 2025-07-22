using TMPro;
using UnityEngine;

namespace Managers.Scripts
{
    public class FinalScreenUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI finalScoreText;

        void Start()
        {
            finalScoreText.text = $"{GameManager.FinalScore}";
        }
    }
}