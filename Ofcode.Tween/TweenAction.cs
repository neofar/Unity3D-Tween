using UnityEngine;
using System.Collections;

namespace Ofcode.Tweens
{
	public class TweenAction : System.Object 
	{
        protected float time;
        protected TweenInterpolator interpolator = null;
        private float startTime, factorTime;
        
        private bool delayEnabled = false;
		private float delayTime   = 0.0f;
		
	
		public void start()
		{
			// añade la accion a la pila de tweens 
			Tween.Add(this);
	
			// Inicializamos las variables de tiempo
			startTime  = Time.time;
			factorTime = 1.0f / time;
			
            // evento que ya se ha iniciado
            isFinished = false;
			onStart();
		}
        
		public virtual void onStart() { }
	
		public void end()
		{
			execComplete();
			onEnd();
		}
		
        public virtual void onEnd() { }

        public TweenAction setDelay(float time)
        {
            delayEnabled = true;
            delayTime = time;
            return this;
        }

        public float getDelay() { return delayTime; }
        public float getDuration() { return time; }


        public bool isFinished { get; private set; }

        #region Targets
        // Target / GameObject o Transform
        protected GameObject gameObject;
        protected Transform transform;

        public void setTarget(UnityEngine.Object target)
        {
            if (target is GameObject)
            {
                gameObject = target as GameObject;
                transform  = gameObject.transform;
            }
            if (target is Transform)
            {
                transform = target as Transform;
                gameObject = transform.gameObject;
            }
            onSetTarget();
        }

        public virtual void onSetTarget() { }

        #endregion


        #region OnComplete Events

        private bool          onCompleteCallback      = false;
		private bool          onCompleteEventDestroy  = false;
		private GameObject    completeTarget          = null;
		private string        completeMetodo;
		private System.Object completeParametros;
	
		public TweenAction onComplete(MonoBehaviour parent, string metodo, System.Object parametros = null)
		{
			if(!string.IsNullOrEmpty(metodo))
			{
				onCompleteCallback  = true;
				completeTarget      = parent.gameObject;
				completeMetodo      = metodo;
				completeParametros  = parametros;
			}
			return this;
		}
	
        public TweenAction onCompleteDestroy()
		{
			onCompleteCallback     = true;
			onCompleteEventDestroy = true;
			return this;
		}
	
		private void execComplete()
		{
			if(onCompleteCallback) 
            {
                onCompleteCallback = false;
	
                if(completeTarget != null)
                    completeTarget.SendMessage( completeMetodo, completeParametros, SendMessageOptions.DontRequireReceiver);
                    
                if(onCompleteEventDestroy)
                    Tween.Destroy(gameObject);
            }
		}
	
		#endregion

	
		public virtual void Update()
		{
			float tFromStart = Time.time - startTime;    // Tiempo transcurrido
	
			if (delayEnabled) 
			{
				tFromStart -= delayTime;                 // Si tiene un delay se lo restamos
				if (tFromStart < 0) return;              // y no hacemos nada mientras estemos por debajo de 0
			}
	
			// aplicamos la escala para tener nuestro rango en <0.0-1.0>
            float t = tFromStart * factorTime;
			
			// vigilamos no pasar nunca de 1.0
			if (t >= 1.0f) 
			{
				t = 1.0f;
				isFinished = true;
			}
	
			// Interpolamos, en caso de tener una funcion
			if(interpolator != null)
				t = interpolator.getInterpolation(t);
            
            // llamamos al Update con el tiempo en factor (0,1) ya ponderado
            onUpdateTime(t);    // esto ya se sobrecarga en la Action sea de tipo Vector/Scalar
		}

        public virtual void onUpdateTime(float t) {  }
	
	
	}
}
