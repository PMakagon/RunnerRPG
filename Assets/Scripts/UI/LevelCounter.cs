using System.Collections;
using DG.Tweening;
using EventHolders;
using SlimeRPG.Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LevelCounter : MonoBehaviour
    {
        [SerializeField] private LevelBuilder levelBuilder;
        [SerializeField] private RectTransform counterPanel;
        [SerializeField] private RectTransform counterTextTransform;
        [SerializeField] private TextMeshProUGUI counterText;
        private Vector3 _startPosition;

        private void Awake()
        {
            _startPosition = counterTextTransform.position;
            LevelEventHolder.OnLevelEnter += ShowCounter;
        }

        private void OnDestroy()
        {
            LevelEventHolder.OnLevelEnter -= ShowCounter;
        }

        private void ShowCounter()
        {
            counterText.text = levelBuilder.LevelNumber.ToString();
            counterPanel.gameObject.SetActive(true);
            counterTextTransform.transform.DOMoveX(100, 1).SetEase(Ease.InElastic).OnComplete(() =>
            {
                StartCoroutine(nameof(FadeoutCounter));
            });
            
        }

        private IEnumerator FadeoutCounter()
        {
            yield return new WaitForSeconds(0.01f);
            counterTextTransform.DOShakeRotation(1, Vector3.forward);
            counterPanel.gameObject.SetActive(false);
            counterTextTransform.transform.position = _startPosition;
            
        }
    }
}