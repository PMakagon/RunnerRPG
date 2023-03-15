using DG.Tweening;
using EventHolders;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private RectTransform btnTransform;
        [SerializeField] private Image _image;

        private void Awake()
        {
            PlayerEventHolder.OnPlayerDied += AnimateImage;
        }

        private void OnDestroy()
        {
            PlayerEventHolder.OnPlayerDied -= AnimateImage;
        }

        private void AnimateImage()
        {
            _image.color = Color.red;
            btnTransform.DOShakeScale(1);
            btnTransform.DOFlip();
        }
        
        public void RestartScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}