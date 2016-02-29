using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ofcode.Tweens
{
	public class Tween : MonoBehaviour {
	
		// Lista de tweens activos
		private List<TweenAction> tweens       = new List<TweenAction>();
		
		//  ThreadSecure list
		private List<TweenAction> tweensSecure = new List<TweenAction>();
		private int TweenId, TweenCopyId = -1;
	
		// Los interpolators basicos
		public static TweenInterpolator InterpolatorLineal 		= null;
		public static TweenInterpolator InterpolatorExponential = new TweenInterpolatorExponential();
		public static TweenInterpolator InterpolatorElastic     = new TweenInterpolatorElastic();
		public static TweenInterpolator InterpolatorBounce      = new TweenInterpolatorBounce();
	
		// Instancia unica
		private static Tween tweenInstance = null;
		public static Tween getInstance()
		{
			if (tweenInstance == null) 
			{
				tweenInstance = (new GameObject ("Tweens")).AddComponent<Tween> ();
				tweenInstance.TweenId = 0;
				tweenInstance.TweenCopyId = 0;
			}
			return tweenInstance;
		}
	
		public static void Add(TweenAction action)
		{
			getInstance().AddSecure(action);
		}
	
		private bool AddSecure(TweenAction action)
		{
			// Si ya esta en la pila no añadimos
			if (tweens.Contains (action)) 
				return false;
				
			// Se añade a la lista y se incrementa el ID
			tweens.Add (action);
			TweenId ++;
			return true;
		}
	
		private bool RemoveSecure(TweenAction action)
		{
			// Si no existe no se puede borrar
			if (!tweens.Contains (action)) return false;
	
			// se borra de la lista y se incrementa el ID
			tweens.Remove(action);
			TweenId ++;
			return true;
		}
	
		public static int Count 
		{
			get { return getInstance().tweens.Count; } 
		}
	
		void Update()
		{
			// Creamos una copia de la pila para recorrerla de forma segura
			if (TweenId != TweenCopyId) 
			{
				TweenCopyId = TweenId;
				tweensSecure.Clear();
                tweensSecure.AddRange(tweens);
			}

			// Recorremos siempre la lista segura, de esta forma nadie la puede modificar
            foreach (TweenAction action in tweensSecure) 
			{
				action.Update ();
	
				if (action.isFinished)
				{
					RemoveSecure(action);
					action.end();
				}
			}
		}
	
	    /*
		public static TweenAction MoveTo(UnityEngine.Object target, Vector3 position, float time, TweenInterpolator interpolator = null)
		{
			TweenAction action = new TweenActionMoveTo(position, time, interpolator);
			action.setTarget(target);
			action.start();
            return action;
		}
	
		public static TweenAction RotateTo(UnityEngine.Object target, Vector3 angle, float time, TweenInterpolator interpolator = null)
		{
			TweenAction action = new TweenActionRotateTo(angle, time, interpolator);
			action.setTarget(target);
			action.start();
			return action;
		}
			
		public static TweenAction ScaleTo(UnityEngine.Object target, float factor, float time, TweenInterpolator interpolator = null)
		{
			TweenAction action = new TweenActionScaleTo (new Vector3(factor,factor,factor), time, interpolator);
			action.setTarget(target);
			action.start ();
			return action;
		}
		public static TweenAction FadeTo(UnityEngine.Object target, float alpha, float time, TweenInterpolator interpolator = null)
		{
			TweenAction action = new TweenActionFadeTo(alpha, time, interpolator);
			action.setTarget(target);
			action.start();
			return action;
		}
	    */
	
	}
}