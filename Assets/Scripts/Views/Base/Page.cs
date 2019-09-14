using Fridge.Services;
using UnityEngine;

namespace Fridge.View
{
    public enum Page { Fridge, PublicFridge, Recepies }

    public interface IPage : IHideableElement
    {
        Page Type { get; }
    }

    public abstract class PageElement<T> : HideableElement<T> where T : MonoBehaviour
    {
        protected PageElement(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {
            go.SetActive(false);
        }
    }
}
