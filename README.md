# Tweening
Some simple tweening functions for Unity, based on internal Unity methods.

'''C#
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Example : MonoBehaviour {

    public UnityEvent onShow;
    public UnityEvent onClose;

    CanvasGroup _canvasGroup;
    TweenRunner _alphaTweenRunner;

    const float FadeTime = 0.2f;

    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _alphaTweenRunner = new TweenRunner(this);
    }

    public void Show()
    {
        FloatTween alphaTween = new FloatTween(){ 
            startValue = 0, targetValue = 1,
            duration = DialogueFadeTime, ignoreTimeScale = true };

        alphaTween.AddOnChangedCallback((alpha) =>
            {
                _canvasGroup.alpha = alpha;

                if(alpha == 1 && onShow != null)
                    onShow.Invoke();
            });

        _alphaTweenRunner.RunTween(alphaTween);
    }

    public void Close()
    {
        FloatTween alphaTween = new FloatTween(){ 
            startValue = 1, targetValue = 0,
            duration = DialogueFadeTime, ignoreTimeScale = true };

        alphaTween.AddOnChangedCallback((alpha) =>
            {
                _canvasGroup.alpha = alpha;

                if(alpha == 0 && onShow != null)
                    onShow.Invoke();
            });

        _alphaTweenRunner.RunTween(alphaTween);
    }
}
'''
