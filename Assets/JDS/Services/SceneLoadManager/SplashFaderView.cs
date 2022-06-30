using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace JDS.Services.SceneLoadManager
{
    public class SplashFaderView : MonoBehaviour
    {
        public Image Image;
        public void FadeIn(float duration, Action OnComplete)
        {
            Image.DOFade(1f, duration).SetTarget(gameObject).OnComplete(() => OnComplete());
        }

        public void FadeOut(float duration, Action OnComplete)
        {
            DOTween.Kill(gameObject);
            Image.DOFade(0f, duration).SetTarget(gameObject).OnComplete(() => OnComplete());;
        }
    }
}