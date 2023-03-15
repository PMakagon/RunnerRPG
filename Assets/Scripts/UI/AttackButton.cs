using SlimeRPG.Core.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SlimeRPG.UI
{
    public class AttackButton : MonoBehaviour
    {
        private PlayerController _playerController;
        
        [Inject]
        private void Construct(PlayerController player)
        {
            _playerController = player;
        }

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(_playerController.Attack);
        }
    }
}