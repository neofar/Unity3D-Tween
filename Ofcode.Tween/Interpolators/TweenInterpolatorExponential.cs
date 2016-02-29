using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ofcode.Tweens
{
    public class TweenInterpolatorExponential : TweenInterpolator 
    {
        float value, power, min, scale;
        
        public TweenInterpolatorExponential() : this(TweenDirection.Out, 2, 10)  { }
        public TweenInterpolatorExponential(TweenDirection direction): this(direction, 2, 10)  { }
        public TweenInterpolatorExponential(TweenDirection direction, float value, float power)
        {
            this.direction = direction;
        
            this.value = value;
			this.power = power;
			this.min   = Mathf.Pow(value, -power);
			this.scale = 1.0f / (1.0f - min);
        }
        
        
        public override float getInterpolation(float input)
        {
            if (direction == TweenDirection.In)
            {
                return (Mathf.Pow(value, power * (input - 1.0f)) - min) * scale;
            }
            else if (direction == TweenDirection.Out)
            {
                return 1.0f - (Mathf.Pow(value, -power * input) - min) * scale;
            }
            else if (direction == TweenDirection.InOut)
            {
                if (input <= 0.5f)
                    return (Mathf.Pow(value, power * (input * 2.0f - 1.0f)) - min) * scale / 2.0f;
                else
                    return (2.0f - (Mathf.Pow(value, -power * (input * 2.0f - 1.0f)) - min) * scale) / 2.0f;
            }
            return input;
        }
   }
}