using System;

namespace EventHolders
{
    public static class StoreEventHolder
    {
        public static event Action<int> OnCoinsAdded;
        public static event Action<int> OnCoinsRemoved;
        public static event Action<float> OnHealthUpgraded;
        public static event Action<float> OnDamageUpgraded;
        public static event Action<float> OnAttackSpeedUpgraded;

        public static void BroadcastOnCoinsAdded(int coinsAdded)
        {
            OnCoinsAdded?.Invoke(coinsAdded);
        } 
        public static void BroadcastOnCoinsRemoved(int coinsRemoved)
        {
            OnCoinsRemoved?.Invoke(coinsRemoved);
            
        }
        public static void BroadcastOnHealthUpgraded(float newHealth)
        {
            OnHealthUpgraded?.Invoke(newHealth);
            
        }
        
        public static void BroadcastOnDamageUpgraded(float newDamage)
        {
            OnDamageUpgraded?.Invoke(newDamage);
            
        }
        
        public static void BroadcastOnAttackSpeedUpgraded(float newAttackSpeed)
        {
            OnAttackSpeedUpgraded?.Invoke(newAttackSpeed);
            
        }
        
    }
}