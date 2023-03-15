using EventHolders;
using UnityEngine;

namespace SlimeRPG.Core.Level
{
    public class LevelBlockTrigger : MonoBehaviour
    {
        private bool isTriggered;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !isTriggered)
            {
                isTriggered = true;
                LevelEventHolder.BroadcastOnLevelCenter();
                // Debug.Log("CENTER");
            }
       
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                LevelEventHolder.BroadcastOnLevelExit();
                // Debug.Log("EXIT");
            }

        }
    }
}
