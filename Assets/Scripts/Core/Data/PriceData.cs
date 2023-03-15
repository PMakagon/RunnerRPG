using UnityEngine;

namespace SlimeRPG.Core.Data
{
    [CreateAssetMenu(fileName = "PriceData", menuName = "Data/PriceData", order = 1)]
    public class PriceData : ScriptableObject
    {
        public float healthUpgradePrice = 10;
        public float damageUpgradePrice = 10;
        public float attackSpeedUpgradePrice = 10;

        public void ResetData()
        {
            healthUpgradePrice = 10;
            damageUpgradePrice = 10;
            attackSpeedUpgradePrice = 10;
        }
        
    }
}