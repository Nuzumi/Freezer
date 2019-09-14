using Fridge.Model;
using Fridge.Services;
using Fridge.View.Shelf;
using System.Collections.Generic;
using UnityEngine;

namespace Fridge.View.Page
{
    public interface IRecepiesPage : IPage
    {

    }

    [Prefab("View/RecepiesPage/RecepiesPage")]
    public class RecepiesPage : PageElement<RecepiesPageComponent>, IRecepiesPage
    {
        public RecepiesPage(IServices services, IViews views, Transform parent) : base(services, views, parent) {
           
        }

        public PageType Type => PageType.Recepies;

        protected override void OnHidden()
        {}

        protected override void OnShow()
        {
        }
    }
}