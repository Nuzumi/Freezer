using Fridge.Services;
using UnityEngine;

namespace Fridge.View.FridgeView
{
    public interface IFridgePage : IPage
    {

    }

    public class FridgePage : PageElement<FridgePageComponent>, IFridgePage
    {
        public FridgePage(IServices services, IViews views, Transform parent) : base(services, views, parent) { }

        public Page Type => Page.Fridge;

        protected override void OnHidden()
        {}

        protected override void OnShow()
        {}
    }
}