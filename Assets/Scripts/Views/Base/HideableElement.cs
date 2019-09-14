using Fridge.Services;
using UnityEngine;

namespace Fridge.View
{
    public interface IHideableElement
    {
        void Show();
        void Hide();

        GameObject Go { get; }
    }

    public abstract class HideableElement<T> : Element<T>, IHideableElement where T : MonoBehaviour
    {
        protected abstract void OnShow();
        protected abstract void OnHidden();

        public GameObject Go => go;

        protected HideableElement(IServices services, IViews views, Transform parent) : base(services, views, parent) { }

        public virtual void Show()
        {
            OnShow();
            go.SetActive(true);
        }

        public void Hide()
        {
            go.SetActive(false);
            OnHidden();
        }
    }
}
