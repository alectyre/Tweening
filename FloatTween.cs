using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Tween
{
    internal struct FloatTween : ITween
    {
        private System.Action<float> _callback;
        private float _startValue;
        private float _targetValue;
        private float _duration;
        private bool _ignoreTimeScale;



        #region Public properties

        public float startValue
        {
            get
            {
                return _startValue;
            }
            set
            {
                _startValue = value;
            }
        }

        public float targetValue
        {
            get
            {
                return _targetValue;
            }
            set
            {
                _targetValue = value;
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

        #endregion




        public void TweenValue(float normalizedValue)
        {
            if (_callback != null)
                _callback.Invoke(Mathf.Lerp(_startValue, _targetValue, normalizedValue));
        }

        public void AddOnChangedCallback(System.Action<float> callback)
        {
            _callback = callback;
        }
    }
}
