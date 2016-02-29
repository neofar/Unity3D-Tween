using UnityEngine;
using System.Collections;

namespace Ofcode.Tweens
{
	public class TweenActionFadeTo : TweenActionScalar 
	{
		private Renderer renderer;
        private Color color;
	
		public TweenActionFadeTo(float alpha, float time, TweenInterpolator interpolator)
		{
			this.setTo(alpha);
			this.time = time;
			this.interpolator = interpolator;
		}
	
		public override void onSetTarget()
		{
			this.renderer = gameObject.GetComponent<Renderer>();
            this.color = renderer.material.color;
            this.setFrom(color.a);
		}
	
		public virtual void onUpdateValue(float value)  
		{
			color.a = value;
			renderer.material.color = color;
		}
	}
}