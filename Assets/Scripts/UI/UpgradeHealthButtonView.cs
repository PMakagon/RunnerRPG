using EventHolders;
using SlimeRPG.Core.Configs;
using SlimeRPG.Core.Data;
using SlimeRPG.Core.Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UpgradeHealthButtonView : MonoBehaviour
    {
        [SerializeField] private StoreService storeService;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private PriceData priceData;
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private TextMeshProUGUI labelText;

        private void Awake()
        {
            priceText.text = priceData.healthUpgradePrice.ToString();
            labelText.text = ((int)playerConfig.Health).ToString();
            StoreEventHolder.OnHealthUpgraded += UpdateButton;
        }

        private void OnDestroy()
        {
            StoreEventHolder.OnHealthUpgraded -= UpdateButton;
        }

        private void UpdateButton(float newHealth)
        {
            labelText.text = ((int)playerConfig.Health).ToString();
            priceText.text = priceData.healthUpgradePrice.ToString();
        }
    }
}