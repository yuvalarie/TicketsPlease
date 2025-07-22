using UnityEngine;
using UnityEngine.UI;

namespace Managers.Scripts
{
    public class PlayButtonHandler : MonoBehaviour
    {
        private void Start()
        {
            Button button = GetComponent<Button>();
            if (button != null)
            {
                button.onClick.RemoveAllListeners(); // Clean any old ones
                button.onClick.AddListener(() =>
                {
                    GameSceneManager.Instance.LoadGameScene();
                });
            }
        }
    }
}