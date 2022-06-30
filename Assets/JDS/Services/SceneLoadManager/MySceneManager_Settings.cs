using UnityEngine;

namespace JDS.Services.SceneLoadManager
{
    [CreateAssetMenu(menuName = "Create MySceneManager Settings", fileName = "MySceneManager Settings", order = 0)]
    public class MySceneManager_Settings : ScriptableObject
    {
        public SplashFaderView SplashFaderViewPrefab;
        public float FadeInDuration = 2f;
        public float FadeOutDuration = 2f;
        public float FinalWaitDuration = 1f;
    }
}