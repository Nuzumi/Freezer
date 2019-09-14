using Fridge.Services;
using TMPro;
using UnityEngine;

namespace Fridge.View
{
    public interface IView
    {
        IOptimizedEvent OnShowEvent { get; set; }
        IOptimizedEvent OnHideEvent { get; set; }
        bool IsShown { get; set; }

        void Show();
        void Hide();
    }

    public abstract class View<T> where T : ViewReferences
    {
        public T component;
        public GameObject go;

        protected readonly IServices Services;
        protected readonly IViews Views;

        protected abstract void OnHidden();
        protected abstract void OnShow();

        public IOptimizedEvent OnShowEvent { get; set; }
        public IOptimizedEvent OnHideEvent { get; set; }

        public bool IsShown { get; set; }

        protected View(IServices services, IViews views)
        {
            Services = services;
            Views = views;
            go = Services.PrefabFactory.Get(Views.CanvasTransform, GetType());
            go.SetActive(false);
            component = go.GetComponent<T>();
            component.OnHidden += OnHidden;

            OnHideEvent = new OptimizedEvent();
            OnShowEvent = new OptimizedEvent();
        }

        public void Show()
        {
            if(IsShown)
                return;
            IsShown = true;
            OnShow();
            OnShowEvent.Invoke();
            go.SetActive(true);
        }

        public virtual void Hide()
        {
            IsShown = false;
            OnHideEvent.Invoke();
            component.SetTrigger(AnimationHashes.ShowOut);
        }

    }
}
