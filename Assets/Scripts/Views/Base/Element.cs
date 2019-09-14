using Fridge.Services;
using TMPro;
using UnityEngine;

namespace Fridge.View
{
    public abstract class Element<T> where T : MonoBehaviour
    {
        public T component;
        public GameObject go;
        protected readonly IServices Services;
        protected readonly IViews Views;

        protected Element(IServices services, IViews views, Transform parent)
        {
            Services = services;
            Views = views;
            go = Services.PrefabFactory.Get(parent, GetType());
            component = go.GetComponent<T>();
        }
    }
}
