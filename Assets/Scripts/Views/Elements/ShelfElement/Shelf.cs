using Fridge.Model;
using Fridge.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Fridge.View.Shelf
{
    [Prefab("Elements/ShelfElement/Shelf")]
    public class Shelf : AbstractShelf
    {
        public Shelf(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {
           
        }

    }
}