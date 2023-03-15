using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace SlimeRPG.Core.SceneManagement
{
    public interface ISceneLoaderService
    {
        UniTask LoadSceneByName(string sceneName, LoadSceneMode loadMode);
        UniTask UnloadSceneByName(string sceneName);
        UniTask LoadMainMenu();
        UniTask UnloadMainMenu();
        UniTask LoadGame();
        UniTask UnloadGame();
    }
}