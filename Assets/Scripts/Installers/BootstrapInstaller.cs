using SlimeRPG.Core.SceneManagement;
using SlimeRPG.Core.Service;
using UnityEngine;
using Zenject;

namespace SlimeRPG.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private GameData gameData;
        
        public override void InstallBindings()
        {
            BindSceneLoader();
            BindGameData();
        }

        private void BindGameData()
        {
            gameData.ResetData();//костыль
            Container.Bind<GameData>().FromInstance(gameData).AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ISceneLoaderService>().To<SceneLoaderService>().FromNew().AsSingle();
        }
    }
}