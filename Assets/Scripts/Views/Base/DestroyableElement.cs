using Fridge.Services;
using UnityEngine;

namespace Fridge.View
{
    public interface IDestroyableElement
    {
        Transform Transform { get; }
        void Destroy();
    }

    public abstract class DestroyableElement<T> : Element<T>, IDestroyableElement where T : MonoBehaviour
    {
        public Transform Transform => go.transform;

        protected abstract void OnDestroy();

        protected DestroyableElement(IServices services, IViews views, Transform parent) : base(services, views, parent) { }

        public void Destroy()
        {
            OnDestroy();
            Services.PrefabFactory.Store(go);
        }
    }
}
