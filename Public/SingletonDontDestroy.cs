using System;
using UnityEngine;

namespace KongZEE.Sinagleton.Public
{
    public class SingletonDontDestroy<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        CreateInstance();
                    }
                }

                return _instance;
            }
        }

        public static void CreateInstance()
        {
            GameObject obj = new GameObject();
            obj.name = typeof(T).Name;
            _instance = obj.AddComponent<T>();
        }
        
        public void Awake()
        {
            OnAwake();
        }

        public virtual void OnAwake()
        {
            if (_instance == null)
            {
                _instance = this as T;
            }
            else
            {
                if(_instance != this as T)
                    Destroy(gameObject);
            }
            
            DontDestroyOnLoad(gameObject);
        }
    }
}