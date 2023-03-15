using System;

namespace EventHolders
{
    public static class LevelEventHolder
    {
        public static event Action OnNewBlockSpawn;
        public static event Action OnNewBlockReady;
        public static event Action OnBlockDestroyed;
        public static event Action OnLevelEnter;
        public static event Action OnLevelCenter;
        public static event Action OnLevelExit;

        public static void BroadcastOnNewBlockSpawn()
        {
            OnNewBlockSpawn?.Invoke();
        }
        public static void BroadcastOnNewBlockReady()
        {
            OnNewBlockReady?.Invoke();
        }
        public static void BroadcastOnBlockDestroyed()
        {
            OnBlockDestroyed?.Invoke();
        }
        public static void BroadcastOnLevelEnter()
        {
            OnLevelEnter?.Invoke();
        }
        public static void BroadcastOnLevelExit()
        {
            OnLevelExit?.Invoke();
        }
        public static void BroadcastOnLevelCenter()
        {
            OnLevelCenter?.Invoke();
        }
    }
}