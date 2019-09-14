using Fridge.Services;
using UnityEngine;

namespace Fridge.View.Shelf
{
    [Prefab("")]
    public class MainShelf : AbstractShelf
    {
        public MainShelf(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {

        }
    }
    
}
