namespace JDS.Services.SceneLoadManager
{
    public interface IGameMeta
    {
        public int UpdateVersion { get; }

        public int FirstPlaySceneIndex { get; }
        public int LoadingSceneIndex { get; }

        public bool IsLevelSceneExists(int sceneIndex);
        
        public int LevelScenesCount { get; }
        public int GetBuildIndexByMapIndex(int mapIndex);
    }
}