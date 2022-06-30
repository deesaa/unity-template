using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace JDS.Services.SceneLoadManager
{
    [CreateAssetMenu(menuName = "Create GameMeta", fileName = "GameMeta", order = 0)]
    public class GameMeta : ScriptableObject, IGameMeta, IInitializable
    {
        public string LevelPrefix = "Level_";
        public int UpdateVersion => 5;
        public int FirstPlaySceneIndex => 0;
        public int LoadingSceneIndex => SceneUtility.GetBuildIndexByScenePath("Assets/_Main/Scenes/LoadingScene.unity");
        public bool IsLevelSceneExists(int sceneIndex)
        {
            int index = SceneUtility.GetBuildIndexByScenePath($"Assets/_Main/Scenes/{LevelPrefix}{sceneIndex}.unity");
            if (index < 0)
                return false;
            return true;
        }
        public int LevelScenesCount => _levelScenesCount;
        public int GetBuildIndexByMapIndex(int mapIndex) =>
            SceneUtility.GetBuildIndexByScenePath($"Assets/_Main/Scenes/{LevelPrefix}{mapIndex}.unity");

        private int _levelScenesCount = -1;
        public void Initialize()
        {
            int index = 0;
            if (!IsLevelSceneExists(index))
            {
                _levelScenesCount = -1;
                return;
            }
            index++;
            while (IsLevelSceneExists(index))
            {
                index++;
                
                if(index > 10000)
                    break;
            }
            _levelScenesCount = index;
        }
    }
}