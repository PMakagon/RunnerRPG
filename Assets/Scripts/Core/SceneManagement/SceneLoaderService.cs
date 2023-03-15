using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace SlimeRPG.Core.SceneManagement
{
    public class SceneLoaderService :  ISceneLoaderService
    {
        
        public async UniTask LoadSceneByName(string sceneName,LoadSceneMode loadMode)
        {
            var loading = SceneManager.LoadSceneAsync(sceneName, 
                loadMode);
            while (loading.isDone == false)
            {
                await UniTask.Delay(1);
            }
        }
        public async UniTask UnloadSceneByName(string sceneName)
        {
            var sceneToRemove = SceneManager.GetSceneByName(sceneName);
            var loading = SceneManager.UnloadSceneAsync(sceneToRemove);
            while (loading.isDone == false)
            {
                await UniTask.Delay(1);
            }
        }
        
        public async UniTask LoadMainMenu()
        {
            var operation = new MenuLoadingOperation();
            await operation.Load();
        }

        public async UniTask UnloadMainMenu()
        {
            var operation = new MenuLoadingOperation();
            await operation.Unload();
        }

        public async UniTask LoadGame()
        {
            var operations = new Queue<ILoadingOperation>();
            operations.Enqueue(new NewGameLoadingOperation());
            foreach (var operation in operations)
            {
               await operation.Load();
            }
        }

        public async UniTask UnloadGame()
        {
            var operations = new Queue<ILoadingOperation>();
            operations.Enqueue(new NewGameLoadingOperation());
            foreach (var operation in operations)
            {
                await operation.Unload();
            }
        }
    }
    
}