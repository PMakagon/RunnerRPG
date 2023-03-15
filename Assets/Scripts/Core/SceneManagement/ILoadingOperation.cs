using Cysharp.Threading.Tasks;

namespace SlimeRPG.Core.SceneManagement
{
    public interface ILoadingOperation
    {
        UniTask Load();
        UniTask Unload();
    }
}