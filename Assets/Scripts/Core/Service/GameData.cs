using SlimeRPG.Core.Configs;
using SlimeRPG.Core.Data;
using UnityEngine;

namespace SlimeRPG.Core.Service
{
    [CreateAssetMenu(fileName = "GameData", menuName = "GameData")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private CoinsData coinsData;
        [SerializeField] private PriceData priceData;
        [SerializeField] private PlayerData playerData;

        public void ResetData()
        {
            playerConfig.ResetData();
            coinsData.ResetData();
            priceData.ResetData();
            playerData.SetData(playerConfig);
        }

        public PlayerConfig PlayerConfig => playerConfig;

        public CoinsData CoinsData => coinsData;

        public PriceData PriceData => priceData;

        public PlayerData PlayerData => playerData;
    }
}