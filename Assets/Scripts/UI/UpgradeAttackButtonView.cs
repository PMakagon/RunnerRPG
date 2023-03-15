using EventHolders;
using SlimeRPG.Core.Configs;
using SlimeRPG.Core.Data;
using SlimeRPG.Core.Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UpgradeAttackButtonView : MonoBehaviour
    {
        [SerializeField] private StoreService storeService;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private PriceData priceData;
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private TextMeshProUGUI labelText;

        private void Awake()
        {
            priceText.text = priceData.attackSpeedUpgradePrice.ToString();
            labelText.text = playerConfig.AttackSpeed.ToString();
            StoreEventHolder.OnAttackSpeedUpgraded += UpdateButton;
        }

        private void OnDestroy()
        {
            StoreEventHolder.OnAttackSpeedUpgraded -= UpdateButton;
        }

        private void UpdateButton(float newAttackSpeed)
        {
            labelText.text = playerConfig.AttackSpeed.ToString();
            priceText.text = priceData.attackSpeedUpgradePrice.ToString();
        }
    }
}