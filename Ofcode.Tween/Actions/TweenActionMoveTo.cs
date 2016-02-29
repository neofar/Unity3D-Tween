using UnityEngine;
using System.Collections;

namespace Ofcode.Tweens
{
	public class TweenActionMoveTo : TweenActionVector 
	{

        public TweenActionMoveTo(float x, float y, float z, float time, TweenInterpolator interpolator = null)
            : this(new Vector3(x, y, z), time, interpolator) {  }

        public TweenActionMoveTo(Vector3 position, float time, TweenInterpolator interpolator = null)
		{
            this.setTo(position);
            this.time = time;
			this.interpolator = interpolator;
		}
	
		public override void onSetTarget()
		{
			this.setFrom(transform.localPosition);
    	}
    
		public override void onUpdateValue(Vector3 value)
		{
			this.transform.localPosition = value;
		}
	
	}
}