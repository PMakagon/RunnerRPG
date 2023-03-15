using UnityEngine;
using Zenject;

namespace SlimeRPG.Core.Pause
{
    // удалить когда получится отвязаться от юнити евентов
    public class PauseMonoRegister : MonoBehaviour
    {
        private IPauseHandler _pauseHandler;

        // MonoBehaviour injection
        [Inject]
        private void Construct(IPauseHandler pauseHandler)
        {
            _pauseHandler = pauseHandler;
        }

        private void Start()
        {
            RegisterServices();
        }

        private void OnDestroy()
        {
            UnregisterServices();
        }

        private void RegisterServices()
        {
           
        }

        private void UnregisterServices()
        {
            
        }
    }
}