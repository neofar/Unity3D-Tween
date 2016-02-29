using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ofcode.Tweens
{
    public class TweenInterpolatorPow : TweenInterpolator 
    {
        private int power;
        
        public TweenInterpolatorPow() : this(TweenDirection.Out, 2) { } 
        public TweenInterpolatorPow(TweenDirection direction) : this(direction, 2) { }
        public TweenInterpolatorPow(TweenDirection direction, int power)
        {
            this.direction = direction;
			this.power = power;
        }
        
        public override float getInterpolation(float input)
        {
            if (direction == TweenDirection.In)
            {
                return (float) Mathf.Pow(input, power);
            }
            else if (direction == TweenDirection.Out)
            {
                return (float) Mathf.Pow(input - 1, power) * (power % 2 == 0 ? -1 : 1) + 1;
            }
            else if (direction == TweenDirection.InOut)
            {
                if (input <= 0.5f) 
                    return (float) Mathf.Pow(input * 2, power) / 2;
                else    
                    return (float) Mathf.Pow((input - 1) * 2, power) / (power % 2 == 0 ? -2 : 2) + 1;            
            }

            return input;
        }
   }
}