using EventHolders;
using SlimeRPG.Core.Data;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CoinBar : MonoBehaviour
    {
        [SerializeField] private CoinsData coinsData;
        [SerializeField] private TextMeshProUGUI coinsValue;

        private void Awake()
        {
            StoreEventHolder.OnCoinsAdded += UpdateTextValue;
            StoreEventHolder.OnCoinsRemoved += UpdateTextValue;
        }

        private void OnDestroy()
        {
            StoreEventHolder.OnCoinsAdded -= UpdateTextValue;
            StoreEventHolder.OnCoinsRemoved -= UpdateTextValue;
        }

        private void UpdateTextValue(int newCoinsValue)
        {
            coinsValue.text = coinsData.GetCoins().ToString();
        }

        private void SpawnValueTextMeshGhost()
        {
            var ghost = Instantiate(gameObject, transform.position, Quaternion.identity, transform);
            
        }
    }
}