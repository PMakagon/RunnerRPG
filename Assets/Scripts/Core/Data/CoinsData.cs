using EventHolders;
using UnityEngine;

namespace SlimeRPG.Core.Data
{
    [CreateAssetMenu(fileName = "CoinsData", menuName = "Data/CoinsData", order = 0)]
    public class CoinsData : ScriptableObject
    {
        private int _coins = 0;

        public void AddCoins(int coinsToAdd)
        {
            _coins += coinsToAdd;
            StoreEventHolder.BroadcastOnCoinsAdded(coinsToAdd);
        }
        
        public void RemoveCoins(int coinsToRemove)
        {
            _coins -= coinsToRemove;
            StoreEventHolder.BroadcastOnCoinsRemoved(coinsToRemove);
        }

        public int GetCoins()
        {
            return _coins;
        }

        public void ResetData()
        {
            _coins = 0;
        }
        
    }
}