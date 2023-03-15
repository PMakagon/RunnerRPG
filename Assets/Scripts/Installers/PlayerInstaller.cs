using SlimeRPG.Core.Player;
using UnityEngine;
using Zenject;

namespace LiftGame.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private PlayerController playerPrefab;

        public override void InstallBindings()
        {
            BindPlayer();
        }

        private void BindPlayer()
        {
            PlayerController player =
                Container.InstantiatePrefabForComponent<PlayerController>(playerPrefab, spawnPoint.position, Quaternion.identity,
                    null);
            Container.Bind<PlayerController>().FromInstance(player).AsSingle();
        }
    }
}