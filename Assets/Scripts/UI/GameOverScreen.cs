using EventHolders;
using UnityEngine;

namespace UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private GameObject screen;


        private void Awake()
        {
            PlayerEventHolder.OnPlayerDied += ShowScreen;
        }

        private void OnDestroy()
        {
            PlayerEventHolder.OnPlayerDied -= ShowScreen;
        }

        private void ShowScreen()
        {
            screen.SetActive(true);
        }
    }
}