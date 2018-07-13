using System.Collections;
using UnityEngine;

namespace Tween
{
    public class TweenRunner
    {
        protected MonoBehaviour coroutineContainer;
        public bool allowMultipleTweens;

        protected Coroutine _tweenCoroutine;

        public TweenRunner(MonoBehaviour coroutineContainer)
        {
            this.coroutineContainer = coroutineContainer;

            if (coroutineContainer == null)
                UnityEngine.Debug.LogWarning((object) "Coroutine container cannot be null. A Monobehaviour must be provided");
        }

        public Coroutine RunTween(ITween tween)
        {
            if(!allowMultipleTweens && _tweenCoroutine != null)
                coroutineContainer.StopCoroutine(_tweenCoroutine);

            if(!coroutineContainer.gameObject.activeInHierarchy)
            {
                tween.TweenValue(1f);
                _tweenCoroutine = null;
            }
            else
            {
                _tweenCoroutine = coroutineContainer.StartCoroutine(Run(tween));
            }

            return _tweenCoroutine;
        }

        IEnumerator Run(ITween tween) 
        {
            float elapsedTime = 0;

            while(elapsedTime < tween.duration)
            {
                elapsedTime += tween.ignoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime;
                tween.TweenValue(Mathf.InverseLerp(0, tween.duration, elapsedTime));
                yield return null;
            }
        }
    }
}