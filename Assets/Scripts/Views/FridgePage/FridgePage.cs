using Fridge.Model;
using Fridge.Services;
using Fridge.View.Shelf;
using System.Collections.Generic;
using UnityEngine;

namespace Fridge.View.FridgeView
{
    public interface IFridgePage : IPage
    {

    }

    [Prefab("View/FridgePage/FridgePage")]
    public class FridgePage : PageElement<FridgePageComponent>, IFridgePage
    {
        readonly ShelfCreator ShelfCreator;

        public FridgePage(IServices services, IViews views, Transform parent) : base(services, views, parent) {
            ShelfCreator = new ShelfCreator(services, views, component.Shelves);
        }

        public Page Type => Page.Fridge;

        protected override void OnHidden()
        {}

        protected override void OnShow()
        {
            Services.HTTPService.GetProducts(SetShelves);
        }

        private void SetShelves(List<Product> products)
        {
            ShelfCreator.FillShelves(products);
        }
    }
}