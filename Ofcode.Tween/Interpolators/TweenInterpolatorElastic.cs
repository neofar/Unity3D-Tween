using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ofcode.Tweens
{

    public class TweenInterpolatorElastic : TweenInterpolator 
    {
        private static float M_PI_X_2 = (float)Mathf.PI * 2.0f;
        private float period, s;
    
        public TweenInterpolatorElastic() : this(TweenDirection.Out, 0.25f) { }
        public TweenInterpolatorElastic(TweenDirection direction, float periodo)
        {
            this.direction = direction;
            this.period = periodo;
            this.s = period / 4;
        }
    
        public override float getInterpolation(float input)
        {
            if (input == 0 || input == 1) return input;
    
            if (direction == TweenDirection.In)
            {
                input = input - 1;
                return -(float)Mathf.Pow(2, 10 * input) * (float)Mathf.Sin((input - s) * M_PI_X_2 / period);
            }
            else if (direction == TweenDirection.Out)
            {
                return (float)Mathf.Pow(2, -10 * input) * (float)Mathf.Sin((input - s) * M_PI_X_2 / period) + 1;
            }
            else if (direction == TweenDirection.InOut)
            {
                input = input * 2.0f;
                if (period == 0) period = 0.3f * 1.5f;
    
                input = input - 1;
                if (input < 0)
                    return (float)(-0.5f * (float)Mathf.Pow(2, 10 * input) * (float)Mathf.Sin((input - s) * M_PI_X_2 / period));
                else
                    return (float)((float)Mathf.Pow(2, -10 * input) * (float)Mathf.Sin((input - s) * M_PI_X_2 / period) * 0.5f + 1.0f);
    
            }
            return input;
        }
    
    
    }
}