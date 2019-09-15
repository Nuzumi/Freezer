using Fridge.Services;
using UnityEngine;

namespace Fridge.View
{
    public enum PageType { Fridge, PublicFridge, Recepies, AddProduct }

    public interface IPage : IHideableElement
    {
        PageType Type { get; }
    }

    public abstract class PageElement<T> : HideableElement<T> where T : MonoBehaviour
    {
        protected PageElement(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {
            go.SetActive(false);
        }
    }
}
