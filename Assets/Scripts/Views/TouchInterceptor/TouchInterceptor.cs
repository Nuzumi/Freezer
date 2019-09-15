using Fridge.Services;
using System;
using UnityEngine;

namespace Fridge.View
{
    public interface ITouchInterceptor : IHideableElement
    {
        event Action OnTouchIntercepted;
        void Setup(int sortOrder, string sortLayer = "UI", float alpha = 0f);
        TouchInterceptorComponent Component { get; }
    }

    [Prefab("View/Touch/TouchInterceptor")]
    public class TouchInterceptor : HideableElement<TouchInterceptorComponent>, ITouchInterceptor
    {
        public event Action OnTouchIntercepted;
        public TouchInterceptorComponent Component => component;

        public TouchInterceptor(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {
            component.Button.onClick.AddListener(OnClick);
            go.SetActive(false);
        }

        void OnClick()
        {
            OnTouchIntercepted?.Invoke();
            Hide();
        }

        public void Setup(int sortOrder, string sortLayer = "UI", float alpha = 0f)
        {
            component.CanvasGroup.alpha = alpha;
            component.Canvas.sortingOrder = sortOrder;
            component.Canvas.sortingLayerName = sortLayer;
        }

        protected override void OnShow()
        {
        }

        protected override void OnHidden()
        {
        }
    }
}
