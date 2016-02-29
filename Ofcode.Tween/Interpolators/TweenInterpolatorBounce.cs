using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ofcode.Tweens
{

	public class TweenInterpolatorBounce : TweenInterpolator
	{
		public TweenInterpolatorBounce() : this(TweenDirection.Out)  { }
		public TweenInterpolatorBounce(TweenDirection direction)
		{
			this.direction = direction;
		}
	
		protected float bounceTime(float t)
		{
			if (t < 1.0f / 2.75f)
			{
				return 7.5625f * t * t;
			}
			else if (t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return 7.5625f * t * t + 0.75f;
			}
			else if (t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return 7.5625f * t * t + 0.9375f;
			}
	
			t -= 2.625f / 2.75f;
			return 7.5625f * t * t + 0.984375f;
		}	
	
		public override float getInterpolation(float input)
		{
			if (direction == TweenDirection.In)
			{
				return 1 - bounceTime(1 - input);
			}
			else if (direction == TweenDirection.Out)
			{
				return bounceTime(input);
			}
			else if (direction == TweenDirection.InOut)
			{
				if (input < 0.5f)
				{
					input = input * 2.0f;
					return (float)((1.0f - this.bounceTime(1 - input)) * 0.5f);
				}
				else
					return (float)(this.bounceTime(input * 2.0f - 1.0f) * 0.5f + 0.5f);
			}
	
			return input;
		}
	
	
	}
}