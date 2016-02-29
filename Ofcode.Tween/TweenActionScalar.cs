using UnityEngine;
using System.Collections;

namespace Ofcode.Tweens
{
	public class TweenActionScalar : TweenAction 
	{
		private float valueFrom, valueTo;         // Value Inicial / final  
        private float valueDif;                   // Value diff

        public void setFrom(float value) { this.valueFrom = value; }
        public void setTo(float value)   { this.valueTo   = value; }
        
        public override void onStart() 
        {
            this.valueDif = valueTo - valueFrom;
        }
	
        public override void onUpdateTime(float t) 
        {
			float v = valueFrom + valueDif * t;
            onUpdateValue(v);
        }
       
        public virtual void onUpdateValue(float value)  { }
	
	}
}
