using Fridge.Model;
using Fridge.Services;
using Fridge.View.Shelf;
using System.Collections.Generic;
using UnityEngine;

namespace Fridge.View.Page
{
    public interface IPublicFridgesPage : IPage
    {

    }

    [Prefab("View/PublicFridgesPage/PublicFridgesPage")]
    public class PublicFridgesPage : PageElement<PublicFridgesPageComponent>, IPublicFridgesPage
    {
        public PublicFridgesPage(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {
            component.MapButton.onClick.AddListener(() => Application.OpenURL("https://www.google.com/maps/d/u/0/viewer?mid=1e4QtlB9Rv4dSEOGGzz-Zgtb7KuPX75WI&hl=pl&ll=52.103701462363745%2C19.94394496315215&z=7"));
        }

        public PageType Type => PageType.PublicFridge;

        protected override void OnHidden()
        {
        }

        protected override void OnShow()
        {
        }
    }
}