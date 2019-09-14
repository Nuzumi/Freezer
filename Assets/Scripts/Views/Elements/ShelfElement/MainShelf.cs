using Fridge.Services;
using UnityEngine;

namespace Fridge.View.Shelf
{
    [Prefab("Elements/ShelfElement/MainShelf")]
    public class MainShelf : AbstractShelf
    {
        public MainShelf(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {

        }

        public override void Init(string category)
        {
            base.Init(category);
            SetText(category);
        }

        private void SetText(string category)
        {
            component.CategoryText.text = category;
        }

    }
    
}
