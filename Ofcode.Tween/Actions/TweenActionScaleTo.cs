using UnityEngine;
using System.Collections;

namespace Ofcode.Tweens
{
	public class TweenActionScaleTo : TweenActionVector 
	{
        public TweenActionScaleTo(float x, float y, float z, float time, TweenInterpolator interpolator = null)
            : this(new Vector3(x, y, z), time, interpolator) { }

        public TweenActionScaleTo(Vector3 scale, float time, TweenInterpolator interpolator = null)
		{
			this.setTo(scale);
			this.time = time;
			this.interpolator = interpolator;
		}
	
		public override void onSetTarget()
		{
			this.setFrom(transform.localScale);
		}
	
		public override void onUpdateValue(Vector3 value)
		{
			this.transform.localScale = value;
		}
	}
}