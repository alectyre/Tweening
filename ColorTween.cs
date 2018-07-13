using UnityEngine;
using UnityEngine.Events;

namespace Tweening
{
    public struct ColorTween : ITween
    {
        private ColorTweenCallback _callback;
        private Color _startColor;
        private Color _targetColor;
        private ColorTweenMode _tweenMode;
        private float _duration;
        private bool _ignoreTimeScale;

        public Color startColor
        {
            get
            {
                return _startColor;
            }
            set
            {
                _startColor = value;
            }
        }

        public Color targetColor
        {
            get
            {
                return _targetColor;
            }
            set
            {
                _targetColor = value;
            }
        }

        public ColorTweenMode tweenMode
        {
            get
            {
                return _tweenMode;
            }
            set
            {
                _tweenMode = value;
            }
        }

        public float duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
            }
        }

        public bool ignoreTimeScale
        {
            get
            {
                return _ignoreTimeScale;
            }
            set
            {
                _ignoreTimeScale = value;
            }
        }

        public void TweenValue(float normalizedValue)
        {
            if(_callback != null)
            {
                Color color = Color.Lerp(_startColor, _targetColor, normalizedValue);

                if(_tweenMode == ColorTween.ColorTweenMode.Alpha)
                {
                    color.r = _startColor.r;
                    color.g = _startColor.g;
                    color.b = _startColor.b;
                }
                else if(_tweenMode == ColorTween.ColorTweenMode.RGB)
                    color.a = _startColor.a;

                _callback.Invoke(color);
            }
        }

        public void AddOnChangedCallback(UnityAction<Color> callback)
        {
            if(_callback == null)
                _callback = new ColorTween.ColorTweenCallback();

            _callback.AddListener(callback);
        }

        public enum ColorTweenMode
        {
            All,
            RGB,
            Alpha,
        }

        public class ColorTweenCallback : UnityEvent<Color>
        {
        }
    }
}
