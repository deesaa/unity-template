using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace JDS.Values
{
    public class TestBeh : MonoBehaviour, IPointerDownHandler
    {
        public TMP_Text Text;
       // public EasedFloat Coins;
        private float timer = 0;
        
        private void Awake()
        {
         //   Coins.SetEase(EaseFunc.Get(Ease.InQuad)).Subscribe(x => Text.text = x.ToString()).AddTo(gameObject);
        }

        public void SetCoinsCount(float coinsCount)
        {
        //    Coins.TargetValue = coinsCount;
        }

        private void Update()
        {
            timer += Time.deltaTime;
            Text.text = timer.ToString();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
          //  Coins.TargetValue += 55;
        }
    }
}