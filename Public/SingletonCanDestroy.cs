using System;
using UnityEngine;

namespace KongZEE.Sinagleton.Public
{
    public class SingletonCanDestroy<T> : SingletonDontDestroy<T> where T : SingletonCanDestroy<T>
    {
        public override void OnAwake()
        {
            
        }
    }
}