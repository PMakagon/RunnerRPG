using EventHolders;
using UnityEngine;

namespace SlimeRPG.Core.Level
{
    public class LevelStartTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                LevelEventHolder.BroadcastOnLevelEnter();
                // Debug.Log("ENTER");
            }
        }
    }
}