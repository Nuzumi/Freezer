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
        public PublicFridgesPage(IServices services, IViews views, Transform parent) : base(services, views, parent) {
           
        }

        public PageType Type => PageType.PublicFridge;

        protected override void OnHidden()
        {}

        protected override void OnShow()
        {
        }
    }
}