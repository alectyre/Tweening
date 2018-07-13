using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tween
{
    public interface ITween
    {
        bool ignoreTimeScale { get; }

        float duration { get; }

        void TweenValue(float normalizedValue);
    }
}
