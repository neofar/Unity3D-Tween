using UnityEngine;
using System.Collections;

namespace Ofcode.Tweens
{
	public class TweenActionRotateTo : TweenActionVector 
	{

        public TweenActionRotateTo(float x, float y, float z, float time, TweenInterpolator interpolator = null)
            : this(new Vector3(x, y, z), time, interpolator) { }

        public TweenActionRotateTo(Vector3 angle, float time, TweenInterpolator interpolator = null)
		{
			this.setTo(angle);
			this.time = time;
			this.interpolator = interpolator;
		}

		public override void onSetTarget()
		{
			this.setFrom(transform.eulerAngles);
		}

		public override void onUpdateValue(Vector3 value)
		{
			this.transform.eulerAngles = value;
		}

	}
}