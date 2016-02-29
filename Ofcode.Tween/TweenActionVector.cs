using UnityEngine;
using System.Collections;

namespace Ofcode.Tweens
{
	public class TweenActionVector : TweenAction 
	{
		protected Vector3 valueFrom, valueTo;        // Vector Inicial / final
        protected Vector3 valueDif;                  // Temporales para el calculo

        public void setFrom(Vector3 value) { this.valueFrom = value; }
        public void setTo(Vector3 value)   { this.valueTo   = value;  }
        
        public override void onStart() 
        {
            this.valueDif = valueTo - valueFrom;
        }
	
        public override void onUpdateTime(float t) 
        {
			Vector3 v = valueFrom + valueDif * t;
            onUpdateValue(v);
        }
       
		public virtual void onUpdateValue(Vector3 value)  {  }
	
	}
}
