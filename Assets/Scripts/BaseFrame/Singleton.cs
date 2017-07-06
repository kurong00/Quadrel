using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace FrameWork{
	public abstract class Singleton<T>:MonoBehaviour where T:Singleton<T> {
		protected static T instance = null;
		public static T Instance()
		{
			if (instance == null) 
			{
				instance = FindObjectOfType<T> ();
				if (FindObjectsOfType<T> ().Length > 1) 
				{
					Debug.Log ("more than one");
					return instance;
				}
				if (instance == null) 
				{
					string instanceName = typeof(T).Name;
					Debug.Log ("instance Name:" + instanceName);
					GameObject instanceGO = GameObject.Find (instanceName);
					if (instanceGO == null)
						instanceGO = new GameObject (instanceName);
					instance = instanceGO.AddComponent<T> ();
					//保证重新加载场景的时候实例不会被释放
					DontDestroyOnLoad (instanceGO);
					Debug.Log ("add new singleTon" + instance.name + " in the game");	
				}
			} 
			else
				Debug.Log ("already exit " + instance.name + " in the game");
			return instance;
		}
		protected virtual void OnDestory()
		{
			instance = null;
		}
	}
}
