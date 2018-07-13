using UnityEngine;

namespace Tween
{
    public class Vector3Tween : ITween {

    	
        private System.Action<Vector3> _callback;
        private Vector3 _startValue;
        private Vector3 _targetValue;
        private float _duration;
        private bool _ignoreTimeScale;


    	
        #region Public properties

        public Vector3 startValue
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

        public Vector3 targetValue
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
                _callback.Invoke(Vector3.Lerp(_startValue, _targetValue, normalizedValue));
        }

        public void AddOnChangedCallback(System.Action<Vector3> callback)
        {
            _callback = callback;
        }
    }
}
