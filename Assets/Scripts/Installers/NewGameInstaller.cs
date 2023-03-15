using SlimeRPG.Core.Pause;
using Zenject;

namespace SlimeRPG.Installers
{
    public class NewGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPauseHandler();
        }
        
        private void BindPauseHandler()
        {
            Container.Bind<IPauseHandler>().To<PauseHandler>().FromNew().AsSingle();
        }
    }
}