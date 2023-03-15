using SlimeRPG.Core.SceneManagement;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Core
{
    public class AppStart : MonoBehaviour
    {
        private ISceneLoaderService _sceneLoaderService;

        [Inject]
        private void Construct(ISceneLoaderService sceneLoaderService)
        {
            _sceneLoaderService = sceneLoaderService;
        }

        private void Start()
        {
            _sceneLoaderService.LoadMainMenu();
        }
    }
}