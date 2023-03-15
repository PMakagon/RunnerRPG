using EventHolders;
using SlimeRPG.Core.Configs;
using SlimeRPG.Core.Data;
using SlimeRPG.Core.Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UpgradeDamageButtonView : MonoBehaviour
    {
        [SerializeField] private StoreService storeService;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private PriceData priceData;
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private TextMeshProUGUI labelText;

        private void Awake()
        {
            priceText.text = priceData.damageUpgradePrice.ToString();
            labelText.text = playerConfig.Damage.ToString();
            StoreEventHolder.OnDamageUpgraded += UpdateButton;
        }

        private void OnDestroy()
        {
            StoreEventHolder.OnDamageUpgraded -= UpdateButton;
        }

        private void UpdateButton(float newDamage)
        {
            labelText.text = playerConfig.Damage.ToString();
            priceText.text = priceData.damageUpgradePrice.ToString();
        }
    }
}