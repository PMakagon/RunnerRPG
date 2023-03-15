using System;

namespace EventHolders
{
    public static class PlayerEventHolder
    {
        public static event Action<float> OnDamageTaken;
        public static event Action OnPlayerDied;

        public static void BroadcastOnDamageTaken(float damage)
        {
            OnDamageTaken?.Invoke(damage);
        } 
        public static void BroadcastOnPlayerDied()
        {
            OnPlayerDied?.Invoke();
            // Debug.Log("PLAYER IS DEAD");
        }
        
    }
}