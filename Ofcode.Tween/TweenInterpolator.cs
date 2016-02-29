using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ofcode.Tweens
{

    public class TweenInterpolator : System.Object 
    {
        public enum TweenDirection { In, Out, InOut  }
        protected TweenDirection direction = TweenDirection.Out;
    
        public virtual float getInterpolation(float input)
        {
            return input;
        }
    }
}